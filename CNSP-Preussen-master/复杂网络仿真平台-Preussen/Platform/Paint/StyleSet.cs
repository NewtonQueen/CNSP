using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;
using System.Drawing.Drawing2D; 

namespace CNSP.Platform.Paint
{
    public class StyleSet//��ʽ��������û��趨�ı������ڵ���״����ɫ���ַ���
    {
        protected string strName;
        protected Color colFore;                      //��ʾ���� �ַ���ɫ
        protected Color colBack;                     //��ʾ���� ������ɫ
        protected Color colFrame;                   //��ʾ���� �߿���ɫ

        protected Color colHLFore;                  //��ʾ���� �����ַ���ɫ
        protected Color colHLBack;                 //��ʾ���� ����������ɫ
        protected Color colHLFrame;              //��ʾ���� �����߿���ɫ

        protected sharp NodeSharp;               //��ʾ���� �ڵ���״
        protected SmoothingMode sMode;    //��ʾ���� �����ģʽ
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
        //����///////////////////////////////
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
        
        //����///////////////////////////////
        //���캯����Ĭ�Ϲ���һ����ʽ
        public StyleSet()
        {
            this.Name = "Ĭ����ʽ";
            this.colFore = Color.Blue;                          //0,0,255
            this.colBack = Color.Green;                     //0,128,0
            this.colFrame = Color.DarkBlue;                 //0,0,139
            this.colHLFore = Color.Blue;                    //0,0,255
            this.colHLBack = Color.Lime;                    //0,255,0
            this.colHLFrame = Color.DarkBlue;           //0,0,139
            this.NodeSharp  = sharp.Round;
            this.sMode = SmoothingMode.AntiAlias;   //0-none,1-anti,2-High Quality
            this.cFont = SystemFonts.DefaultFont;       //
            this.strDescription = "�û���ʽ";
        }
        
        //���캯������һ��������ʽ������
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

        //���캯������xml�ڵ�������ʽ
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

        //16�����ַ���װ��Ϊ��ɫ����
        Color StringToColor(string sColor)
        {
            int intRGB;
            int intRed, intGreen, intBlue;

            //16�����ַ���ת10��������
            intRGB = Convert.ToInt32(sColor, 16);
            //��ɫΪ23-16λ
            intRed = (intRGB & 0x00FF0000) >> 16;
            //��ɫΪ15-8λ
            intGreen = (intRGB & 0x0000FF00) >> 8;
            //��ɫΪ7-0λ
            intBlue = intRGB & 0x000000FF;
            //����һ���µ�RGB����ע���ʱ͸����AĬ��Ϊ255����͸����
            return Color.FromArgb(intRed, intGreen, intBlue);
        }

        //����Equals�������ж�������ʽ���Ƿ�һ��
        public override bool Equals(object obj)
        {
            //�ж���֮�Ƚϵ������Ƿ�Ϊnull������������ɵݹ�����
            if (obj == null)
            {
                return false;
            }
            //�����Ƿ�һ��
            if (GetType() != obj.GetType())
            {
                return false;
            }
            //����
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
