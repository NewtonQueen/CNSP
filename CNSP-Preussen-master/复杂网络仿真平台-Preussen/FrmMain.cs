using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Media;
using System.Data.OleDb;
using CNSP.Platform;
using CNSP.Core;
using CNSP.DataBase;
using CNSP.Platform.Paint;
using CNSP.Platform.Create;
using CNSP.Platform.Parameter;
using System.Windows.Forms.DataVisualization.Charting;

namespace CNSP
{
    
    public partial class FrmMain : Form
    {
        int[,] Map;           //全局变量，节点坐标映射
        int PicWidth;         //全局变量，图像宽度
        int PicHeight;        //全局变量，图像高度
        int intFactor = 1;    //全局变量，比例系数
        public cNet ComplexNet;             //全局变量，复杂网络
        Graphics GraCam;             //全局变量，网络图形对象
        Graphics GraFore;             //全局变量，网络图形对象
        Bitmap img;                  //全局变量，网络图像
        Bitmap imgFore;                  //全局变量，网络图像

        const int BaseWidth=600;            //常量，基准宽度
        const int BaseHeight=500;           //常量，基准高度

        public static StyleSet GlobalPaintStyle;  // 全局变量 绘图风格
        //委托声明，用于处理StyleUpdate事件
        public delegate void StyleUpdateEventHandler(Object sender, StyleUpdateEventArgs e);
        //事件声明，用于发布Style被修改事件
        public event StyleUpdateEventHandler StyleUpdate;

        Boolean  bolTrace = false;          //内部使用，标记变量
        Point LastLoc = new Point(0,0);
        int intMove = -1;                    //内部使用，标记变量
        Boolean selected = false;           //内部使用，标记变量

        public FrmMain()                    //构造函数，初始化组件
        {
            InitializeComponent();          
        }

        //主窗体数据初始化
        private void FrmMain_Load(object sender, EventArgs e)
        {
            TabMain.TabPages.Clear ();
            TabMain.TabPages.Add (TabStructure );
        }

        //窗体控件重置
        public void FormReset()              
        {
			ComplexNet = null;
			PicCam.Image= null;
           //控件重置重置
			TabMain.TabPages.Clear();
			TabMain.TabPages.Add(TabStructure);

            //列表框重置
            NetNum.Text = "";
            NetDeg.Text = "";
            EdgeNum.Text = "";
            MaxDegree.Text = "";
            MaxNode.Text = "";
            MinDegree.Text = "";
            NodeList.Items.Clear();
        }

        //窗体图像重置
		public void GraphicReset()
		{
			int i, j;
            int x, y;
			
			if (intFactor < 1)
            {
                intFactor = 1;
            }
            //全局变量重置
            PicWidth  = BaseWidth * intFactor;          
            PicHeight = BaseHeight  * intFactor;
            
            if (img != null)
            {
                img.Dispose();
            }
            if (imgFore != null)
            {
                imgFore.Dispose();
            }
            img = new Bitmap(PicWidth, PicHeight);
            imgFore = new Bitmap(PicWidth, PicHeight);
            GraCam = Graphics.FromImage(img);
            GraFore = Graphics.FromImage(imgFore);
            GraCam.SmoothingMode = GlobalPaintStyle.SmoothMode;
            GraFore.SmoothingMode = GlobalPaintStyle.SmoothMode;
            PicCam.BackgroundImage = img;
            PicCam.Image = imgFore;
            Map = new int[PicHeight, PicWidth];
            
            for (i = 0; i < PicHeight; i++)
            {
                for (j = 0; j < PicWidth; j++)
                {
                    Map[i, j] = -1;
                }
            }
            
            //主窗体重置
            x = MainLayout.Location.X + TabMain.Location.X + PanelPic.Location.X + PicWidth + 40;
            y = MainLayout.Location.Y + TabMain.Location.Y + PanelPic.Location.Y + PicHeight + StatusStrip1.Size.Height + 78;
            this.MaximumSize = new Size(x, y);
		}

        //启动定时器中断函数
        private void StartTimer_Tick(object sender, EventArgs e)
        {
            StyleSetProxy dbReader = new StyleSetProxy();
            //响应一次后就关，以后不再进入
            StartTimer.Enabled = false;
            //读入数据库中保存的样式集
            GlobalPaintStyle = dbReader.ReadCurrent();
            //读取xml格式的zachary网络文件
            Read(Application.StartupPath.ToString() + "\\Zachary.xml");
            //响应一次后就关，以后不再进入
            StartTimer.Enabled = false;
        }

        //新建菜单项响应函数
        private void NewMI_Click(object sender, EventArgs e)
        {
            DialogResult choice;

            if (ComplexNet != null)                     //确保网络为空
            {
                choice =MessageBox.Show("是否保存当前网络？", "警告", MessageBoxButtons.YesNoCancel , MessageBoxIcon.Exclamation);
                if( choice ==DialogResult .Yes )
                {
                    if(SaveNetwork() ==false )          //保存网络
                    {
                        return;
                    }
                }
                else if( choice ==DialogResult .No )
                {
                }
                else if(choice ==DialogResult.Cancel )
                {
                    return ;
                }
            }
            DiaCreate diaNew = new DiaCreate(this); //新建网络对话框，新建网络
            if (diaNew.ShowDialog(this) == DialogResult.OK)
            {
                FormReset();                                           				//重置当前系统
                ComplexNet = diaNew.cNetwork;
                Initialized();
            }
            else if (diaNew.ShowDialog(this) == DialogResult.Abort)
            {
                MessageBox.Show("网络创建失败", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TSSL1.Text = "就绪";
            }
            diaNew.Dispose();
        }

        //打开菜单项响应函数
        private void OpenMI_Click(object sender, EventArgs e)
        {
            string strName;

            TSSL1.Text = "正在打开";//状态栏
            //初始化对话框，文件类型，过滤器，初始路径等设置
            this.DiaOpen.Filter = "All files (*.*)|*.*|XML files (*.xml)|*.xml|Standard list files (*.sst)|*.sst|三元组网络文件 (*.tri)|*.tri|MATLAB files (*.mat)|*.mat|Key Word Text files (*.kwt)|*.kwt";
            this.DiaOpen.FilterIndex = 0;
            this.DiaOpen.InitialDirectory = Application.StartupPath ;
            this.DiaOpen.RestoreDirectory = true ;
            //成功选取文件后，根据文件类型执行读取函数
            if(this.DiaOpen.ShowDialog() != DialogResult.OK)
            {
            	return;
            }
            Cursor = Cursors.WaitCursor;
            strName = this.DiaOpen.FileName;
            Read(strName);
			Cursor = Cursors.Arrow;
            TSSL1.Text = "就绪";
			return;
        }

        //文件读取函数，输入文件路径
        void Read(string sPath)
        {
            Error eRet = null;

            FormReset();                                           				//重置当前系统
            ComplexNet = cNet.Read(sPath, ref eRet);												//调用下层函数，文件解析
            if (eRet.intError != 0)
            {
                Cursor = Cursors.Arrow;
                TSSL1.Text = "就绪";
                MessageBox.Show(eRet.ToString(), "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Initialized();
        }
		
        //填充节点位置映射矩阵
        void FillMap()
		{
			int iNum;
			Point curPot;
			
			for (iNum = 0 ; iNum < ComplexNet.intNumber; iNum++)    
			{
				curPot = ComplexNet.Network[iNum].Location;
				Map[curPot.Y, curPot.X] = iNum;
			}
		}

        //节点放置函数，可选择放置方式
        public void PlaceNodes(string opt)
        {
            if (ComplexNet.Network[0].Location.X != 0 || ComplexNet.Network[0].Location.Y != 0)
            {
                return;
            }
            switch (opt)
            {
                case "Random":
                    RandomPlaceNode();
                    break;
                case "Cycle":
                    break;
                case "Tree":
                    break;
                default:
                    RandomPlaceNode();
                    break;
            }
        }

        //节点随机放置函数
        private void RandomPlaceNode()
        {
            int xleftlimit, xrightlimit, yuplimit, ydownlimit;
            int i, j;
            //生成基本参数，画布尺寸和放置区域
            xleftlimit = 0;
            xrightlimit = 0;
            xrightlimit = PicWidth;
            yuplimit = 0;
            ydownlimit = 0;
            ydownlimit = PicHeight;
            Map = new int[ydownlimit, xrightlimit];

            for (i = 0; i < ydownlimit; i++)
            {
                for (j = 0; j < xrightlimit; j++)
                {
                    Map[i, j] = -1;
                }
            }
            //循环调用单点定位函数
            for (i = 0; i < ComplexNet.intNumber; i++)
            {
                ComplexNet.Network[i].Location = SetPoint(i, xleftlimit, xrightlimit, yuplimit, ydownlimit);
            }
        }

        //单一节点放置函数
        private Point SetPoint(int iNum, int lLimit, int rLimit, int uLimit, int dLimit)
        {
            Point curPoint;
            Random magic1 = new Random(DateTime.Now.Millisecond * DateTime.Now.Second * iNum);
            Random magic2 = new Random(magic1.Next(1, 99 * (iNum + 1)) * DateTime.Now.Millisecond);

            //位置合法性检测，不可超过画布范围
            if (lLimit < 0)
            {
                lLimit = 0;
            }
            if (rLimit > PicWidth)
            {
                rLimit = PicWidth;
            }
            if (uLimit < 0)
            {
                uLimit = 0;
            }
            if (dLimit > PicHeight)
            {
                dLimit = PicHeight;
            }
            curPoint = new Point(0, 0);
            curPoint.X = magic1.Next(lLimit, rLimit);
            curPoint.Y = magic2.Next(uLimit, dLimit);
            while (Map[curPoint.Y, curPoint.X] != -1)//如有重叠则重新生成位置
            {
                magic1 = new Random(DateTime.Now.Millisecond * DateTime.Now.Second * iNum);
                magic2 = new Random(magic1.Next(0, 1000 * iNum));
                curPoint.X = magic1.Next(lLimit, rLimit);
                curPoint.Y = magic2.Next(uLimit, dLimit);
            }
            return curPoint;
        }

        private void Initialized()
        {
            //计算网络系数
            intFactor = Convert.ToInt32(ComplexNet.intNumber * 1.0 / 300);
            //重置图像
            GraphicReset();
            //放置节点
            PlaceNodes("Random");
            //填充节点映射矩阵
            FillMap();
            //更新绘图网络
            ComplexNet.Initialized(GlobalPaintStyle);
            //绘制网络结构图
            ComplexNet.Draw(ref GraCam);
            //处理后续操作         					
            AfterCreated();
            //订阅StyleSet更新事件
            StyleUpdate += ComplexNet.UpdateStyle;
        }


        //保存菜单项响应函数
        private void SaveMI_Click(object sender, EventArgs e)
        {
            if (ComplexNet == null)
            {
                MessageBox.Show("请先读取或生成一个网络！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //保存网络到文件
            SaveNetwork();          
        }

        //保存网络数据到文件
        private Boolean SaveNetwork()
        {
            string strName;
            Error eRet;

            TSSL1.Text = "正在保存";
            //初始化对话框，文件类型，过滤器，初始路径等设置
            this.DiaSave.Filter = "XML files (*.xml)|*.xml|Standard list files (*.sst)|*.sst|三元组网络文件 (*.tri)|*.tri|MATLAB files (*.mat)|*.mat";
            this.DiaSave.FilterIndex = 0;
            this.DiaSave.InitialDirectory = Application.StartupPath;
            this.DiaSave.RestoreDirectory = true;
            //创建文件名后，根据文件类型执行保存函数
            if (this.DiaSave.ShowDialog() != DialogResult.OK)
            {
            	return false;
            }
            Cursor = Cursors.WaitCursor;
            strName = this.DiaSave.FileName;
            //调用下层函数，文件解析
            eRet = ComplexNet.Save(strName);												
			if(eRet.intError != 0)
			{
				Cursor = Cursors.Arrow;
            	TSSL1.Text = "就绪";
				MessageBox.Show(eRet.ToString(), "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			Cursor = Cursors.Arrow;
			TSSL1.Text = "就绪";
            return true;
        }

        //后续事务处理函数
        private void AfterCreated()
        {
            //读取节点列表
             LoadList();
             //读取普通网络参数
             LoadNetData();     
        }

        //读取节点列表
        private void LoadList()
        {
            string strNode = "";
            int i;

            for(i=0; i < ComplexNet .intNumber; i++ )
            {
                strNode = "节点" + i.ToString() + ",度：" + ComplexNet.Network[i].Degree.ToString();
                NodeList.Items.Add(strNode);
            }
        }

        //读取普通网络参数
        private void LoadNetData()
        {
            NetNum.Text = ComplexNet.intNumber.ToString();              //网络节点数
            NetDeg.Text = Math.Round(ComplexNet.AveDeg, 3).ToString();  //网络平均度
            EdgeNum.Text = ComplexNet.intEdge.ToString();               //网络连边数
            MaxDegree.Text = ComplexNet.MaxDeg.ToString();              //网络最大度
            MaxNode.Text = ComplexNet.Master;
            MinDegree.Text = ComplexNet.MinDeg.ToString();              //网络最小度
            TypeBox.Text = ComplexNet.Type;                                 //网络类型
        }

        //清除菜单项响应函数
       private void ClearMI_Click(object sender, EventArgs e)
       {
           FormReset();       //清除网络数据
           GraphicReset();
       }

        //退出菜单项响应函数
       private void ExitMI_Click(object sender, EventArgs e)
       {
           FormReset();       //清除网络数据
           GraphicReset();
           this.Close();    //关闭窗口
       }

       //节点列表，节点信息刷新
       private void NodeList_SelectedIndexChanged(object sender, EventArgs e)
       {
           int intTarget;
           
           if (this.NodeList.SelectedIndex > -1)
           {
               intTarget = this.NodeList.SelectedIndex;
               SelectNode(intTarget, ComplexNet.Network[intTarget].Location);

               if (TabMain.TabPages.Contains(TabDegDist) == true )
               {
                   Border3DAnnotation txtShow = new Border3DAnnotation();//显示标注
                   DegreeChart.Annotations.Clear(); 
                   txtShow.Text ="节点："+intTarget .ToString ();
                   txtShow.LineWidth = 2;
                   txtShow.LineColor = Color.Gainsboro;
                   txtShow.ForeColor = Color.Black;
                   txtShow.BackColor = Color.LightYellow;                
                   txtShow.AnchorDataPoint = DegreeChart.Series["DegLine"].Points[ComplexNet.Network[intTarget].Degree];
                   DegreeChart.Annotations.Add(txtShow);
               }
           }
       }

       //选择节点
       public void SelectNode(int intTarget, Point newLoc)
       {
           //在背景图层上绘制未选中节点
           GraCam.Clear(Color.Transparent);
           ComplexNet.Draw(ref GraCam, intTarget);
           //在前景图层上绘制选中高亮节点
           GraFore.Clear(Color.Transparent);
           ComplexNet.DrawHighLightNodeEdge(intTarget, newLoc, ref this.GraFore);
           PicCam.Refresh();
           //记录选中的节点
           intMove = intTarget;
           //打开选中标志
           selected = true;
       }

       //保存网络结构图
       private void PicCam_DoubleClick(object sender, EventArgs e)
       {
           string strName;

           DiaSave.Filter = "";
           DiaSave.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
           DiaSave.FilterIndex = 0;
           DiaSave.InitialDirectory = Application.StartupPath;
           DiaSave.RestoreDirectory = true;
           if (DiaSave.ShowDialog() == DialogResult.OK)
           {
               strName = DiaSave.FileName;
               img.Save(strName);
           }
       }
       
        //以下 高级图形显示功能，建议不要改动
       private void CheckXY(ref int x, ref int y)//检查节点坐标是否超出图像边界
       {
           if (x < 0)
           {
               x = 0;
           }
           if (x > PicWidth-1)
           {
               x = PicWidth-1;
           }
           if (y < 0)
           {
               y = 0;
           }
           if (y > PicHeight-1)
           {
               y = PicHeight-1;
           }
       }
       
        //图像框鼠标单击事件响应函数
       private void PicCam_MouseClick(object sender, MouseEventArgs e)
       {
           int intTarget;

           //显示单击点坐标
           TSSL3.Text = e.X.ToString() + "," + e.Y.ToString();
           if (e.Button == MouseButtons.Left)
           {
               //搜索单击点5像素范围内是否存在节点
               intTarget = SearchNode(e);
               if (intTarget != -1)
               {//找到一个
                   //清除当前选中的
                   NodeList.ClearSelected();
                   //改选中最近搜索到的
                   NodeList.SetSelected(intTarget, true);
                   //选中后的处理
                   SelectNode(intTarget, ComplexNet.Network[intTarget].Location);
                   //打开移动标记位
                   bolTrace = true;
                   return;
               }
           }
           //如果没有节点则取消选中
           if (selected == true)
           {
               intMove = -1;
               selected = false;
               NodeList.ClearSelected();
               GraCam.Clear(Color.Transparent);
               GraFore.Clear(Color.Transparent);
               //在主图层上绘制完整的网络
               ComplexNet.Draw(ref GraCam);     
               PicCam.Refresh();
           }
       }
       
        //图像框鼠标按下事件响应函数
       private void PicCam_MouseDown(object sender, MouseEventArgs e)
       {
           int intTarget;

            //如果当前有节点选中
           if (selected == true)
           {
               if (e.Button == MouseButtons.Left)
               {
                   //搜索按下位置附近的节点
                   intTarget = SearchNode(e);
                   //按下位置的节点和当前选中一致
                   if (intTarget == intMove)
                   {
                       //保持移动标志为true
                       bolTrace = true;
                       return;
                   }
               }
           }
            //没找到则清除移动标志
           bolTrace = false;
       }
       
        //图像框鼠标移动事件响应函数
        private void PicCam_MouseMove(object sender, MouseEventArgs e)
       {
           int intTarget,x,y;
           
            //当前存在选中节点，同时鼠标按下
           if (selected == true && bolTrace == true)
           {
               //检查当前鼠标位置是否和之前一次相同
               if (e.X == LastLoc.X && e.Y== LastLoc.Y)
               {
                   return;
               }
               x = e.X;
               y = e.Y;
               CheckXY(ref x, ref y);
               //记录新的位置
               LastLoc = new Point(x, y);
               intTarget = intMove;
               //清除映射矩阵中旧位置的标记
               Map[ComplexNet.Network[intTarget].Location.Y, ComplexNet.Network[intTarget].Location.X] = -1;
               //修改节点位置
               ComplexNet.Network[intTarget].Location = LastLoc;
               //在映射矩阵中注册新的节点位置
               Map[ComplexNet.Network[intTarget].Location.Y, ComplexNet.Network[intTarget].Location.X] = intTarget;
               GraFore.Clear(Color.Transparent);
               //绘制高亮节点和有关连边
               ComplexNet.DrawHighLightNodeEdge(intTarget, LastLoc, ref GraFore);
               PicCam.Refresh();
               TSSL2.Text = e.X.ToString() + "," + e.Y.ToString();
           }
       }

        //检查鼠标点击位置周围是否存在节点
       int SearchNode(MouseEventArgs e)
       {
           int left, right, up, down;
           int i, j;
           const int intRange = 10;

           left = e.X - intRange;
           right = e.X + intRange;
           up = e.Y - intRange;
           down = e.Y + intRange;
           CheckXY(ref left, ref up);
           CheckXY(ref right, ref down);
            for (i = up; i <= down; i++)
            {
                for (j = left; j <= right; j++)
                {
                    if (Map[i, j] != -1)
                    {
                        return Map[i, j];
                    }
                }
            }
           return -1;
       }

        //图像框鼠标释放事件响应函数
       private void PicCam_MouseUp(object sender, MouseEventArgs e)
       {
           //鼠标释放，清除移动标记，节点不能移动。
           if (bolTrace == true)
           {
               bolTrace = false;
           }
       }
       //以上 高级图形显示功能，建议不要改动

        //节点类表双击事件响应函数
       private void NodeList_MouseDoubleClick(object sender, MouseEventArgs e)
       {
           if (e.Button == MouseButtons.Left)
           {
               DiaNodeInfo diaNode = new DiaNodeInfo(this);
               //显示节点信息对话框
               diaNode.ShowDialog(this);
               diaNode.Dispose();
           }
       }

       //度分布图表显示
       private void DegreeDistMI_Click(object sender, EventArgs e)
       {
           if (ComplexNet == null)
           {
               MessageBox.Show("请先读取或生成一个网络！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return;
           }
           DegreeChart.Series[0].Points.DataBindY(ComplexNet.netState.intDegDist);//数据绑定
           if (TabMain.TabPages.Contains(TabDegDist) == false)
           {
               TabMain.TabPages.Add(TabDegDist);
           }
           TabMain.SelectedTab = TabDegDist;
       }

       //对数分布图表显示
       private void LogDistMI_Click(object sender, EventArgs e)
       {
           if (ComplexNet == null)
           {
               MessageBox.Show("请先读取或生成一个网络！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return;
           }
           DrawLogChart();
           if (TabMain.TabPages.Contains(TabLogDist) == false)
           {
               TabMain.TabPages.Add(TabLogDist);
           }
           TabMain.SelectedTab = TabLogDist;
       }

       //对数分布图表显示功能函数
       private void DrawLogChart()
       {
           int[] dxvalue;
           float[] dyvalue;
           int i,j,intCount;

           intCount = 0;
           for (i = 1; i <= this.ComplexNet.MaxDeg - 1; i++)//统计数据数量
           {
               if (ComplexNet.netState.intDegDist[i] > 0)
               {
                   intCount += 1;
               }
           }
           dxvalue = new int[intCount];
           dyvalue = new float[intCount];                   //初始化数组

           j = 0;
           for (i = 1; i <= this.ComplexNet.MaxDeg - 1; i++)
           {
               if (ComplexNet.netState.intDegDist[i] > 0)
               {
                   //填入数组
                   dxvalue[j] = i;
                   dyvalue[j] = ComplexNet.netState.intDegDist[i] * 1.0f / ComplexNet.intEdge;
                   j += 1;
               }
           }
           LogDegree.Series[0].Points.DataBindXY(dxvalue, dyvalue);     //数据绑定，显示
       }

       //度分布图图表注释显示
       private void DegreeChart_GetToolTipText(object sender, ToolTipEventArgs e)
       {
           int intIndex;

           switch (e.HitTestResult.ChartElementType)
           {
               case ChartElementType.Axis:
                   e.Text = e.HitTestResult.Axis.Title ;
                   break;
               case ChartElementType.DataPoint:
                   intIndex =e.HitTestResult.PointIndex+1;
                   e.Text = "度为:" + intIndex.ToString();
                   break;
               case ChartElementType.LegendArea:
                   e.Text = "图例";
                   break;
               case ChartElementType.PlottingArea:
                   e.Text = "绘图区";
                   break;
               case ChartElementType.Title:
                   e.Text = "图题";
                   break;
           }

       }

       //对数分布图图表注释显示
       private void LogDegree_GetToolTipText(object sender, ToolTipEventArgs e)
       {
           switch (e.HitTestResult.ChartElementType)
           {
               case ChartElementType.Axis:
                   e.Text = e.HitTestResult.Axis.Title;
                   break;
               case ChartElementType.LegendArea:
                   e.Text = "图例";
                   break;
               case ChartElementType.PlottingArea:
                   e.Text = "绘图区";
                   break;
               case ChartElementType.Title:
                   e.Text = "图题";
                   break;
           }
       }

       //度分布图双击事件响应函数
       private void DegreeChart_MouseDoubleClick(object sender, MouseEventArgs e)//保存度分布图
       {
           string strName;
           string[] strSeg;
           if (e.Button == MouseButtons.Left)
           {
               TSSL1.Text = "正在保存";
               this.DiaSave.Filter = "Bitmap (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg|EMF (*.emf)|*.emf|PNG (*.png)|*.png|SVG (*.svg)|*.svg|GIF (*.gif)|*.gif|TIFF (*.tif)|*.tif";
               this.DiaSave.FilterIndex = 0;
               this.DiaSave.InitialDirectory = Application.StartupPath;
               this.DiaSave.RestoreDirectory = true;

               if (this.DiaSave.ShowDialog() == DialogResult.OK)
               {
                   ChartImageFormat format = ChartImageFormat.Bmp;

                   Cursor = Cursors.WaitCursor;
                   strName = this.DiaSave.FileName;
                   strSeg = strName.Split(new char[] { '.' });
                   strSeg[strSeg.Length - 1] = strSeg[strSeg.Length - 1].ToLower();
                   switch (strSeg[strSeg.Length - 1])//格式选择
                   {
                       case "bmp":
                           format = ChartImageFormat.Bmp;
                           break;
                       case "jpg":
                           format = ChartImageFormat.Jpeg;
                           break;
                       case "emf":
                           format = ChartImageFormat.Emf;
                           break;
                       case "gif":
                           format = ChartImageFormat.Gif;
                           break;
                       case "png":
                           format = ChartImageFormat.Png;
                           break;
                       case "tif":
                           format = ChartImageFormat.Tiff;
                           break;
                   }
                   DegreeChart.SaveImage(DiaSave.FileName, format);//保存
                   Cursor = Cursors.Arrow;
                   TSSL1.Text = "就绪";
               }
               else
               {
                   TSSL1.Text = "就绪";
               }
           }
       }
       
        //对数分布图双击事件响应函数
        private void LogDegree_MouseDoubleClick(object sender, MouseEventArgs e)//保存对数分布图
       {
           string strName;
           string[] strSeg;
           if (e.Button == MouseButtons.Left)
           {
               TSSL1.Text = "正在保存";
               this.DiaSave.Filter = "Bitmap (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg|EMF (*.emf)|*.emf|PNG (*.png)|*.png|SVG (*.svg)|*.svg|GIF (*.gif)|*.gif|TIFF (*.tif)|*.tif";
               this.DiaSave.FilterIndex = 0;
               this.DiaSave.InitialDirectory = Application.StartupPath;
               this.DiaSave.RestoreDirectory = true;

               if (this.DiaSave.ShowDialog() == DialogResult.OK)
               {
                   ChartImageFormat format = ChartImageFormat.Bmp;

                   Cursor = Cursors.WaitCursor;
                   strName = this.DiaSave.FileName;
                   strSeg = strName.Split(new char[] { '.' });
                   strSeg[strSeg.Length - 1] = strSeg[strSeg.Length - 1].ToLower();
                   switch (strSeg[strSeg.Length - 1])//格式选择
                   {
                       case "bmp":
                           format = ChartImageFormat.Bmp;
                           break;
                       case "jpg":
                           format = ChartImageFormat.Jpeg;
                           break;
                       case "emf":
                           format = ChartImageFormat.Emf;
                           break;
                       case "gif":
                           format = ChartImageFormat.Gif;
                           break;
                       case "png":
                           format = ChartImageFormat.Png;
                           break;
                       case "tif":
                           format = ChartImageFormat.Tiff;
                           break;
                   }
                   LogDegree.SaveImage(DiaSave.FileName, format);//保存
                   Cursor = Cursors.Arrow;
                   TSSL1.Text = "就绪";
               }
               else
               {
                   TSSL1.Text = "就绪";
               }
           }
       }

        //关于菜单项响应函数
       private void AboutMI_Click(object sender, EventArgs e)//“关于”窗口
       {
           DiaAbout diaAbout = null;

           if (diaAbout == null)
           {
               diaAbout = new DiaAbout();
           }
           diaAbout.ShowDialog(this);
       }

       //参数计算菜单项单击响应函数
       private void ParaMI_Click(object sender, EventArgs e)
       {
           DiaParameter diaPara = null;
           if (ComplexNet == null)
           {
               MessageBox.Show("请先读取或生成一个网络！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return;
           }
           if (diaPara == null)
           {
               diaPara = new DiaParameter(this);
           }
           diaPara.ShowDialog(this);
           diaPara.Dispose();
       }

        //内容菜单项响应函数
       private void ContentMI_Click(object sender, EventArgs e)
       {
           Read(Application.StartupPath.ToString() + "\\十八大报告.kwt"); 
       }

        //用户选项菜单项响应函数
       private void OptionMI_Click(object sender, EventArgs e)
       {
           DiaOption diaOption = null;

           if (diaOption == null)
           {
               diaOption = new DiaOption();
           }
           diaOption.ShowDialog(this);
           //获取用户设置的样式集
           if (GlobalPaintStyle.Equals( diaOption.CurrentStyle) == false)
           {
               GlobalPaintStyle = diaOption.CurrentStyle;
           }
           //更新当前网络图像
           UpdateStyleSet();
           diaOption.Dispose();
       }

        //更新样式集与图像
       void UpdateStyleSet()
       {
           if (ComplexNet == null)
           {
               MessageBox.Show("请先读取或生成一个网络！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               return;
           }
           //更新网络内部样式集
           if (StyleUpdate != null)
           {
               StyleUpdate(this, new StyleUpdateEventArgs(GlobalPaintStyle));
           }
           //更新图像
           ComplexNet.UpdateImage();
           //重置图像
           GraphicReset();
           //填充节点位置映射矩阵
           FillMap();
           //绘制网络结构图
           ComplexNet.Draw(ref GraCam);     
           //刷新图像框         					
           PicCam.Refresh();
       }

        //Tab控件双击事件响应函数
       private void TabMain_DoubleClick(object sender, EventArgs e)
       {
           int intTarget;

           //获取当前活跃的选项卡索引
           intTarget = TabMain.SelectedIndex;
           //如果是网络结构图选项卡，不允许关闭
           if (intTarget == 0)
           {
               return;
           }
           //其他选项卡可以关闭
           TabMain.TabPages.RemoveAt(intTarget);
           TSSL1.Text = "就绪";
       }
    }
}
