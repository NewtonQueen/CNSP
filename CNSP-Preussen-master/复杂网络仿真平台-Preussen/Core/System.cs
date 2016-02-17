using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNSP.Core
{
    public class Error
    {
        string strReason;                   //错误原因字符串
        public ErrorList intError;          //错误枚举

        public enum ErrorList
        {
            OK = 0,
            FormatFault =1,
            OpenFailed = 2,
            SaveError = 3,
        }
        /*
         * Function: Error
         * Description:Error类构造函数
         * Parameters: 
         *      string sReason 错误原因字符串
         * Return Value: Error
         */
        public Error(string sReason)
        {
            strReason = sReason;

            switch(sReason)
            {
                case "OK":
                    intError = ErrorList.OK;
                    break;
                case "文件格式错误":
                    intError = ErrorList.FormatFault;
                    break;
                case "文件打开错误":
                    intError = ErrorList.OpenFailed;
                    break;
                case "保存错误":
                    intError = ErrorList.SaveError;
                    break;
                default:
                    break;
            }
        }
        /*
         * Function: ToString
         * Description:转化为字符串输出(重载函数）
         * Parameters:
         * Return Value:string
         */
        override public string ToString()
        {
            return strReason;
        }

    }
}
