using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNSP.Core;

namespace CNSP.Platform.Parameter
{
    class PageRankStrategy//PageRank算法类
    {
        public double[] dubPageRank;
        double[] newPageRank;

        //算法构造函数，初始化结构体
        public PageRankStrategy(int iNum)
        {
            int i;
            dubPageRank = new double[iNum];
            newPageRank = new double[iNum];
            for (i = 0; i < iNum; i++)
            {
                dubPageRank[i] = 1.0;
                newPageRank[i] = 0.0;
            }
        }

        double[] PageRank
        {
            get
            {
                return dubPageRank;
            }
        }
        
        //公开接口函数
        public void Calculate(pNet curNetwork, int iTime)
        {
            int i;
            for (i = 0; i < iTime; i++)
            {
                CalPageRank(curNetwork);
            }
        }

        //PageRank核心算法
        void CalPageRank(pNet curNetwork)
        {
            int i;
            double dubPiece;
            //遍历网络节点
            foreach (pNode curNode in curNetwork.Network)
            {
                if (curNode.Degree == 0)
                {
                    newPageRank[curNode.Number] = dubPageRank[curNode.Number];
                }
                else
                {//将值分给朋友
                    dubPiece = dubPageRank[curNode.Number] / curNode.Degree;
                    foreach (Edge edge in curNode)
                    {
                        newPageRank[edge.Target] += dubPiece;
                    }
                }
            }
            for (i = 0; i < curNetwork.intNumber; i++)
            {
                dubPageRank[i] = newPageRank[i];
                newPageRank[i] = 0.0;
            }
        }
    }
}
