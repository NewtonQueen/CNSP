using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNSP.Core
{
    public class Error
    {
        string strReason;                   //����ԭ���ַ���
        public ErrorList intError;          //����ö��

        public enum ErrorList
        {
            OK = 0,
            FormatFault =1,
            OpenFailed = 2,
            SaveError = 3,
        }
        /*
         * Function: Error
         * Description:Error�๹�캯��
         * Parameters: 
         *      string sReason ����ԭ���ַ���
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
                case "�ļ���ʽ����":
                    intError = ErrorList.FormatFault;
                    break;
                case "�ļ��򿪴���":
                    intError = ErrorList.OpenFailed;
                    break;
                case "�������":
                    intError = ErrorList.SaveError;
                    break;
                default:
                    break;
            }
        }
        /*
         * Function: ToString
         * Description:ת��Ϊ�ַ������(���غ�����
         * Parameters:
         * Return Value:string
         */
        override public string ToString()
        {
            return strReason;
        }

    }
}
