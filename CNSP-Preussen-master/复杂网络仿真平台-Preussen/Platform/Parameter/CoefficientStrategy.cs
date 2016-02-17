using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNSP.Core;

namespace CNSP.Platform.Parameter
{
    class CoefficientStrategy//各种中心度系数计算算法类
    {
        public double[] dubCluster;             //所有节点聚类系数
        public double[] dubLoop;                //所有节点环路系数
        public double[] dubClose;               //所有节点接近中心度
        public double AveCluster;               //网络平均聚类系数
        public double AveLoop;                  //网络平均环路系数
        public double AveClose;                 //网络平均接近中心度

        public CoefficientStrategy(int iNum)
        {
            dubCluster = new double[iNum];
            dubLoop = new double[iNum];
            dubClose = new double[iNum];
        }

        //公用调用接口，计算聚类相关三个参数
        public void Calculate(pNet curNetwork)
        {
            CalCluster(curNetwork);
            CalLoop(curNetwork);
            CalClose(curNetwork);
            CalAverage(curNetwork);
        }
        
        //计算聚类系数
        void CalCluster(pNet curNetwork)
        {
            int intLeft, intRight;
            int intTotal, intSum, intUnit, intRes;
            double sngCluster;

            foreach (pNode curNode in curNetwork.Network)//遍历每个节点
            {
                intSum = 0;
                intTotal = 0;
                foreach (Edge edge1 in curNode)//遍历当前节点的所有邻居
                {
                    intLeft = edge1.Target;
                    intUnit = (int)Math.Ceiling(edge1.Value);
                    foreach (Edge edge2 in curNode)//遍历当前节点的所有邻居
                    {
                        intRight = edge2.Target;
                        intUnit += (int)Math.Ceiling(edge2.Value);
                        if (intRight == intLeft)//相等跳过
                        {
                            continue;
                        }
                        intRes = (int)Math.Ceiling(IsFriend(intLeft, intRight, curNetwork.Network));
                        if (intRes == -1)//不相邻则加上当前边的权重
                        {
                            intTotal += intUnit;
                        }
                        else//相邻则加上当前边的权重和返回权重
                        {
                            intUnit += intRes;
                            intTotal += intUnit;
                            intSum += intUnit;
                        }
                    }
                }
                if (intTotal == 0)//防止除零
                {
                    sngCluster = 0.0;
                }
                else
                {
                    sngCluster = intSum * 1.0 / intTotal;
                }
                dubCluster[curNode.Number] = sngCluster;
            }
        }
        
        //如果是二者是邻居，返回他们之间的连边权重，否则返回-1
        double IsFriend(int iSour, int iTar, List<pNode> Network)
        {
            foreach (Edge edge in Network[iSour])
            {
                if (edge.Target == iTar)
                {
                    return edge.Value;
                }
            }
            return -1;
        }
        
        //计算环路系数
        void CalLoop(pNet curNetwork)
        {
            double sngResult = 0.0;
            int intDeg = 0;
            int intDown = 0;
            int intDistance = 0;
            double sngUp = 0;

            foreach(pNode curNode in curNetwork.Network)
            {
                intDeg = curNode.Degree;
                sngUp = 0.0;
                sngResult = 0.0;
                intDown = 1;
                if (intDeg == 0 || intDeg == 1)
                {
                    dubLoop[curNode.Number] = 1.0;
                    continue;
                }
                foreach (Edge edge1 in curNode)
                {
                    foreach (Edge edge2 in curNode)
                    {
                        if (edge1.Target != edge2.Target)
                        {
                            intDistance = CalDistance(edge1.Target, edge2.Target, curNode.Number, curNetwork);
                            if (intDistance == 1)
                            {
                                sngUp += 1.0 / intDistance;
                            }
                            else if (intDistance != -1)
                            {
                                sngUp += 1.0 / intDistance;
                            }
                            else
                            {
                                sngUp += 0;
                            }
                        }
                    }
                }
                intDown = intDeg * (intDeg - 1);
                sngResult = sngUp / intDown;
                dubLoop[curNode.Number] = sngResult;
            }
        }
        
        //节点状态初始化
        void InitState(int iValue, ref pNet curNetwork)
        {
            foreach(pNode curNode in curNetwork.Network)
            {
                curNode.State = iValue;
            }
        }
        
        //信息传播方法，计算两点间距离
        int CalDistance(int iSource, int iTarget, int iMask, pNet curNetwork)
        {
            int intLevel = 0;
            int intTarget = 0, intRound;

            if (iSource == iTarget)
            {
                return 0;
            }
            InitState(-1, ref curNetwork);
            curNetwork.Network[iSource].State = 0;
            foreach (Edge edge in curNetwork.Network[iSource])
            {
                intTarget = edge.Target;
                if (intTarget == iTarget)
                {
                    return 1;
                }
                if (intTarget == iMask)
                {
                    continue;
                }
                curNetwork.Network[intTarget].State = 1;
            }
            intLevel = 1;
            while (true)//循环向周围节点（未得到信息）传播，直到不再有节点收到数据包
            {
                intRound = 0;
                foreach (pNode curNode in curNetwork.Network)
                {
                    if (curNode.State == intLevel)
                    {
                        foreach (Edge edge in curNode)
                        {
                            intTarget = edge.Target;
                            if (curNetwork.Network[intTarget].State == -1 && intTarget != iSource)
                            {
                                curNetwork.Network[intTarget].State = intLevel + 1;
                                intRound++;
                            }
                            if (intTarget == iTarget)
                            {
                                return intLevel;
                            }
                            if (intTarget == iMask)
                            {
                                continue;
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
            return -1;
        }
        
        //计算接近中心度
        void CalClose(pNet curNetwork)
        {
            int[,] intDistance;
            int intCount, intSum;
            DistanceStrategy disStrategy = new DistanceStrategy(curNetwork.Number);
            disStrategy.Calculate(curNetwork);
            intDistance = disStrategy.Distance;
            foreach(pNode sourNode in curNetwork.Network)
            {
                intSum = 0;
                intCount = 0;
                foreach(pNode tarNode in curNetwork.Network)
                {
                    if (intDistance[sourNode.Number,tarNode.Number] > 0)
                    {
                        intCount += 1;
                        intSum += intDistance[sourNode.Number, tarNode.Number];
                    }
                }
                if (intSum == 0)
                {
                    dubClose[sourNode.Number] = 0;
                }
                else
                {
                    dubClose[sourNode.Number] = intCount * 1.0d / intSum;
                }
            }
        }

        //计算平均值
        void CalAverage(pNet curNetwork)
        {
            double totalCluster = 0;               
            double totalLoop = 0;                  
            double totalClose = 0;

            if (curNetwork.intNumber == 0)
            {
                AveCluster = 0;
                AveLoop = 0;
                AveClose = 0;
            }
            for (int i = 0; i < curNetwork.intNumber; i++)
            {
                totalCluster += dubCluster[i];
                totalLoop += dubLoop[i];
                totalClose += dubClose[i];
            }
            AveCluster = totalCluster / (curNetwork.intNumber * 1.0);
            AveLoop = totalLoop / (curNetwork.intNumber * 1.0);
            AveClose = totalClose / (curNetwork.intNumber * 1.0);
        }
    }
}
