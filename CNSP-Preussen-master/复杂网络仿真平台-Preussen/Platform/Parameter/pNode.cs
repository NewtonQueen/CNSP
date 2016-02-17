using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using CNSP.Core;

namespace CNSP.Platform.Parameter
{
    public class pNode//参数计算用节点，去除绘图功能，只包含xml读入功能
    {
        //成员变量
        Node node;
        public int State;

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

        //方法///////////////////////////////
        public pNode(int iNum)    //构造函数：新建
        {
            this.node = new Node(iNum);
        }

        //从xml数据中生成节点
        public pNode(XmlElement xNode)
        {
            XmlNode edges_xml;
            Node newNode;
            int intNum, tar;
            double value;

            intNum = Convert.ToInt32(xNode.Attributes.GetNamedItem("num").Value);
            newNode = new Node(intNum);                                            //新建节点
            edges_xml = null;
            foreach (XmlNode curNode in xNode.ChildNodes)       //节点位置设置
            {
                if (curNode.Name == "Edges")//获取连边列表
                {
                    edges_xml = curNode;
                }
            }
            if (edges_xml == null)
            {
                return;
            }
            foreach (XmlNode edge in edges_xml.ChildNodes)                                     //遍历连边列表
            {
                tar = Convert.ToInt32(edge.Attributes.GetNamedItem("Target").Value);//读出目标节点
                value = Convert.ToDouble(edge.InnerText);                           //读出连边权重
                newNode.AddEdge(tar, value);                                        //加入连边
            }
            this.node = newNode;
        }

        //增加连边
        public bool AddEdge(int iTarget, double dValue)
        {
            return this.node.AddEdge(iTarget, dValue);
        }

        //删除连边
        public bool DecEdge(int iTarget)
        {
            return this.node.DecEdge(iTarget);
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
