using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;
using CNSP.Core;


namespace CNSP.Platform.Paint
{
    public class dNode
    {
         //成员变量
        Node node;
        private Point potOffset;                        //绘图偏移
        //属性///////////////////////////////
        public int Number
        {
            get
            {
                return this.node.Number;
            }
        }
        public int Degree
        {
            get
            {
                return this.node.Degree;
            }
        }
        public Point Location
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
        public Point Offset
        {
            get
            {
                return potOffset;
            }
            set
            {
                potOffset = value;
            }
        }

        //方法///////////////////////////////
        public dNode(int iNum)    //构造函数：新建
        {
            this.node = new Node(iNum);
        }

        //从xml数据中生成节点
        public dNode(XmlElement xNode)
        {
            XmlNode x_xml, y_xml, edges_xml;
            Node newNode;
            int x, y, intNum, tar;
            double value;

            intNum = Convert.ToInt32(xNode.Attributes.GetNamedItem("num").Value);
            newNode = new Node(intNum);                                            //新建节点
            x_xml = y_xml = edges_xml = null;
            foreach (XmlNode curNode in xNode.ChildNodes)       //节点位置设置
            {
                if (curNode.Name == "Xpos")//节点位置
                {
                    x_xml = curNode;
                }
                if (curNode.Name == "Ypos")
                {
                    y_xml = curNode;
                }
                if (curNode.Name == "Edges")//获取连边列表
                {
                    edges_xml = curNode;
                }
            }
            if (x_xml == null || y_xml == null || edges_xml == null)
            {
                return;
            }
            x = Convert.ToInt32(x_xml.InnerText);
            y = Convert.ToInt32(y_xml.InnerText);
            newNode.Location = new Point(x, y);

            foreach (XmlNode edge in edges_xml.ChildNodes)                                     //遍历连边列表
            {
                tar = Convert.ToInt32(edge.Attributes.GetNamedItem("Target").Value);//读出目标节点
                value = Convert.ToDouble(edge.InnerText);                           //读出连边权重
                newNode.AddEdge(tar, value);                                        //加入连边
            }
            this.node = newNode;
        }

        //获取指定连边权重
        public double GetWeight(int iTarget)
        {
            if (node.ContainsEdge(iTarget) == true)
            {
                return node.Links[iTarget].Value;
            }
            return 0;
        }

        //检查是否包含和某个节点间连边
        public bool Contains(int iTarget)
        {
            return this.node.ContainsEdge(iTarget);
        }

        //返回枚举器，foreach语句使用
        public NodeEnumerator GetEnumerator()
        {
            return this.node.GetEnumerator();
        }

    }
}
