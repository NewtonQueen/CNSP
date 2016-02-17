using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CNSP.Core
{
    public class Edge//复杂网络连边类：负责存储网络连边信息
    {
        private int intSource;//连边起点
        private double dubValue;//连边权重
        private int intTarget;//连边终点
        //属性//////////////////////////
        public int Source
        {
            get
            {
                return intSource;
            }
            set
            {
                intSource =value; 
            }
        }
        public double Value
        {
            get
            {
                return dubValue;
            }
            set
            {
                dubValue = value;
            }
        }
        public int Target
        {
            get
            {
                return intTarget;
            }
            set
            {
                intTarget = value;
            }
        }
        //方法/////////////////////////
        /*
         * Function: Edge
         * Description:复杂网络连边类Edge构造函数
         * Parameters:
         *      int iSource 连边起始节点编号
         *      int iTarget 连边终止节点编号
         *      int iValue 连边权重
         * Return Value:Edge
         */
        public Edge(int iSource , int iTarget, double dValue)//构造函数 对三个变量进行赋值
        {
            this.intSource = iSource;
            this.intTarget = iTarget;
            this.dubValue = dValue;
        }
        /*
         * Function: XMLItem
         * Description:XML连边节点数据生成函数
         * Parameters:
         *      XmlDocument doc 待写入XML文档对象
         * Return Value: XmlElement
         */
        public XmlElement XMLItem(ref XmlDocument doc)
        {
            XmlElement curEdge = doc.CreateElement("Edge");         //创建连边元素
            XmlText Valuetxt;

            curEdge.SetAttribute("Target", (intTarget).ToString());   //创建属性元素，值为目标节点
            Valuetxt = doc.CreateTextNode(dubValue.ToString());     //创建文本元素，值为连编权重
            curEdge.AppendChild(Valuetxt);                                  //属性和文本元素加入当前连边元素

            return curEdge;
        }
    }
}
