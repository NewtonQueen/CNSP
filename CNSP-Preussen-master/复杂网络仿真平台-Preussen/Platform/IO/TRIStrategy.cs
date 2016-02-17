using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Xml;
using CNSP.Core;
using CNSP.Platform;

namespace CNSP.Platform.IO
{
    public class TRIStrategy:IfIOStrategy//三元组文件读写算法
    {
        const string strEncoding = "gb2312";        //常量，文件编码国标2312
        const string strSeparator = " ";       //常量，三元组分隔符
        const string strComment = "#";       //常量，文件注释起始标记
        const int intAoffset = 0;
        const int intBoffset = 1;
        const int intSourceOffset = 0;
        const int intTargetOffset = 1;
        const int intValueOffset = 2;
        /*
         * Function: CountNodes
         * Description:计算节点个数
         * Parameters:
         *      string sPath 文件路径
         * Return Value:int
         */
        public int CountNodes(string sPath)
        {
            StreamReader Counter;
            string sLine;
            int intA, intB,  intEnd;
            string[] strNum;

            intEnd = 0;
            Counter = new StreamReader(sPath, Encoding.GetEncoding(strEncoding));
            if (Counter == null)
            {
                return -1;
            }
            do
            {
                sLine = Counter.ReadLine().Trim();
                if (sLine != "" && sLine.StartsWith(strComment) == false)//本行不为空，且不是注释行
                {
                    strNum = sLine.Split(new string[] { strSeparator }, StringSplitOptions.None);
                    intA = Convert.ToInt32(strNum[intAoffset]);
                    intB = Convert.ToInt32(strNum[intBoffset]);
                    if (intA > intEnd)
                    {
                        intEnd = intA;
                    }
                    if (intB > intEnd)
                    {
                        intEnd = intB;
                    }
                }
            } while (Counter.EndOfStream == false);

            Counter.Close();
            Counter.Dispose();
            return intEnd+1;
        }
        /*
         * Function: ReadFile
         * Description:TRIStrategy算法读取函数
         * Parameters:
         *      string sPath 文件路径
         *      StyleSet pStyle 绘制样式集
         * Return Value:cNet
         */
        cNet IfIOStrategy.ReadFile(string sPath)
        {
            StreamReader Reader;
            cNet NewNet;
            string sLine = "";
            int i, intLines;

            intLines = CountNodes(sPath);
            NewNet = new cNet(intLines);
            for (i = 0; i < intLines; i++)
            {
                NewNet.Network.Add(new cNode(i));
            }
            Reader = new StreamReader(sPath, Encoding.GetEncoding(strEncoding));//设定编码，因为存在中文，采用国标2312编码
            if (Reader == null)
            {
                return null;
            }
            do
            {
                sLine = Reader.ReadLine().Trim();
                if (sLine != "" && sLine.StartsWith(strComment) == false)          //文本不为空，也不是注释
                {
                    PhraseTriad(ref NewNet, sLine, strSeparator);    //对读入文本进行解释
                }
            } while (Reader.EndOfStream == false);                          //文件终止
            Reader.Close();                                                 //关闭文件
            Reader.Dispose();
            if (NewNet.intNumber == 0)
            {
                return null;
            }
            return NewNet;
        }
        /*
         * Function: PhraseTriad
         * Description:TRIStrategy算法读取函数
         * Parameters:
         *      ref cNet cNetwork   待处理网络
         *      string sLine        待分析字符串
         *      string Separator    分隔符
         * Return Value:
         */
        private static void PhraseTriad(ref cNet cNetwork, string sLine, string Separator)
        {
            int intSour, intTar;
            double dubValue;
            string[] strSeg;

            dubValue = 1.0;
            strSeg = sLine.Split(new string[] { Separator }, StringSplitOptions.None);//首先使用Separator进行信息区块划分
            intSour = Convert.ToInt32(strSeg[intSourceOffset]);
            intTar = Convert.ToInt32(strSeg[intTargetOffset]);
            if (strSeg.Length == 3)
            {
                dubValue = Convert.ToDouble(strSeg[intValueOffset]);
            }
            cNetwork.AddEdge(intSour, intTar, dubValue);                              //根据读出的信息加边
        }
        /*
         * Function: SaveFile
         * Description:TRIStrategy算法保存函数
         * Parameters:
         *      string sPath 文件路径
         *      XmlDocument doc 待保存xml数据
         * Return Value:
         */
        void IfIOStrategy.SaveFile(XmlDocument doc, string sPath)
        {
            StreamWriter Writer;
            XmlNodeList Nodelist;
            XmlNode xmlroot;
            string sLine;

            Writer = new StreamWriter(sPath);
            if (Writer == null)
            {
                return;
            }
            xmlroot = doc.ChildNodes.Item(0);
            Nodelist = xmlroot.ChildNodes;                                             //获取节点列表
            foreach (XmlElement curNode in Nodelist)
            {
                sLine = DualString(curNode);//循环调用底层节点的输出函数;
                if (sLine != "")
                {
                    Writer.WriteLine(sLine);            //写入文件
                }
            }
            Writer.Close();                             //关闭文件，完成存储
            Writer.Dispose();
        }
        /*
         * Function: DualString
         * Description:连边数据保存函数
         * Parameters:
         *      XmlElement curNode  
         * Return Value:string
         */
        public string DualString(XmlElement curNode)//输出节点dual格式（保存网络时使用）
        {
            string strResult;
            XmlNode edges_xml;
            string strNum, target, value;

            strNum = curNode.Attributes.GetNamedItem("num").Value;
            edges_xml = null;
            foreach (XmlNode xNode in curNode.ChildNodes)       //节点位置设置
            {
                if (xNode.Name == "Edges")//获取连边列表
                {
                    edges_xml = xNode;
                }
            }
            if (edges_xml == null)
            {
                return "";
            }
            strResult = "";
            foreach (XmlElement edge in edges_xml)//循环，将本节点连边以(当前节点,权重,目标节点)一行的格式写入字符串
            {
                target = edge.Attributes.GetNamedItem("Target").Value;//读出目标节点
                value = edge.InnerText;                           //读出连边权重
                if (Convert.ToInt32(target) < Convert.ToInt32(strNum))//输出的连边必须保证，目标节点值<当前节点，连边只会输出一次
                {
                    if (strResult != "")
                    {
                        strResult += "\r\n";//换行
                    }
                    strResult += strNum + strSeparator + target + strSeparator + value;
                }
            }
            return strResult;
        }
    }
}
