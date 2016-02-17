using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using CNSP.DataBase;
using CNSP.Platform.Paint;

namespace CNSP.Platform
{
    public partial class DiaOption : Form
    {
        public StyleSet CurrentStyle; //当前Main使用的样式
        public StyleSet ModifyStyle; //保存用户临时设置的样式
        public List<StyleSet> Preset;   //预设的样式集

        public DiaOption()
        {
            InitializeComponent();
        }

        void LoadStyle()
        {
            foreach (StyleSet paint in Preset)
            {
                StyleList.Items.Add(paint.Name);
            }
        }

        //刷新两个PictureBox，并用指定样式绘图
        void RefreshGraph(StyleSet PaintStyle)
        {
            //普通节点视图
            NodeImage.Image = DrawNode(PaintStyle, false);
            NodeImage.Refresh();
            //高亮节点视图
            HLImage.Image = DrawNode(PaintStyle, true);
            HLImage.Refresh();
        }

        //填充界面控件内容
        void FillContent(StyleSet PaintStyle)
        {
            DescBox.Text = PaintStyle.Description;
            FontBox.Text = PaintStyle.charFont.Name;
            SizeBox.Text = PaintStyle.charFont.Size.ToString();
            ForeLabel.BackColor = PaintStyle.ForeColor;
            BackLabel.BackColor = PaintStyle.BackColor;
            FrameLabel.BackColor = PaintStyle.FrameColor;
            HLForeLabel.BackColor = PaintStyle.HLForeColor;
            HLBackLabel.BackColor = PaintStyle.HLBackColor;
            HLFrameLabel.BackColor = PaintStyle.HLFrameColor;
            SmoothBox.SelectedIndex = (int)PaintStyle.SmoothMode;
        }

        //绘制预览节点
        Image DrawNode(StyleSet NetStyle, Boolean isHL)
        {
            Pen frame;					//显示变量 边框画笔
            GraphicsPath path;  //路径图形
            PathGradientBrush pthGrBrush;   //路径画笔
            Graphics graPreview;
            Image imgPreview;
            int intRand;

            intRand = 30;
            imgPreview = new Bitmap(2 * intRand + 1, 2 * intRand + 1);
            graPreview = Graphics.FromImage(imgPreview);

            //新建位图，存放节点图像
            graPreview.SmoothingMode = NetStyle.SmoothMode;//平滑处理
            //立体效果绘制
            path = new GraphicsPath();
            path.AddEllipse(0, 0, intRand * 2, intRand * 2);
            pthGrBrush = new PathGradientBrush(path);
            pthGrBrush.CenterColor = Color.FromArgb(255, 255, 255, 255);
            pthGrBrush.CenterPoint = new Point(Convert.ToInt32(2 * intRand * 0.618), Convert.ToInt32(intRand * 0.618));
            //高亮节点采用特定的颜色
            if (isHL == true)
            {
                frame = new Pen(NetStyle.HLFrameColor);
                pthGrBrush.SurroundColors = new Color[] { NetStyle.HLBackColor };
            }
            else
            {
                frame = new Pen(NetStyle.FrameColor);
                pthGrBrush.SurroundColors = new Color[] { NetStyle.BackColor };
            }
            graPreview.FillEllipse(pthGrBrush, 0, 0, intRand * 2, intRand * 2);
            //外围边框绘制
            graPreview.DrawEllipse(frame, 0, 0, 2 * intRand, 2 * intRand);
            //绘制节点编号
            DrawString(NetStyle, ref graPreview, isHL);
            return imgPreview;
        }

        //绘制节点编号，使用前景色
        void DrawString(StyleSet NetStyle, ref Graphics GraCam, Boolean isHL)
        {
            SolidBrush fore;				//显示变量 背景色刷

            //高亮节点使用高亮前景色
            if (isHL == true)
            {
                fore = new SolidBrush(NetStyle.HLForeColor);
            }
            else
            {
                fore = new SolidBrush(NetStyle.ForeColor);
            }
            
            //字符绘制
            GraCam.DrawString("预览", NetStyle.charFont, fore, 14, 24);
            fore.Dispose();
        }

        //OK按钮响应函数
        private void OK_Button_Click(object sender, EventArgs e)
        {
            //如果应用按钮使能表示有用户数据未保存
            if (ApplyButton.Enabled == true)
            {
                ApplyButton_Click(sender,e);
            }
        }

        //保存用户暂存数据到数据库
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            StyleSetProxy dbReader = new StyleSetProxy();
            //保存数据到数据库
            dbReader.SaveCurrent(ModifyStyle);
            //用当前用户设定样式集替换目前工作的样式集
            CurrentStyle = ModifyStyle;
        }

        //启动定时器中断函数
        private void StartTimer_Tick(object sender, EventArgs e)
        {
            StyleSetProxy dbReader = new StyleSetProxy();
            //响应一次后就关，以后不再进入
            StartTimer.Enabled = false;
            //读取当前工作用的样式集
            CurrentStyle = dbReader.ReadCurrent();
            //读取系统预设的样式集列表
            Preset = dbReader.ReadPreset();
            //刷新预览图
            RefreshGraph(CurrentStyle);
            //填充界面数据
            FillContent(CurrentStyle);
            //读取预设样式集列表
            LoadStyle();
            //使用当前工作的样式集初始化待用户修改的样式集
            ModifyStyle = new StyleSet(CurrentStyle);
            //启动后台检测定时器，用户检查ModifyStyle是否被用户改动了
            CheckTimer.Enabled = true;
        }

        //修改检查定时器
        private void CheckTimer_Tick(object sender, EventArgs e)
        {
            //如果当前工作样式集等于用户设定暂存样式集则表示没有修改过
            if (CurrentStyle.Equals(ModifyStyle) == true)
            {
                //此时应用按钮去使能，无需保存
                if (ApplyButton.Enabled == true)
                {
                    ApplyButton.Enabled = false;
                }
                return;
            }
            //启用应用按钮
            if (ApplyButton.Enabled == false)
            {
                ApplyButton.Enabled = true;
            }
        }

        //字体设置对话框响应
        private void FontButton_Click(object sender, EventArgs e)
        {
            //设置对话框字体为当前设置的字体
            diaFont.Font = ModifyStyle.charFont;
            if (diaFont.ShowDialog(this) == DialogResult.OK)
            {
                //当前设置字体设置为对话框的字体
                ModifyStyle.charFont = diaFont.Font;
                //数据回填到界面控件
                FontBox.Text = ModifyStyle.charFont.Name;
                SizeBox.Text = ModifyStyle.charFont.Size.ToString();
                //刷新预览图
                RefreshGraph(ModifyStyle);
            }
        }

        //前景色设置对话框响应
        private void ForeButton_Click(object sender, EventArgs e)
        {
            //设置对话框颜色为当前设置的颜色
            diaColor.Color = ModifyStyle.ForeColor;
            if (diaColor.ShowDialog(this) == DialogResult.OK)
            {
                //当前设置颜色设置为对话框的颜色
                ModifyStyle.ForeColor = diaColor.Color;
                //数据体现到界面控件
                ForeLabel.BackColor = ModifyStyle.ForeColor;
                //刷新预览图
                RefreshGraph(ModifyStyle);
            }
        }

        //背景色设置色对话框响应
        private void BackButton_Click(object sender, EventArgs e)
        {
            //设置对话框颜色为当前设置的颜色
            diaColor.Color = ModifyStyle.BackColor;
            if (diaColor.ShowDialog(this) == DialogResult.OK)
            {
                //当前设置颜色设置为对话框的颜色
                ModifyStyle.BackColor = diaColor.Color;
                //数据体现到界面控件
                BackLabel.BackColor = ModifyStyle.BackColor;
                //刷新预览图
                RefreshGraph(ModifyStyle);
            }
        }

        //边框色设置对话框响应
        private void FrameButton_Click(object sender, EventArgs e)
        {
            //设置对话框颜色为当前设置的颜色
            diaColor.Color = ModifyStyle.FrameColor;
            if (diaColor.ShowDialog(this) == DialogResult.OK)
            {
                //当前设置颜色设置为对话框的颜色
                ModifyStyle.FrameColor = diaColor.Color;
                //数据体现到界面控件
                FrameLabel.BackColor = ModifyStyle.FrameColor;
                //刷新预览图
                RefreshGraph(ModifyStyle);
            }
        }

        //高亮前景色设置对话框响应
        private void HLForeButton_Click(object sender, EventArgs e)
        {
            //设置对话框颜色为当前设置的颜色
            diaColor.Color = ModifyStyle.HLForeColor;
            if (diaColor.ShowDialog(this) == DialogResult.OK)
            {
                //当前设置颜色设置为对话框的颜色
                ModifyStyle.HLForeColor = diaColor.Color;
                //数据体现到界面控件
                HLForeLabel.BackColor = ModifyStyle.HLForeColor;
                //刷新预览图
                RefreshGraph(ModifyStyle);
            }
        }

        //高亮背景色设置对话框响应
        private void HLBackButton_Click(object sender, EventArgs e)
        {
            //设置对话框颜色为当前设置的颜色
            diaColor.Color = ModifyStyle.HLBackColor;
            if (diaColor.ShowDialog(this) == DialogResult.OK)
            {
                //当前设置颜色设置为对话框的颜色
                ModifyStyle.HLBackColor = diaColor.Color;
                //数据体现到界面控件
                HLBackLabel.BackColor = ModifyStyle.HLBackColor;
                //刷新预览图
                RefreshGraph(ModifyStyle);
            }
        }

        //高亮边框色设置对话框响应
        private void HLFrameButton_Click(object sender, EventArgs e)
        {
            //设置对话框颜色为当前设置的颜色
            diaColor.Color = ModifyStyle.HLFrameColor;
            if (diaColor.ShowDialog(this) == DialogResult.OK)
            {
                //当前设置颜色设置为对话框的颜色
                ModifyStyle.HLFrameColor = diaColor.Color;
                //数据体现到界面控件
                HLFrameLabel.BackColor = ModifyStyle.HLFrameColor;
                //刷新预览图
                RefreshGraph(ModifyStyle);
            }
        }

        //抗锯齿组合框选项修改响应
        private void SmoothBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ModifyStyle == null)
            {
                return;
            }
            //获取用户设置
            ModifyStyle.SmoothMode = (SmoothingMode)SmoothBox.SelectedIndex;
            RefreshGraph(ModifyStyle);
        }

        //预设样式集列表选项修改响应
        private void StyleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StyleList.SelectedIndex < 0)
            {
                return;
            }
            //设置选中预设样式集为当前暂存样式集
            ModifyStyle = Preset[StyleList.SelectedIndex];
            //回填数据到窗体控件
            FillContent(ModifyStyle);
            //刷新预览图
            RefreshGraph(ModifyStyle);
        }

        private void DiaOption_Load(object sender, EventArgs e)
        {

        }
    }
}
