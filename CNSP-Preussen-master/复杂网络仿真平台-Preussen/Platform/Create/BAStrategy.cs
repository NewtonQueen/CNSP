using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNSP.Core;

namespace CNSP.Platform.Create
{
    public class BAStrategy : IfCreateStrategy
    {
        /*
         * Function: Create
         * Description:实现IfCreateStrategy接口
         * Parameters:
         *      CreateParameter cParam
         * Return Value:cNet
         */
        cNet IfCreateStrategy.Create(CreateParameter cParam)
        {
            cNet NewNet = null;
            int intNum, intInit, intLimit;
            int i;

            intNum = cParam.Number;
            intInit = cParam.Para1;
            intLimit = cParam.Para2;
            //生成网络实例，并初始化每个节点实例
            NewNet = new cNet(intNum);
            for (i = 0; i < intNum; i++)
            {
                NewNet.Network.Add (new cNode(i));
            }
            //根据用户选择，确定使用的初始化策略
            if (cParam.Option== true)
            {
                BA_InitNet(ref NewNet, intInit, "FULL");
            }
            else
            {
                BA_InitNet(ref NewNet, intInit, "ER");
            }
            //遍历节点，进行加边操作
            for (i = intInit ; i < intNum; i++)
            {
                BA_AddEdge(ref NewNet, i, intLimit);
            }
            //返回处理完毕的节点
            return NewNet;
        }
        /*
         * Function: Edge
         * Description:BA网络初始化函数
         * Parameters:
         *      ref cNet cNetwork 待初始化网络
         *      int iInit 初始处理节点
         *      string sType 初始算法类型
         * Return Value:
         */
        private void BA_InitNet(ref cNet cNetwork, int iInit, string sType)
        {
            int i, j;
            Random magic1;
            //两两遍历初始节点
            for (i = 1; i < iInit; i++)
            {
                for (j = 0; j < iInit - 1; j++)
                {
                    if (i > j)
                    {//全联通策略直接加边，ER策略根据概率随机加边。
                        if (sType == "ER")
                        {
                            magic1 = new Random(DateTime.Now.Millisecond * i * j);
                            if (magic1.Next(0, 100) > 50)
                            {
                                continue;
                            }
                        }
                        cNetwork.AddEdge(i, j, 1);
                    }
                }
            }
        }
        /*
         * Function: Edge
         * Description:BA网络初始化函数
         * Parameters:
         *      ref cNet cNetwork 待初始化网络
         *      int iNum 节点编号
         *      int iLimit 连边上限
         * Return Value:
         */
        private void BA_AddEdge(ref cNet cNetwork, int iNum, int iLimit)
        {
            Random magic1;
            int i, intLink, intCount;
            double dubLink;

            intCount = 0;
            while (intCount < iLimit)
            {//每个节点加的边小于用户限制
                for (i = 0; i < iNum; i++)
                {
                    if (cNetwork.Network[iNum].Contains(i) == false)
                    {//如果当前节点和目标节点间没有连边
                        dubLink = cNetwork.Network[i].Degree * 1.0 / (cNetwork.intEdge * 2);
                        intLink = Convert.ToInt32(Math.Round(dubLink, 2) * 100);
                        magic1 = new Random(DateTime.Now.Millisecond * intLink);
                        if (magic1.Next(0, 100) < intLink)
                        {//如果概率满足设置则加边
                            cNetwork.AddEdge(iNum, i, 1);
                            intCount += 1;
                        }
                    }
                }
            }
        }
    }
}
