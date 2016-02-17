using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;
using CNSP.Platform.Paint;

namespace CNSP.DataBase
{
    public class StyleSetProxy
    {
        const string strTablePath = "Data/System/tabStyleSet.xml";
        DataProxy dbHandler;

        //读取当前用户设定的样式
        public StyleSet ReadCurrent()
        {
            StyleSet CurrentStyle ;
            XmlElement Result;

            //新建数据库读写代理对象
            dbHandler = new DataProxy();
            //获取路径下文件所有数据
            Result = dbHandler.ReadIndexOf(strTablePath, 0);
            if (Result == null)
            {
                return null;
            }
            //从数据生成样式集
            CurrentStyle = new StyleSet(Result);
            return CurrentStyle;
        }

        //读取系统预设样式列表
        public List<StyleSet> ReadPreset()
        {
            DataProxy dbReader;
            List<StyleSet> Preset;
            List<XmlElement> Result;

            //新建数据库读写代理对象
            dbReader = new DataProxy();
            //获取路径下文件所有数据
            Result = dbReader.ReadFromTo(strTablePath, 1);
            if (Result == null)
            {
                return null;
            }
            //从数据生成样式集
            Preset = new List<StyleSet>();
            foreach (XmlElement xNode in Result)
            {
                Preset.Add(new StyleSet(xNode));
            }
            return Preset;
        }

        //保存当前用户设置
        public void SaveCurrent(StyleSet CurrentStyle)
        {
            XmlDocument doc;
            XmlNode xmlroot, xNode;
            //新建数据库读写代理对象
            dbHandler = new DataProxy();
            //读入xml文件
            doc = dbHandler.Read(strTablePath);
            //查找数据根节点标签
            xmlroot = doc.SelectSingleNode("dataroot");
            //指向第0个节点，当前使用样式
            xNode = xmlroot.ChildNodes.Item(0);
            //修改节点数据
            ModifyStyle(ref xNode, CurrentStyle);
            //保存回文件
            dbHandler.Save(strTablePath, doc);
        }

        //修改节点数据
        void ModifyStyle(ref XmlNode xNode, StyleSet CurrentStyle)
        {
            Color cColor;
            String strFont;
            int intSize, intSharp, intMode;

            cColor = CurrentStyle.ForeColor;
            xNode.ChildNodes.Item(3).InnerText = ColorToString(cColor);
            cColor = CurrentStyle.BackColor;
            xNode.ChildNodes.Item(4).InnerText = ColorToString(cColor);
            cColor = CurrentStyle.FrameColor;
            xNode.ChildNodes.Item(5).InnerText = ColorToString(cColor);
            cColor = CurrentStyle.HLForeColor;
            xNode.ChildNodes.Item(6).InnerText = ColorToString(cColor);
            cColor = CurrentStyle.HLBackColor;
            xNode.ChildNodes.Item(7).InnerText = ColorToString(cColor);
            cColor = CurrentStyle.HLFrameColor;
            xNode.ChildNodes.Item(8).InnerText = ColorToString(cColor);
            intSharp = (int)CurrentStyle.Sharp;
            xNode.ChildNodes.Item(9).InnerText = intSharp.ToString();
            intMode = (int)CurrentStyle.SmoothMode;
            xNode.ChildNodes.Item(10).InnerText = intMode.ToString();
            strFont = CurrentStyle.charFont.Name;
            xNode.ChildNodes.Item(11).InnerText = strFont;
            intSize = Convert.ToInt32(CurrentStyle.charFont.Size);
            xNode.ChildNodes.Item(12).InnerText = intSize.ToString();
        }

        //颜色对象转化为字符串
        String ColorToString(Color sColor)
        {
            string strColor;
            //颜色整型转为16进制字符串
            strColor = Convert.ToString(sColor.ToArgb(), 16);
            //去除最高8位（2个字节）的透明度信息
            strColor = strColor.Substring(2);
            return strColor;
        }
    }
}
