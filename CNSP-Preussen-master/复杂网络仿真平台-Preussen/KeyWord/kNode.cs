using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNSP.Core;
using CNSP.Platform;
using System.Drawing;
using System.Drawing.Drawing2D; 
using System.Xml;

namespace CNSP.KeyWord
{
    public class kNode:IfPlatform, IfKeyWord
    {
        //成员变量
        public Node node;            //节点成员
        string strWord;                 //词语
        string strType;                  //词性
        int intPosition;                 //句中位置
        int intLine;                       //句子编号
        //属性
        int IfKeyWord.Number
        {
            get
            {
                return this.node.Number;
            }
        }
        string IfKeyWord.Word
        {
            get
            {
                return strWord;
            }
        }
        string IfKeyWord.Type
        {
            get
            {
                return strType;
            }
        }
        int IfKeyWord.Position
        {
            get
            {
                return intPosition;
            }
        }
        int IfKeyWord.Line
        {
            get
            {
                return intLine;
            }
        }
        int IfPlatform.Number
        {
            get
            {
                return this.node.Number;
            }
        }
        int IfPlatform.Degree
        {
            get
            {
                return this.node.Degree;
            }
        }
        Point IfPlatform.Location
        {
            get
            {
                return this.node.Location;
            }
            set
            {
                this.node.Location = value;
            }
        }

        //方法///////////////////////////////
        public kNode(int iNum)    //构造函数：新建
        {
            this.node = new Node(iNum);
        }

        public kNode(int iNum, WordResult word)    //构造函数：新建
        {
            this.node = new Node(iNum);
            this.strWord = word.Word;
            this.strType = word.Type;
            this.intLine = word.Line;
            this.intPosition = word.Position;
        }
        //增加连边
        bool IfPlatform.AddEdge(int iTarget, double dValue)
        {
            return this.node.AddEdge(iTarget, dValue);
        }
        //去除连边
        bool IfPlatform.DecEdge(int iTarget)
        {
            return this.node.DecEdge(iTarget);
        }

        //获取指定连边权重
        double IfPlatform.GetWeight(int iTarget)
        {
            if (node.ContainsEdge(iTarget) == true)
            {
                return node.Links[iTarget].Value;
            }
            return 0;
        }

        //检查是否包含对某个节点的连边
        bool IfPlatform.Contains(int iTarget)
        {
            return this.node.ContainsEdge(iTarget);
        }
        //枚举器foreach语句使用
        NodeEnumerator IfPlatform.GetEnumerator()
        {
            return this.node.GetEnumerator();
        }
        //将xml数据转化为节点
        void IfPlatform.XMLinput(XmlElement xNode, int intNumOffset)
        {
            XmlNode degree_xml, x_xml, y_xml, word_xml, type_xml, line_xml, pos_xml, edges_xml;
            Node newNode;
            int intNum, x, y, tar;
            double value;

            intNum = Convert.ToInt32(xNode.Attributes.GetNamedItem("num").Value) - intNumOffset;
            newNode = new Node(intNum);                                            //新建节点

            degree_xml = x_xml = y_xml = edges_xml = null;
            word_xml = type_xml = line_xml = pos_xml = null;
            foreach (XmlNode curNode in xNode.ChildNodes)       //节点位置设置
            {
                if (curNode.Name == "Degree")//节点度
                {
                    degree_xml = curNode;
                }
                if (curNode.Name == "Xpos")//节点位置
                {
                    x_xml = curNode;
                }
                if (curNode.Name == "Ypos")
                {
                    y_xml = curNode;
                }
                if (curNode.Name == "Word")//词语内容
                {
                    word_xml = curNode;
                }
                if (curNode.Name == "Type")//词性
                {
                    type_xml = curNode;
                }
                if (curNode.Name == "Line")//所属语句
                {
                    line_xml = curNode;
                }
                if (curNode.Name == "Position")//所在位置
                {
                    pos_xml = curNode;
                }
                if (curNode.Name == "Edges")//获取连边列表
                {
                    edges_xml = curNode;
                }
            }
            if (x_xml == null || y_xml == null || edges_xml == null || word_xml == null || type_xml == null || line_xml == null || pos_xml == null)
            {
                return;
            }
            x = Convert.ToInt32(x_xml.InnerText);
            y = Convert.ToInt32(y_xml.InnerText);
            newNode.Location = new Point(x, y);
            this.strWord = word_xml.InnerText;
            this.strType = type_xml.InnerText;
            this.intLine = Convert.ToInt32(line_xml.InnerText);
            this.intPosition = Convert.ToInt32(pos_xml.InnerText);

            foreach (XmlNode edge in edges_xml.ChildNodes)                                     //遍历连边列表
            {
                tar = Convert.ToInt32(edge.Attributes.GetNamedItem("Target").Value) - intNumOffset;//读出目标节点
                value = Convert.ToDouble(edge.InnerText);                           //读出连边权重
                newNode.AddEdge(tar, value);                                        //加入连边
            }
            this.node = newNode;
        }

        //将节点数据输出为XML格式
        XmlElement IfPlatform.XMLoutput(ref XmlDocument doc)
        {
            XmlElement curNode = doc.CreateElement("Node");
            XmlElement degree_xml, x_xml, y_xml, word_xml,type_xml,line_xml, pos_xml, edges_xml;
            XmlText deg_txt, x_txt, y_txt,word_txt, type_txt, line_txt, pos_txt;

            curNode.SetAttribute("num", this.node.Number.ToString());                   //创建各属性的Tag元素
            degree_xml = doc.CreateElement("Degree");
            x_xml = doc.CreateElement("Xpos");
            y_xml = doc.CreateElement("Ypos");
            word_xml = doc.CreateElement("Word");
            type_xml = doc.CreateElement("Type");
            line_xml = doc.CreateElement("Line");
            pos_xml = doc.CreateElement("Position");
            edges_xml = doc.CreateElement("Edges");

            deg_txt = doc.CreateTextNode(this.node.Degree.ToString());               //创建各属性的文本元素
            x_txt = doc.CreateTextNode(this.node.Location.X.ToString());
            y_txt = doc.CreateTextNode(this.node.Location.Y.ToString());
            word_txt = doc.CreateTextNode(this.strWord);
            type_txt = doc.CreateTextNode(this.strType);
            line_txt = doc.CreateTextNode(this.intLine.ToString());
            pos_txt = doc.CreateTextNode(this.intPosition.ToString());

            degree_xml.AppendChild(deg_txt);                                    //将标题元素赋予文本内容
            x_xml.AppendChild(x_txt);
            y_xml.AppendChild(y_txt);
            word_xml.AppendChild(word_txt);
            type_xml.AppendChild(type_txt);
            line_xml.AppendChild(line_txt);
            pos_xml.AppendChild(pos_txt);

            curNode.AppendChild(degree_xml);                                   //向当前节点中加入各属性节点
            curNode.AppendChild(x_xml);
            curNode.AppendChild(y_xml);
            curNode.AppendChild(word_xml);
            curNode.AppendChild(type_xml);
            curNode.AppendChild(line_xml);
            curNode.AppendChild(pos_xml);

            foreach (Edge edge in this.node)                    //遍历，加入连边节点
            {
                edges_xml.AppendChild(edge.XMLItem(ref doc));
            }
            curNode.AppendChild(edges_xml);
            return curNode;
        }
    
    }
}
