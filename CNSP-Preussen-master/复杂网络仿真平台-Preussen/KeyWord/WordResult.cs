using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNSP.KeyWord
{
    public class WordResult//分词结果保存对象类
    {
        string strWord;     //词语内容
        string strType;      //词语词性
        int intPosition;      //词语所处语句的位置
        int intLine;            //词语所处语句的编号
        bool bolIgnore;     //是否被忽略标记
        bool bolMerged;     //是否被兼并标记
        KeyValuePair<int, int> kvpOwner;    //被哪个词语兼并

        public string Word
        {
            get
            {
                return strWord;
            }
        }
        public string Type
        {
            get
            {
                return strType;
            }
        }
        public int Position
        {
            get
            {
                return intPosition;
            }
            set
            {
                intPosition = value;
            }
        }
        public int Line
        {
            get
            {
                return intLine;
            }
            set
            {
                intLine = value;
            }
        }
        public bool IsIgnore
        {
            get
            {
                return bolIgnore;
            }
        }
        public bool IsMerged
        {
            get
            {
                return bolMerged;
            }
        }
        public KeyValuePair<int, int> Owner
        {
            get
            {
                return kvpOwner;
            }
        }

        //构造函数，输入词语和词性，即第三方分词模块输出
        public WordResult(string sWord, string sType)
        {
            strWord = sWord;
            strType = sType;
            intPosition = 0;
            intLine = 0;
            bolIgnore = false;
            bolMerged = false;
        }

        //兼并本节点
        public void Merged(int iLine, int iPos)
        {
            //记录新主人所在语句编号和位置
            kvpOwner = new KeyValuePair<int, int>(iLine,iPos);
            //修改兼并标记位
            bolMerged = true;
            //被兼并节点同时也被忽略
            this.Ignore();
        }
        //忽略本节点
        public void Ignore()
        {
            this.bolIgnore = true;
        }
    }
}
