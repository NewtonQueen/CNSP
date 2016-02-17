using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNSP.Core;


namespace CNSP.Platform.Create
{
    public class ERStrategy : IfCreateStrategy
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
            int intNum, intEdge, intLink;
            int i;
            //获取参数
            intNum = cParam.Number;
            intEdge = cParam.Para1;
            intLink = cParam.Para2;
            //生成网络，并初始化节点
            NewNet = new cNet(intNum);
            for (i = 0; i < intNum; i++)
            {
                NewNet.Network.Add(new cNode(i));
            }
            //根据用户选项确定加边算法
            if (cParam.Option == true)
            {
                while (NewNet.intEdge < intEdge)
                {
                    ER_AddEdge_Edge(ref NewNet, intNum);
                }
            }
            else
            {
                ER_AddEdge_Pro(ref NewNet, intNum, intLink);
            }
            return NewNet;
        }

        /*
         * Function: ER_AddEdge_Edge
         * Description:随机加边函数
         * Parameters:
         *      ref cNet cNetwork   待处理网络
         *      int iNum    网络节点总数
         * Return Value:
         */
        private void ER_AddEdge_Edge(ref cNet cNetwork, int iNum)
        {
            Random magic1 = new Random(DateTime.Now.Millisecond * iNum);
            Random magic2;
            int intSource, intTarget;

            magic2 = new Random(DateTime.Now.Millisecond * magic1.Next(0, 1000));
            magic1 = new Random(DateTime.Now.Millisecond * magic2.Next(1000, 2000));

            intSource = magic1.Next(0, iNum - 1);
            intTarget = magic2.Next(0, iNum - 1);
            if (cNetwork.Network[intSource].Contains(intTarget) == false)
            {
                cNetwork.AddEdge(intSource, intTarget, 1);
            }
        }
        /*
         * Function: Edge
         * Description:根据概率加边函数
         * Parameters:
         *      ref cNet cNetwork   待处理网络
         *      int iNum    网络节点总数
         *      int iLink   预设概率
         * Return Value:
         */
        private void ER_AddEdge_Pro(ref cNet cNetwork, int iNum, int iLink)
        {
            int i, j;
            Random magic1;
            for (i = 0; i < iNum; i++)
            {
                for (j =i + 1; j < iNum - 1; j++)
                {
                    magic1 = new Random(DateTime.Now.Millisecond * (i+1) * j);
                    if (magic1.Next(0, 100) > iLink)
                    {
                        continue;
                    }
                    cNetwork.AddEdge(i, j, 1);
                }
            }
        }

    }
}
