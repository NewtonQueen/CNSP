using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNSP.Core;

namespace CNSP.Platform.Create
{
    public class SWstrategy : IfCreateStrategy
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
            int intNum, intNei, intPro;
            int i;
            //获取参数
            intNum = cParam.Number;
            intNei = cParam.Para1;
            intPro = cParam.Para2;
            //构建网络并初始化节点实例
            NewNet = new cNet(intNum);
            for (i = 0; i < intNum; i++)
            {
                NewNet.Network.Add(new cNode(i));
            }
            //创建最近邻网络
            SW_CreateNNC(ref NewNet, intNum, intNei);
            //根据用户选项选择WS小世界或NW小世界
            if (cParam.Option == true)
            {
                SW_RandomReLink(ref NewNet, intNum, intNei, intPro);
            }
            else
            {
                SW_RandomAddEdge(ref NewNet, intNum, intNei, intPro);
            }
            return NewNet;
        }
        /*
         * Function: SW_CreateNNC
         * Description:创建最近邻网络函数
         * Parameters:
         *      ref cNet cNetwork   待处理网络
         *      int iNum    网络节点总数
         *      int iNei   待连接邻居数
         * Return Value:
         */
        private void SW_CreateNNC(ref cNet cNetwork, int iNum, int iNei)//生成最近邻网络
        {

            int intCount;
            int intTarget;
            int i, j;

            intCount = iNei / 2;
            for (i = 0; i < iNum; i++)
            {
                for (j = 1; j <= intCount; j++)
                {
                    intTarget = i - j;
                    if (intTarget < 0)
                    {
                        intTarget += iNum;
                    }
                    cNetwork.AddEdge(i, intTarget, 1);
                }
            }
        }
        /*
         * Function: SW_RandomReLink
         * Description:随机重连函数
         * Parameters:
         *      ref cNet cNetwork   待处理网络
         *      int iNum    网络节点总数
         *      int iNei   待连接邻居数
         *      int iPro   重连概率
         * Return Value:
         */
        private void SW_RandomReLink(ref cNet cNetwork, int iNum, int iNei, int iPro)//随机重连
        {
            int intTarget, newTarget, intPoint, intCount;
            Random magic1, magic2;
            int[] tmp, mapTmp;
            int i, j;

            for (i = 0; i < iNum; i++)
            {//遍历网络中所有节点
                intPoint = cNetwork.Network[i].Degree;
                tmp = new int[intPoint];
                mapTmp = new int[intPoint];
                intCount = 0;
                foreach (Edge edge in cNetwork.Network[i])
                {//遍历节点所有连边，并记录下来
                    tmp[intCount] = edge.Target;
                    mapTmp[intCount] = 0;
                    intCount += 1;
                }
                for (j = 0; j < intPoint; j++)
                {//针对每条边计算是否需要重连
                    intTarget = tmp[j];
                    magic1 = new Random(DateTime.Now.Millisecond * i * intTarget);
                    if (magic1.Next(0, 100) < iPro)
                    {
                        do
                        {
                            magic2 = new Random(DateTime.Now.Millisecond * magic1.Next(10, 100));
                            newTarget = magic1.Next(0, iNum-1);
                        } while (intTarget == newTarget || cNetwork.Network[i].Contains(newTarget) == true);
                    }
                }
                for (j = 0; j < intPoint; j++)
                {
                    if (mapTmp[j] > 0)
                    {//符合重连条件的进行重连
                        cNetwork.DecEdge(i, tmp[j]);
                        cNetwork.AddEdge(i, mapTmp[j], 1);
                    }
                }
            }
        }
        /*
         * Function: SW_RandomAddEdge
         * Description:随机加边函数
         * Parameters:
         *      ref cNet cNetwork   待处理网络
         *      int iNum    网络节点总数
         *      int iNei   待连接邻居数
         *      int iPro   加边概率
         * Return Value:
         */
        private void SW_RandomAddEdge(ref cNet cNetwork, int iNum, int iNei, int iPro)//随机加边
        {
            Random magic1 = new Random(DateTime.Now.Millisecond * iNum);
            Random magic2;
            int intSource, intTarget;

            while (cNetwork.intEdge < iNum * iNei)
            {
                magic2 = new Random(DateTime.Now.Millisecond * magic1.Next(0, 1000));
                magic1 = new Random(DateTime.Now.Millisecond * magic2.Next(1000, 2000));

                intSource = magic1.Next(0, iNum - 1);
                intTarget = magic2.Next(0, iNum - 1);
                if (cNetwork.Network[intSource].Contains(intTarget) == false && intSource != intTarget)
                {
                    cNetwork.AddEdge(intSource, intTarget, 1);
                }
            }
        }


    }
}
