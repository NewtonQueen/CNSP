using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNSP.Core;

namespace CNSP.Platform.Parameter
{
    class DistanceStrategy//距离参数计算策略类
    {
        private int[,] intDistance;              //节点对之间的最短路径长度
        private double dubAveDistance;          //网络节点间平均距离
        private int intDiameter;                //网络直径

        public int[,] Distance
        {
            get
            {
                return intDistance;
            }
        }
        public double AveDistance
        {
            get
            {
                return dubAveDistance;
            }
        }
        public int Diameter
        {
            get
            {
                return intDiameter;
            }
        }

        public DistanceStrategy(int iNum)
        {
            intDistance = new int[iNum, iNum];
            dubAveDistance = 0.0;
            intDiameter = 0;
        }

        //公用调用接口，计算距离相关三个参数
        public void Calculate(pNet curNetwork)
        {
            CalSmallPaths(curNetwork);
            CalAveDistance(curNetwork.Number);
            CalDiameter(curNetwork.Number);
        }

        //计算最短路径
        void CalSmallPaths(pNet curNetwork)
        {
            int i, j;
            for (i = 0; i < curNetwork.intNumber; i++)
            {
                CalPath(i, ref curNetwork);         //以每个节点为起点，向其他点传播信息，获得距离
                for (j = 0; j < curNetwork.intNumber; j++)
                {
                    intDistance[i, j] = curNetwork.Network[j].State;
                    curNetwork.Network[j].State = 0;
                }
            }
        }

        //计算平均距离
        void CalAveDistance(int intNumber)
        {
            int intSum, intCount, i, j;
            intSum = 0;
            intCount = 0;
            for (i = 0; i < intNumber; i++)
            {
                for (j = 0; j < intNumber; j++)
                {
                    if (intDistance[i, j] > 0)
                    {
                        intSum += intDistance[i, j];
                        intCount += 1;
                    }
                }
            }
            dubAveDistance = intSum * 1.0d / intCount;
        }

        //计算网络直径，最长节点间距离
        void CalDiameter(int intNumber)
        {
            int intMax, i, j;
            intMax = 0;
            for (i = 0; i < intNumber; i++)
            {
                for (j = 0; j < intNumber; j++)
                {
                    if (intDistance[i, j] > intMax)
                    {
                        intMax = intDistance[i, j];
                    }
                }
            }
            intDiameter = intMax;
        }

        //广度优先搜索计算路径
        void CalPath(int iSource, ref pNet curNetwork)
        {
            int intLevel = 1, intSource, intMaster, intTarget, intRound;

            foreach (pNode curNode in curNetwork.Network)
            {
                if (curNode.Number != iSource)
                {
                    curNode.State = -1;
                }
            }
            intSource = iSource;
            intMaster = intSource;
            curNetwork.Network[intSource].State = 0;
            foreach (Edge edge in curNetwork.Network[intSource])//对初始节点的第一层外围节点进行初始化
            {
                intTarget = edge.Target;
                curNetwork.Network[intTarget].State = intLevel;
            }
            while (true)//循环向周围节点（未得到信息）传播，直到不再有节点收到数据包
            {
                intRound = 0;
                foreach (pNode curNode in curNetwork.Network)
                {
                    if (curNode.State == intLevel)
                    {
                        intSource = curNode.Number;
                        foreach (Edge edge in curNode)
                        {
                            intTarget = edge.Target;
                            if (curNetwork.Network[intTarget].State == -1 && intTarget != intMaster)
                            {
                                curNetwork.Network[intTarget].State = intLevel + 1;
                                intRound++;
                            }
                        }
                    }
                }
                if (intRound == 0)
                {//本次没有一个新节点被处理，则认为传播完毕
                    break;
                }
                intLevel += 1;
            }
        }
    }
}
