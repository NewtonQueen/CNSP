using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Drawing;
using CNSP.Core;

namespace CNSP.Platform.Paint
{
    public class dNet
    {
        public List<dNode> Network; //网络节点集合
        public int intNumber;           //节点总数
        public int intEdge;               //连边总数
        string strType;			//网络类型(有向 无向)
        int intMaxDeg;          //网络最大度
        int intMinDeg;          //网络最小度
        public SortedList<int, int> DegreeList;                //网络度列表
        public SortedList<int, Image> SharedImages;     //网络共享节点图片列表

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
        public int MaxDeg
        {
            get
            {
                return intMaxDeg;
            }
        }
        public int MinDeg
        {
            get
            {
                return intMinDeg;
            }
        }
        //方法
        //将xml文件转化为网络
        public dNet(XmlDocument doc)
        {
            XmlNodeList Nodelist;
            XmlNode xmlroot;

            this.Network = new List<dNode>();
            DegreeList = new SortedList<int, int>();
            SharedImages = new SortedList<int, Image>();
            xmlroot = doc.ChildNodes.Item(0);
            Nodelist = xmlroot.ChildNodes;                                             //获取节点列表
            this.intNumber = 0;
            foreach (XmlElement curNode in Nodelist)                                      //遍历节点列表
            {
                this.Network.Add(new dNode(curNode));                          //调用下层函数，生成新节点
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
            int iMaxDeg, iMinDeg;

            intTotal = 0;
            iMaxDeg = 0;
            iMinDeg = intNumber;
            //找出统计连边数
            foreach(dNode sNode in this.Network)
            {
                intTotal += sNode.Degree;
                if (sNode.Degree > iMaxDeg)
                {
                    iMaxDeg = sNode.Degree;
                }
                if (sNode.Degree < iMinDeg)
                {
                    iMinDeg = sNode.Degree;
                }
                if (DegreeList.ContainsKey(sNode.Degree) == false)
                {
                    DegreeList.Add(sNode.Degree, sNode.Degree);
                }
            }
            intMaxDeg = iMaxDeg;
            intMinDeg = iMinDeg;
            if (strType == "有向图")
            {
                intEdge = intTotal;
            }
            else
            {
                intEdge = intTotal / 2;
            }
        }
    }
}
