using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;

namespace CNSP.Core
{
    public class Node//复杂网络节点类：负责存储单一网络节点的信息，并向上层类提供功能接口函数
    {
        //成员变量
        protected int intNum;                           //节点编号
        protected int intDegree;                        //节点度
        public Dictionary<int, Edge> Links;       //连边 使用字典结构存放（目标节点号，连边对象）
        protected Point potLoc;                        //节点位置
        //属性///////////////////////////////
        public int Number
        {
            get
            {
                return intNum;
            }
        }
        public int Degree
        {
            get
            {
                return intDegree;
            }
        }
        public Point Location
        {
            get
            {
                return potLoc;
            }
            set
            {
                potLoc = value;
            }
        }

        //方法///////////////////////////////
        /*
         * Function: Node
         * Description:复杂网络节点类Node构造函数
         * Parameters:
         *      int iNum 节点编号
         * Return Value: Node
         */
        public Node (int iNum)    //构造函数
        {
            this.intNum = iNum;
            this.intDegree = 0;
            this.potLoc = new Point(0,0);
            Links=new Dictionary<int,Edge >();
        }
        /*
         * Function: AddEdge
         * Description:增加连边
         * Parameters:
         *      int iTarget 连边终止节点编号
         *      int iValue 连边权重
         * Return Value:bool
         */
        public bool AddEdge(int iTarget, double dValue)
        {
            if (iTarget != intNum)//检测条件：当前节点与目标节点不相连，且目标节点不是当前节点
            {
                if (Links.ContainsKey(iTarget) == false)
                {
                    intDegree++;
                    Links.Add(iTarget, new Edge(intNum, iTarget, dValue));   //向Links中加入新项目  
                }
                else
                {
                    Links[iTarget].Value++;
                }
                return true; 
            }
            return false;
        }
        /*
         * Function: DecEdge
         * Description:去除连边
         * Parameters:
         *      int iTarget 连边终止节点编号
         * Return Value:bool
         */
        public bool DecEdge(int iTarget)//去除连边
        {
            if (Links.ContainsKey(iTarget) == true)     //确保当前节点确实含有需去除的边
            {
                Links.Remove(iTarget);
                intDegree--;
                return true;
            }
            return false;
        }
        /*
         * Function: ClearEdge
         * Description:去除所有连边
         * Parameters:
         * Return Value:
         */
        public void ClearEdge()
        {
            if (intDegree > 0)      //只要有边就全部去除
            {
                Links.Clear();
            }
        }
        /*
         * Function: ValueOfEdge
         * Description:返回目标节点之间的连边权重
         * Parameters:
         *      int iTarget 节点编号
         * Return Value:int
         */
        public double ValueOfEdge(int iTarget)
        {
            int iRet = 0;
            if (Links.ContainsKey(iTarget))
            {
                return Links[iTarget].Value;
            }
            return iRet;
        }
        /*
         * Function: ContainsEdge
         * Description:返回是否包含和目标节点间的连边
         * Parameters:
         *      int iTarget 节点编号
         * Return Value:bool
         */
        public bool ContainsEdge(int iTarget)
        {
            if (Links.ContainsKey(iTarget))
            {
                return true;
            }
            return false;
        }
        /*
         * Function: GetEnumerator
         * Description:遍历器获取函数
         * Parameters:
         * Return Value:NodeEnumerator
         */
        public NodeEnumerator GetEnumerator()
        {
            return new NodeEnumerator(this);
        }

    }

    public class NodeEnumerator : IEnumerator   //节点遍历器类，实现使用foreach遍历节点中连边
    {
        private int index;                  //当前位置索引
        private Node curNode;         //当前节点
        /*
         * Function: Reset
         * Description:实现IEnumerator接口的Reset方法，将集合索引置于第一个元素之前
         * Parameters:
         * Return Value:
         */
        public NodeEnumerator(Node node)
        {
            curNode = node;
            index = -1;
        }

        public object Current
        {
            get
            {
                return curNode.Links.ElementAt(index).Value;
            }
        }
        /*
         * Function: Reset
         * Description:实现IEnumerator接口的Reset方法，将集合索引置于第一个元素之前
         * Parameters:
         * Return Value:
         */
        public void Reset()
        {
            index = -1;
        }
        /*
         * Function: MoveNext
         * Description:复杂网络连边类Edge构造函数
         * Parameters:实现IEnumerator接口的MoveNext方法，用于向前访问集合元素，如果超出集合范围，返回false
         * Return Value:bool
         */
        public bool MoveNext()
        {
            index++;
            if (index >= curNode.Degree)
            {
                index = -1;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
