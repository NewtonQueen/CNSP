using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using CNSP.Core;

namespace CNSP.Platform.Parameter
{
    public class pNet//参数计算专用网络
    {
        public List<pNode> Network; //网络节点集合
        public int intNumber;           //节点总数
        public int intEdge;               //连边总数
        string strType;			//网络类型(有向 无向)
        //属性
        public int Number
        {
            get
            {
                return this.intNumber;
            }
        }
        public int Edge
        {
            get
            {
                return this.intEdge;
            }
        }
        public string Type
        {
            get
            {
                return strType;
            }
        }
        //方法
        //将xml文件转化为网络
        public pNet(XmlDocument doc)
        {
            XmlNodeList Nodelist;
            XmlNode xmlroot;

            this.Network = new List<pNode>();
            xmlroot = doc.ChildNodes.Item(0);
            Nodelist = xmlroot.ChildNodes;                                             //获取节点列表
            this.intNumber = 0;
            foreach (XmlElement curNode in Nodelist)                                      //遍历节点列表
            {
                this.Network.Add(new pNode(curNode));                          //调用下层函数，生成新节点
                this.intNumber++;
            }
            Initialized();
        }

        //网络初始化，在加入所有节点之后执行一次
        public void Initialized()
        {
            NetworkType();//网络类型分析
            DegreeStat();//节点度统计
        }

        //网络类型分析函数，确定网络是否有向
        private void NetworkType()
        {
            int i, intTarget, intSource;
            for (i = 0; i < intNumber; i++)
            {
                foreach (Edge edge in Network[i])
                {
                    intTarget = edge.Target;
                    intSource = i;
                    if (Network[intTarget].Contains(intSource) == false)
                    {
                        strType = "有向图";
                        return;
                    }
                }
            }
            strType = "无向图";
            return;
        }

        //节点度统计函数，最大度，最小度，度列表
        private void DegreeStat()
        {
            int intTotal;

            intTotal = 0;
            //找出统计连边数
            foreach(pNode sNode in this.Network)
            {
                intTotal += sNode.Degree;
            }

            if (strType == "有向图")
            {
                intEdge = intTotal;
            }
            else
            {
                intEdge = intTotal / 2;
            }
        }

        //去除连边，提供两端点编号
        public void DecEdge(int iNum, int iTarget)
        {
            if (strType == "有向图")
            {
                Network[iNum].DecEdge(iTarget);
            }
            else
            {
                Network[iNum].DecEdge(iTarget);
                Network[iTarget].DecEdge(iNum);
            }
            intEdge -= 1;
        }

    }
}
