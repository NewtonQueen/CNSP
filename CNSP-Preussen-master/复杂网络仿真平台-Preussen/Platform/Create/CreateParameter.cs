using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNSP.Platform.Create
{
    public class CreateParameter//创建参数类
    {
        int intNumber;      //节点数量
        int intPara1;          //第一参数
        int intPara2;           //第二参数
        bool bolOption;     //用户选项
        //
        public int Number
        {
            get
            {
                return intNumber;
            }
        }
        public int Para1
        {
            get
            {
                return intPara1;
            }
        }
        public int Para2
        {
            get
            {
                return intPara2;
            }
        }
        public bool Option
        {
            get
            {
                return bolOption;
            }
        }
        //Method
        /*
         * Function: CreateParameter
         * Description:网络构建算法参数构造函数
         * Parameters:
         *      int iNum    节点数量
         *      int iP1     第一参数
         *      int iP2     第二参数
         *      bool bOpt   用户选项
         * Return Value:BAStrategy
         */
        public CreateParameter(int iNum, int iP1, int iP2, bool bOpt)
        {
            intNumber = iNum;
            intPara1 = iP1;
            intPara2 = iP2;
            bolOption = bOpt;
        }
    }
}
