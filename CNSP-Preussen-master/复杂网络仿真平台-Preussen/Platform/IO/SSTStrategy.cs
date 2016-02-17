using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNSP.Core;
using CNSP.Platform;
using System.IO;
using System.Drawing;
using System.Xml;

namespace CNSP.Platform.IO
{
    public class SSTStrategy:IfIOStrategy//SST文件读写算法
    {
        const string strEncoding = "gb2312";
        const int xPos = 1;
        const int yPos = 2;
        const int EdgePos = 3;
        const int linkOffset = 1;
        const char SeperatorOut = '-';
        const char SeperatorIn = ',';
        const string strCommet = "#";
        int intNumOffset = 0; //如果等于0则代表新版本，编号从0开始，如果为1，代表老版本，编号从1开始。
        /*
         * Function: ReadFile
         * Description:SSTStrategy算法读取函数
         * Parameters:
         *      string sPath 文件路径
         *      StyleSet pStyle 绘制样式集
         * Return Value:cNet
         */
        cNet IfIOStrategy.ReadFile(string sPath)
        {
            StreamReader  Reader;
            cNet NewNet;
            List<string> store;
            string sLine = "";
            int intLines = 0;
            int intTemp;

            Reader = new StreamReader(sPath, Encoding.GetEncoding(strEncoding));
            if(Reader == null)
            {
                return null;
            }
            store = new List<string>();
            do
            {
                //读出一行
                sLine = Reader.ReadLine().Trim();
                //检查是否空行或注释
                if (sLine != "" && sLine.StartsWith(strCommet) == false)  
                {
                    //将生成的字符串保存入列表
                    store.Add(sLine);
                    if (intLines == 0)
                    {
                        intTemp = sLine.IndexOf('-');
                        if (sLine.Substring(0, intTemp) == "1")
                        {
                            intNumOffset = 1;
                        }
                    }
                    intLines++;
                }
            } while (Reader.EndOfStream == false);                  
            Reader.Close();
            Reader.Dispose();
            //初始化网络
            NewNet = new cNet(intLines);
            intLines = 0;
            //遍历节点字符串列表，加入网络
            foreach(string strLine in store)
            {
                //将解析后生成的节点加入网络
                NewNet.Network.Add(SstInit(strLine, intLines));
                intLines++;
            }
            if (NewNet.intNumber == 0)
            {
                return null;
            }
            return NewNet;
        }
        /*
         * Function: SstInit
         * Description:节点数据解析函数
         * Parameters:
         *      string sPath 文件路径
         *      int iNum    节点编号
         * Return Value:IfPlatform
         */
        private IfPlatform SstInit(string sLine, int iNum)
        {
            IfPlatform NewNode;
            string[] strSeg, strLink, strValue;
            int intDegree = 0, intlast;
            int intTarget;
            int i;

            //初始化新节点
            NewNode = new cNode(iNum);
            //切分字符串，变为各个子单元
            strSeg = sLine.Split(new char[] { SeperatorOut });                                
            intlast = strSeg.Length - 1;
            if (strSeg[intlast-linkOffset].Trim() != "")                                       
            {//生成节点基本信息
                strLink = strSeg[intlast - linkOffset].Split(new char[] { SeperatorIn });
                strValue = strSeg[intlast].Split(new char[] { SeperatorIn });
                intDegree = strLink.Length;
                for (i = 0; i < intDegree; i++)
                {
                    intTarget = Convert.ToInt32(strLink[i]) - intNumOffset;
                    if (iNum != intTarget)
                    {
                        NewNode.AddEdge(intTarget, Convert.ToDouble(strValue[i]));
                    }
                }
            }
            NewNode.Location = new Point(Convert.ToInt32(strSeg[xPos]), Convert.ToInt32(strSeg[yPos]));
            return NewNode;
        }
        /*
         * Function: SaveFile
         * Description:SST文件保存函数
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

            Writer = new StreamWriter(sPath, false, Encoding.GetEncoding(strEncoding));
            if(Writer == null)
            {
                return;
            }
            xmlroot = doc.ChildNodes.Item(0);
            Nodelist = xmlroot.ChildNodes;                                             //获取节点列表
            foreach(XmlElement curNode in Nodelist)                                            
            {//将xml数据序列化为字符串
                sLine = SstString(curNode);     
                Writer.WriteLine(sLine);           
            }
            Writer.Close();
            Writer.Dispose();
        }
        /*
        * Function: SstString
        * Description:节点数据提取函数
        * Parameters:
        *      XmlElement curNode
        * Return Value:string
        */
        public string SstString(XmlElement curNode)
        {
            XmlNode x_xml, y_xml, edges_xml;
            string strNum, x, y, target, value;
            string strResult;
            string strLink;
            string strValue;

            strLink = "";
            strValue = "";
            //节点编号
            strNum = curNode.Attributes.GetNamedItem("num").Value;
            x_xml = y_xml = edges_xml = null;
            foreach (XmlNode xNode in curNode.ChildNodes)       //节点位置设置
            {
                if (xNode.Name == "Xpos")//节点位置
                {
                    x_xml = xNode;
                }
                if (xNode.Name == "Ypos")
                {
                    y_xml = xNode;
                }
                if (xNode.Name == "Edges")//获取连边列表
                {
                    edges_xml = xNode;
                }
            }
            if (x_xml == null || y_xml == null || edges_xml == null)
            {
                return "";
            }
            x = x_xml.InnerText;
            y = y_xml.InnerText;
            strResult = strNum.ToString() + "-";
            strResult += x.ToString() + "-";
            strResult += y.ToString() + "-";
            foreach (XmlNode edge in edges_xml.ChildNodes)                                     //遍历连边列表
            {
                target = edge.Attributes.GetNamedItem("Target").Value;//读出目标节点
                value = edge.InnerText;                           //读出连边权重
                if (strLink == "")
                {
                    strLink = target;
                }
                else
                {
                    strLink += "," + target;
                }

                if (strValue == "")
                {
                    strValue = value;
                }
                else
                {
                    strValue += "," + value;
                }
            }
            strResult += strLink + "-" + strValue;
            return strResult;
        }
    }
}
