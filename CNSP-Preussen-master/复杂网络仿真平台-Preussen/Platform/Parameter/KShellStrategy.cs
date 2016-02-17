using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNSP.Core;

namespace CNSP.Platform.Parameter
{
    class KShellStrategy
    {
        public int[] intKShell;

        //构造函数
        public KShellStrategy(int iNum)
        {
            intKShell = new int[iNum];
        }

        int[] Kshell
        {
            get
            {
                return intKShell;
            }
        }

        //公开接口函数
        public void Calculate(pNet curNetwork)
        {
            CalKShell(curNetwork);
        }

        //节点状态初始化函数
        int InitState(ref pNet curNetwork)
        {
            int intCount = 0;
            foreach (pNode curNode in curNetwork.Network)
            {
                if (curNode.Degree == 0)
                {
                    curNode.State = 0;
                    intCount++;
                }
                else
                {
                    curNode.State = -1;
                }
            }
            return intCount;
        }

        //K-Shell核心算法
        void CalKShell(pNet curNetwork)
        {
            int intCount, intLevel;
            List<int> intTarget;

            intCount = InitState(ref curNetwork);
            intLevel = 1;
            intTarget = new List<int>();
            while (intCount < curNetwork.intNumber)
            {
                intTarget.Clear();
                foreach (pNode curNode in curNetwork.Network)
                {
                    if(curNode.State == -1 && curNode.Degree == intLevel)
                    {//选中度和当前级别相等的，并没有赋值的节点
                        curNode.State = intLevel;
                        intCount += 1;
                        intTarget.Add(curNode.Number);
                    }
                }
                if (intTarget.Count == 0)
                {//当前循环没有节点则增加一级
                    intLevel += 1;
                }
                else
                {//选中的节点，删除所有连边
                    DeleteEdges(intTarget, ref curNetwork);
                    intLevel = 0;
                }
            }
            foreach (pNode curNode in curNetwork.Network)
            {
                intKShell[curNode.Number] = curNode.State;
            }
        }

        //连边删除
        void DeleteEdges(List<int> Source, ref pNet curNetwork)
        {
            List<int> Target;

            foreach (int iNum in Source)
            {
                Target = new List<int>();
                //不能再foreach内部改变节点的连边，只能先记录下来
                foreach (Edge edge in curNetwork.Network[iNum])
                {
                    Target.Add(edge.Target);
                }
                //依据记录结果删除连边
                foreach (int intTarget in Target)
                {
                    curNetwork.DecEdge(iNum, intTarget);
                }
            }
        }
    }
}
