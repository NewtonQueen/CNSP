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
    public class SSTStrategy:IfIOStrategy//SST�ļ���д�㷨
    {
        const string strEncoding = "gb2312";
        const int xPos = 1;
        const int yPos = 2;
        const int EdgePos = 3;
        const int linkOffset = 1;
        const char SeperatorOut = '-';
        const char SeperatorIn = ',';
        const string strCommet = "#";
        int intNumOffset = 0; //�������0������°汾����Ŵ�0��ʼ�����Ϊ1�������ϰ汾����Ŵ�1��ʼ��
        /*
         * Function: ReadFile
         * Description:SSTStrategy�㷨��ȡ����
         * Parameters:
         *      string sPath �ļ�·��
         *      StyleSet pStyle ������ʽ��
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
                //����һ��
                sLine = Reader.ReadLine().Trim();
                //����Ƿ���л�ע��
                if (sLine != "" && sLine.StartsWith(strCommet) == false)  
                {
                    //�����ɵ��ַ����������б�
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
            //��ʼ������
            NewNet = new cNet(intLines);
            intLines = 0;
            //�����ڵ��ַ����б���������
            foreach(string strLine in store)
            {
                //�����������ɵĽڵ��������
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
         * Description:�ڵ����ݽ�������
         * Parameters:
         *      string sPath �ļ�·��
         *      int iNum    �ڵ���
         * Return Value:IfPlatform
         */
        private IfPlatform SstInit(string sLine, int iNum)
        {
            IfPlatform NewNode;
            string[] strSeg, strLink, strValue;
            int intDegree = 0, intlast;
            int intTarget;
            int i;

            //��ʼ���½ڵ�
            NewNode = new cNode(iNum);
            //�з��ַ�������Ϊ�����ӵ�Ԫ
            strSeg = sLine.Split(new char[] { SeperatorOut });                                
            intlast = strSeg.Length - 1;
            if (strSeg[intlast-linkOffset].Trim() != "")                                       
            {//���ɽڵ������Ϣ
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
         * Description:SST�ļ����溯��
         * Parameters:
         *      string sPath �ļ�·��
         *      XmlDocument doc ������xml����
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
            Nodelist = xmlroot.ChildNodes;                                             //��ȡ�ڵ��б�
            foreach(XmlElement curNode in Nodelist)                                            
            {//��xml�������л�Ϊ�ַ���
                sLine = SstString(curNode);     
                Writer.WriteLine(sLine);           
            }
            Writer.Close();
            Writer.Dispose();
        }
        /*
        * Function: SstString
        * Description:�ڵ�������ȡ����
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
            //�ڵ���
            strNum = curNode.Attributes.GetNamedItem("num").Value;
            x_xml = y_xml = edges_xml = null;
            foreach (XmlNode xNode in curNode.ChildNodes)       //�ڵ�λ������
            {
                if (xNode.Name == "Xpos")//�ڵ�λ��
                {
                    x_xml = xNode;
                }
                if (xNode.Name == "Ypos")
                {
                    y_xml = xNode;
                }
                if (xNode.Name == "Edges")//��ȡ�����б�
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
            foreach (XmlNode edge in edges_xml.ChildNodes)                                     //���������б�
            {
                target = edge.Attributes.GetNamedItem("Target").Value;//����Ŀ��ڵ�
                value = edge.InnerText;                           //��������Ȩ��
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
