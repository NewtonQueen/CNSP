using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;
using System.Drawing.Drawing2D; 

namespace CNSP.Platform.Paint
{
    public class StyleSet//样式集，存放用户设定的变量（节点形状，颜色，字符）
    {
        protected string strName;
        protected Color colFore;                      //显示变量 字符颜色
        protected Color colBack;                     //显示变量 背景颜色
        protected Color colFrame;                   //显示变量 边框颜色

        protected Color colHLFore;                  //显示变量 高亮字符颜色
        protected Color colHLBack;                 //显示变量 高亮背景颜色
        protected Color colHLFrame;              //显示变量 高亮边框颜色

        protected sharp NodeSharp;               //显示变量 节点形状
        protected SmoothingMode sMode;    //显示变量 抗锯齿模式
        protected Font cFont;
        protected string strDescription;
        
        public enum sharp
        {
            Round = 1,
            Triangle,
            Diamond,
            Square,
            Star_5,
            Star_6,
        }
        //属性///////////////////////////////
        public string Name
        {
            get
            {
                return strName;
            }
            set
            {
                strName = value;
            }
        }
        public Color ForeColor
        {
            get
            {
                return colFore;
            }
            set
            {
                colFore = value;
            }
        }
        public Color BackColor
        {
            get
            {
                return colBack;
            }
            set
            {
                colBack = value;
            }
        }
        public Color FrameColor
        {
            get
            {
                return colFrame;
            }
            set
            {
                colFrame = value;
            }
        }
        public Color HLForeColor
        {
            get
            {
                return colHLFore;
            }
            set
            {
                colHLFore = value;
            }
        }
        public Color HLBackColor
        {
            get
            {
                return colHLBack;
            }
            set
            {
                colHLBack = value;
            }
        }
        public Color HLFrameColor
        {
            get
            {
                return colHLFrame;
            }
            set
            {
                colHLFrame = value;
            }
        }
        public sharp Sharp
        {
            get
            {
                return NodeSharp;
            }
            set
            {
                NodeSharp = value;
            }
        }
        public SmoothingMode SmoothMode
        {
            get
            {
                return sMode;
            }
            set
            {
                sMode = value;
            }
        }
        public Font charFont
        {
            get
            {
                return cFont;
            }
            set
            {
                cFont = value;
            }
        }
        public string Description
        {
            get
            {
                return strDescription;
            }
            set
            {
                strDescription = value;
            }
        }
        
        //方法///////////////////////////////
        //构造函数，默认构造一个样式
        public StyleSet()
        {
            this.Name = "默认样式";
            this.colFore = Color.Blue;                          //0,0,255
            this.colBack = Color.Green;                     //0,128,0
            this.colFrame = Color.DarkBlue;                 //0,0,139
            this.colHLFore = Color.Blue;                    //0,0,255
            this.colHLBack = Color.Lime;                    //0,255,0
            this.colHLFrame = Color.DarkBlue;           //0,0,139
            this.NodeSharp  = sharp.Round;
            this.sMode = SmoothingMode.AntiAlias;   //0-none,1-anti,2-High Quality
            this.cFont = SystemFonts.DefaultFont;       //
            this.strDescription = "用户样式";
        }
        
        //构造函数，从一个已有样式集生成
        public StyleSet(StyleSet Original)
        {
            this.Name = this.Name;
            this.colFore = Original.ForeColor;
            this.colBack = Original.BackColor;
            this.colFrame = Original.FrameColor;
            this.colHLFore = Original.HLForeColor;
            this.colHLBack = Original.HLBackColor;
            this.colHLFrame = Original.HLFrameColor;
            this.NodeSharp = Original.NodeSharp;
            this.sMode = Original.sMode;
            this.cFont = Original.cFont;
            this.Description = Original.Description;
        }

        //构造函数，从xml节点生成样式
        public StyleSet(XmlElement xNode)
        {
            string strFont;
            int intSize;

            this.Name = xNode.ChildNodes.Item(1).InnerText;
            this.colFore = StringToColor(xNode.ChildNodes.Item(3).InnerText);
            this.colBack = StringToColor(xNode.ChildNodes.Item(4).InnerText);
            this.colFrame = StringToColor(xNode.ChildNodes.Item(5).InnerText);
            this.colHLFore = StringToColor(xNode.ChildNodes.Item(6).InnerText);
            this.colHLBack = StringToColor(xNode.ChildNodes.Item(7).InnerText);
            this.colHLFrame = StringToColor(xNode.ChildNodes.Item(8).InnerText);
            this.NodeSharp = (sharp)Convert.ToInt32(xNode.ChildNodes.Item(9).InnerText);
            this.sMode = (SmoothingMode)Convert.ToInt32(xNode.ChildNodes.Item(10).InnerText);
            strFont = xNode.ChildNodes.Item(11).InnerText;
            intSize = Convert.ToInt32(xNode.ChildNodes.Item(12).InnerText);
            this.cFont = new Font(strFont,intSize);
            this.Description = xNode.ChildNodes.Item(13).InnerText;
        }

        //16进制字符串装化为颜色对象
        Color StringToColor(string sColor)
        {
            int intRGB;
            int intRed, intGreen, intBlue;

            //16进制字符串转10进制整型
            intRGB = Convert.ToInt32(sColor, 16);
            //红色为23-16位
            intRed = (intRGB & 0x00FF0000) >> 16;
            //绿色为15-8位
            intGreen = (intRGB & 0x0000FF00) >> 8;
            //蓝色为7-0位
            intBlue = intRGB & 0x000000FF;
            //返回一个新的RGB对象，注意此时透明度A默认为255，不透明。
            return Color.FromArgb(intRed, intGreen, intBlue);
        }

        //重载Equals函数，判断两个样式集是否一样
        public override bool Equals(object obj)
        {
            //判断与之比较的类型是否为null。这样不会造成递归的情况
            if (obj == null)
            {
                return false;
            }
            //类型是否一致
            if (GetType() != obj.GetType())
            {
                return false;
            }
            //拆箱
            StyleSet Traget = (StyleSet)obj;

            if (this.colFore != Traget.colFore)
            {
                return false;
            }
            if (this.colBack != Traget.colBack)
            {
                return false;
            }
            if (this.colFrame != Traget.colFrame)
            {
                return false;
            }
            if (this.HLForeColor != Traget.HLForeColor)
            {
                return false;
            }
            if (this.HLBackColor != Traget.HLBackColor)
            {
                return false;
            }
            if (this.HLFrameColor != Traget.HLFrameColor)
            {
                return false;
            }
            if (this.Sharp != Traget.Sharp)
            {
                return false;
            }
            if (this.SmoothMode != Traget.SmoothMode)
            {
                return false;
            }
            if (this.charFont.Name != Traget.charFont.Name)
            {
                return false;
            }
            if (this.charFont.Size != Traget.charFont.Size)
            {
                return false;
            }
            return true;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }


    public class StyleUpdateEventArgs : EventArgs
    {
        StyleSet curStyle;

        public StyleSet NewStyleSet
        {
            get
            {
                return curStyle;
            }
        }

        public StyleUpdateEventArgs(StyleSet NewStyleSet)
        {
            curStyle = NewStyleSet;
        }
    }
}
