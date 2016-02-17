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
    public class Node//��������ڵ��ࣺ����洢��һ����ڵ����Ϣ�������ϲ����ṩ���ܽӿں���
    {
        //��Ա����
        protected int intNum;                           //�ڵ���
        protected int intDegree;                        //�ڵ��
        public Dictionary<int, Edge> Links;       //���� ʹ���ֵ�ṹ��ţ�Ŀ��ڵ�ţ����߶���
        protected Point potLoc;                        //�ڵ�λ��
        //����///////////////////////////////
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

        //����///////////////////////////////
        /*
         * Function: Node
         * Description:��������ڵ���Node���캯��
         * Parameters:
         *      int iNum �ڵ���
         * Return Value: Node
         */
        public Node (int iNum)    //���캯��
        {
            this.intNum = iNum;
            this.intDegree = 0;
            this.potLoc = new Point(0,0);
            Links=new Dictionary<int,Edge >();
        }
        /*
         * Function: AddEdge
         * Description:��������
         * Parameters:
         *      int iTarget ������ֹ�ڵ���
         *      int iValue ����Ȩ��
         * Return Value:bool
         */
        public bool AddEdge(int iTarget, double dValue)
        {
            if (iTarget != intNum)//�����������ǰ�ڵ���Ŀ��ڵ㲻��������Ŀ��ڵ㲻�ǵ�ǰ�ڵ�
            {
                if (Links.ContainsKey(iTarget) == false)
                {
                    intDegree++;
                    Links.Add(iTarget, new Edge(intNum, iTarget, dValue));   //��Links�м�������Ŀ  
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
         * Description:ȥ������
         * Parameters:
         *      int iTarget ������ֹ�ڵ���
         * Return Value:bool
         */
        public bool DecEdge(int iTarget)//ȥ������
        {
            if (Links.ContainsKey(iTarget) == true)     //ȷ����ǰ�ڵ�ȷʵ������ȥ���ı�
            {
                Links.Remove(iTarget);
                intDegree--;
                return true;
            }
            return false;
        }
        /*
         * Function: ClearEdge
         * Description:ȥ����������
         * Parameters:
         * Return Value:
         */
        public void ClearEdge()
        {
            if (intDegree > 0)      //ֻҪ�б߾�ȫ��ȥ��
            {
                Links.Clear();
            }
        }
        /*
         * Function: ValueOfEdge
         * Description:����Ŀ��ڵ�֮�������Ȩ��
         * Parameters:
         *      int iTarget �ڵ���
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
         * Description:�����Ƿ������Ŀ��ڵ�������
         * Parameters:
         *      int iTarget �ڵ���
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
         * Description:��������ȡ����
         * Parameters:
         * Return Value:NodeEnumerator
         */
        public NodeEnumerator GetEnumerator()
        {
            return new NodeEnumerator(this);
        }

    }

    public class NodeEnumerator : IEnumerator   //�ڵ�������࣬ʵ��ʹ��foreach�����ڵ�������
    {
        private int index;                  //��ǰλ������
        private Node curNode;         //��ǰ�ڵ�
        /*
         * Function: Reset
         * Description:ʵ��IEnumerator�ӿڵ�Reset�������������������ڵ�һ��Ԫ��֮ǰ
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
         * Description:ʵ��IEnumerator�ӿڵ�Reset�������������������ڵ�һ��Ԫ��֮ǰ
         * Parameters:
         * Return Value:
         */
        public void Reset()
        {
            index = -1;
        }
        /*
         * Function: MoveNext
         * Description:��������������Edge���캯��
         * Parameters:ʵ��IEnumerator�ӿڵ�MoveNext������������ǰ���ʼ���Ԫ�أ�����������Ϸ�Χ������false
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
