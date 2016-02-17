using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using CNSP.Platform;
using CNSP.Core;

namespace CNSP.Platform.Paint
{
    public class DefaultStrategy :IfPaintStrategy//默认网络绘制算法
    {
        StyleSet NetStyle;   //绘制使用的样式集
        dNet curNetwork;
        //属性
        StyleSet IfPaintStrategy.PaintStyle
        {
            get
            {
                return NetStyle;
            }
        }
        SortedList<int, Image> IfPaintStrategy.Images
        {
            get
            {
                return curNetwork.SharedImages;
            }
        }
        //构造函数，输入用户当前使用的样式集
        public DefaultStrategy(StyleSet GlobalStyle)
		{
            NetStyle = GlobalStyle;
		}

        //更新网络样式集
        void IfPaintStrategy.UpdateStyle(StyleSet GlobalStyle)
        {
            if (GlobalStyle != null)
            {
                NetStyle = GlobalStyle;
            }
        }

        //更新网络节点坐标
        void IfPaintStrategy.UpdateLocation(XmlDocument doc)
        {
            if (doc != null)
            {
                curNetwork = new dNet(doc);
            }
        }

        //刷新网络图片列表
        void IfPaintStrategy.UpdateImage()
        {
            PaintParameter curNodePara;
            Image IRet;
            int index;

            //计算每个节点的绘制参数
            foreach (dNode curNode in curNetwork.Network)
            {
                curNodePara = new PaintParameter(curNode.Number, curNode.Degree, curNetwork.MaxDeg, curNetwork.MinDeg);
                curNode.Offset = new Point(curNodePara.x, curNodePara.y);
            }
            //绘制每个度所属的图片
            foreach (KeyValuePair<int, int> img in curNetwork.DegreeList)
            {
                curNodePara = new PaintParameter(img.Key, img.Key, curNetwork.MaxDeg, curNetwork.MinDeg);
                IRet = this.DrawNode(curNodePara, false);
                index = img.Key;
                curNetwork.SharedImages.Remove(index);
                curNetwork.SharedImages.Add(index, IRet);
            }
        }

        //绘制网络节点，输入绘制参数和是否高亮
        Image DrawNode(PaintParameter curNodePara, Boolean isHL)
        {
            Pen frame;					//显示变量 边框画笔
            Image img;                  //返回Image
            Graphics gGraphic;      //绘制目标图元
            GraphicsPath path;  //路径图形
            PathGradientBrush pthGrBrush;   //路径画笔
            int intRand;                    //半径

            intRand = curNodePara.intRand;
            //新建位图，存放节点图像
            img = new Bitmap(intRand * 2 + 1, intRand * 2 + 1);
            gGraphic = Graphics.FromImage(img);
            gGraphic.SmoothingMode = NetStyle.SmoothMode;//平滑处理
            //立体效果绘制
            path = new GraphicsPath();
            path.AddEllipse(0, 0, intRand * 2, intRand * 2);
            pthGrBrush = new PathGradientBrush(path);
            pthGrBrush.CenterColor = Color.FromArgb(255, 255, 255, 255);
            pthGrBrush.CenterPoint = new Point(Convert.ToInt32(2 * intRand * 0.618), Convert.ToInt32(intRand * 0.618));
            if (isHL == true)
            {//高亮节点使用高亮背景色和边框
                frame = new Pen(NetStyle.HLFrameColor);
                pthGrBrush.SurroundColors = new Color[] { NetStyle.HLBackColor };
            }
            else
            {//普通节点使用普通背景色和边框
                frame = new Pen(NetStyle.FrameColor);
                pthGrBrush.SurroundColors = new Color[] { NetStyle.BackColor };
            }
            //填充圆形
            gGraphic.FillEllipse(pthGrBrush, 0, 0, intRand * 2, intRand * 2);
            //外围边框绘制
            gGraphic.DrawEllipse(frame, 0, 0, 2 * intRand, 2 * intRand);
            return img;
        }
        
        //编号绘制函数，输入编号，起始点，目标图元
        void DrawString(string strNum, Point potStart, ref Graphics GraCam, Boolean isHL)
        {            
        	SolidBrush fore;				//显示变量 背景色刷

            //生成对应前景色笔刷
            if (isHL == true)
            {
                fore = new SolidBrush(NetStyle.HLForeColor);
            }
            else
            {
                fore = new SolidBrush(NetStyle.ForeColor);
            }
			//字符绘制
            GraCam.DrawString(strNum, NetStyle.charFont, fore, potStart.X, potStart.Y);
            fore.Dispose();
        }

        //绘制网络结构图，输入目标图元，和高亮节点编号（默认为没有）
        void IfPaintStrategy.Draw(ref Graphics GraCam, int intExclude)//
        {
            int intTarget, intRadiusSource, intRadiusTarget;
            Image curImg;
            Point potStart;
            dNode tarNode;
            //绘制连边
            foreach(dNode curNode in curNetwork.Network)
            {
                foreach (Edge edge in curNode)
                {
                    intTarget = edge.Target;
                    if (curNode.Number == intExclude || intTarget == intExclude)//被选中的节点连边不用画
                    {
                        continue;
                    }
                    tarNode = curNetwork.Network[intTarget];
                    //起始节点的半径
                    intRadiusSource = curNetwork.SharedImages[curNode.Degree].Width;
                    intRadiusSource = (intRadiusSource - 1) / 2;
                    //目标节点的半径
                    intRadiusTarget = curNetwork.SharedImages[tarNode.Degree].Width;
                    intRadiusTarget = (intRadiusTarget - 1) / 2;
                    //如果两节点处于同一个位置，则不绘制连边保证detX，detY不同时为0
                    if ((curNode.Location.X == tarNode.Location.X)
                        && (curNode.Location.Y == tarNode.Location.Y))
                    {
                        continue;
                    }
                    DrawLine(ref GraCam, curNode.Location, intRadiusSource,
                                    tarNode.Location, intRadiusTarget, (int)Math.Ceiling(edge.Value));
                }
            }
            //绘制节点
            foreach (dNode curNode in curNetwork.Network)
            {
                if (curNode.Number == intExclude)
                {
                    continue;
                }
                curImg = curNetwork.SharedImages[curNode.Degree];
                GraCam.DrawImage(curImg,
                                    new Point(curNode.Location.X - curImg.Width / 2,
                                                curNode.Location.Y - curImg.Height / 2));
                potStart = new Point(curNode.Location.X - curNode.Offset.X,
                                                curNode.Location.Y - curNode.Offset.Y);
                this.DrawString(curNode.Number.ToString(), potStart, ref GraCam, false);
            }
        }

        //绘制连边函数
        void DrawLine(ref Graphics GraCam, Point LocSource, int iRadiusSource, Point LocTarget, int iRadiusTarget, int iValue)
        {
            Pen LinePen;
            Point NewSource, NewTarget;

            LinePen = new Pen(Brushes.Gray);
            //连边宽度，暂时为权重，以后扩展
            LinePen.Width = iValue;
            //箭头
            if (curNetwork.Type == "有向图")
            {
                LinePen.CustomEndCap = new AdjustableArrowCap(3, 3, true);
            }
            //有向边起点坐标向终点方向移动iRadiusSource长度
            NewSource = LocationModify(LocSource, LocTarget, iRadiusSource);
            //有向边终点坐标向起点方向移动iRadiusTarget长度
            NewTarget = LocationModify(LocTarget, LocSource, iRadiusTarget);
            GraCam.DrawLine(LinePen, NewSource, NewTarget);
            LinePen.Dispose();
        }

        //有向边坐标调整函数
        Point LocationModify(Point LocSource, Point LocTarget, int iRadiusSource)
        {
            double dubDistance;
            int detX, detY, offsetX, offsetY;

            //计算向量的X，Y分量（保留正负号，不要取绝对值）
            detX = LocTarget.X - LocSource.X;
            detY = LocTarget.Y - LocSource.Y;
            //计算向量长度，这是绝对值
            dubDistance = Math.Sqrt(Math.Pow(detX, 2) + Math.Pow(detY, 2));
            //根据比例将待缩短的半径划分为X,Y方向上的分量 x = r * (dx / D)
            offsetX = Convert.ToInt32(iRadiusSource * detX / dubDistance);
            offsetY = Convert.ToInt32(iRadiusSource * detY / dubDistance);
            //偏移过的坐标就是修改后的新坐标
            return new Point(LocSource.X + offsetX, LocSource.Y + offsetY);
        }

        //高亮节点绘制函数
        public void DrawHighLightNode(int iNum, ref Graphics GraCam)
        {
            Image img;
            PaintParameter curNodePara;
            Point potStart;
            dNode curNode = curNetwork.Network[iNum];

            //计算网络绘制参数
            curNodePara = new PaintParameter(iNum, curNode.Degree, curNetwork.MaxDeg, curNetwork.MinDeg);
            //获取绘制完成的图片
            img = this.DrawNode(curNodePara, true);
            //在图元对应位置绘制图片
            GraCam.DrawImage(img, new Point(curNode.Location.X - img.Width / 2, curNode.Location.Y - img.Height / 2));
            //计算编号绘制起点
            potStart = new Point(curNode.Location.X - curNode.Offset.X, curNode.Location.Y - curNode.Offset.Y);
            //绘制节点编号
            this.DrawString(iNum.ToString(), potStart, ref GraCam, true);
        }

        //绘制高亮节点和其相关连边
        void IfPaintStrategy.DrawHighLightNodeEdge(int iNum, Point newLoc, ref Graphics GraCam)
        {
            int intRadiusSource, intRadiusTarget;
            dNode curNode = curNetwork.Network[iNum];

            curNode.Location = newLoc;
            //起始节点的半径
            intRadiusSource = curNetwork.SharedImages[curNode.Degree].Width;
            intRadiusSource = (intRadiusSource - 1) / 2;
            foreach (Edge edge in curNode)
            {
                dNode tarNode = curNetwork.Network[edge.Target];
                //目标节点的半径
                intRadiusTarget = curNetwork.SharedImages[tarNode.Degree].Width;
                intRadiusTarget = (intRadiusTarget - 1) / 2;
                //起始节点到目标点连边
                DrawLine(ref GraCam,
                               curNode.Location, intRadiusSource,
                               tarNode.Location, intRadiusTarget,
                               (int)Math.Ceiling(edge.Value));
                if (curNetwork.Type == "无向图")
                {
                    //目标点到起始节点连边
                    DrawLine(ref GraCam,
                                    tarNode.Location, intRadiusTarget,
                                   curNode.Location, intRadiusSource,
                                   (int)Math.Ceiling(edge.Value));
                }
            }
            if (curNetwork.Type == "有向图")
            {
                foreach (dNode tarNode in curNetwork.Network)
                {
                    if (tarNode.Contains(iNum) == true)
                    {
                        //目标节点的半径
                        intRadiusTarget = curNetwork.SharedImages[tarNode.Degree].Width;
                        intRadiusTarget = (intRadiusTarget - 1) / 2;
                        //目标节点到起始节点的连边
                        DrawLine(ref GraCam,
                                       tarNode.Location, intRadiusTarget,
                                       curNode.Location, intRadiusSource,
                                       (int)Math.Ceiling(tarNode.GetWeight(iNum)));
                    }
                }
            }
            //绘制高亮节点
            DrawHighLightNode(iNum, ref GraCam);
        }
    }
}
