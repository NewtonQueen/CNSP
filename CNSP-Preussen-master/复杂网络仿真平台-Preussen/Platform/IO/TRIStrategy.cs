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
    public class TRIStrategy:IfIOStrategy//��Ԫ���ļ���д�㷨
    {
        const string strEncoding = "gb2312";        //�������ļ��������2312
        const string strSeparator = " ";       //��������Ԫ��ָ���
        const string strComment = "#";       //�������ļ�ע����ʼ���
        const int intAoffset = 0;
        const int intBoffset = 1;
        const int intSourceOffset = 0;
        const int intTargetOffset = 1;
        const int intValueOffset = 2;
        /*
         * Function: CountNodes
         * Description:����ڵ����
         * Parameters:
         *      string sPath �ļ�·��
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
                if (sLine != "" && sLine.StartsWith(strComment) == false)//���в�Ϊ�գ��Ҳ���ע����
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
         * Description:TRIStrategy�㷨��ȡ����
         * Parameters:
         *      string sPath �ļ�·��
         *      StyleSet pStyle ������ʽ��
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
            Reader = new StreamReader(sPath, Encoding.GetEncoding(strEncoding));//�趨���룬��Ϊ�������ģ����ù���2312����
            if (Reader == null)
            {
                return null;
            }
            do
            {
                sLine = Reader.ReadLine().Trim();
                if (sLine != "" && sLine.StartsWith(strComment) == false)          //�ı���Ϊ�գ�Ҳ����ע��
                {
                    PhraseTriad(ref NewNet, sLine, strSeparator);    //�Զ����ı����н���
                }
            } while (Reader.EndOfStream == false);                          //�ļ���ֹ
            Reader.Close();                                                 //�ر��ļ�
            Reader.Dispose();
            if (NewNet.intNumber == 0)
            {
                return null;
            }
            return NewNet;
        }
        /*
         * Function: PhraseTriad
         * Description:TRIStrategy�㷨��ȡ����
         * Parameters:
         *      ref cNet cNetwork   ����������
         *      string sLine        �������ַ���
         *      string Separator    �ָ���
         * Return Value:
         */
        private static void PhraseTriad(ref cNet cNetwork, string sLine, string Separator)
        {
            int intSour, intTar;
            double dubValue;
            string[] strSeg;

            dubValue = 1.0;
            strSeg = sLine.Split(new string[] { Separator }, StringSplitOptions.None);//����ʹ��Separator������Ϣ���黮��
            intSour = Convert.ToInt32(strSeg[intSourceOffset]);
            intTar = Convert.ToInt32(strSeg[intTargetOffset]);
            if (strSeg.Length == 3)
            {
                dubValue = Convert.ToDouble(strSeg[intValueOffset]);
            }
            cNetwork.AddEdge(intSour, intTar, dubValue);                              //���ݶ�������Ϣ�ӱ�
        }
        /*
         * Function: SaveFile
         * Description:TRIStrategy�㷨���溯��
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

            Writer = new StreamWriter(sPath);
            if (Writer == null)
            {
                return;
            }
            xmlroot = doc.ChildNodes.Item(0);
            Nodelist = xmlroot.ChildNodes;                                             //��ȡ�ڵ��б�
            foreach (XmlElement curNode in Nodelist)
            {
                sLine = DualString(curNode);//ѭ�����õײ�ڵ���������;
                if (sLine != "")
                {
                    Writer.WriteLine(sLine);            //д���ļ�
                }
            }
            Writer.Close();                             //�ر��ļ�����ɴ洢
            Writer.Dispose();
        }
        /*
         * Function: DualString
         * Description:�������ݱ��溯��
         * Parameters:
         *      XmlElement curNode  
         * Return Value:string
         */
        public string DualString(XmlElement curNode)//����ڵ�dual��ʽ����������ʱʹ�ã�
        {
            string strResult;
            XmlNode edges_xml;
            string strNum, target, value;

            strNum = curNode.Attributes.GetNamedItem("num").Value;
            edges_xml = null;
            foreach (XmlNode xNode in curNode.ChildNodes)       //�ڵ�λ������
            {
                if (xNode.Name == "Edges")//��ȡ�����б�
                {
                    edges_xml = xNode;
                }
            }
            if (edges_xml == null)
            {
                return "";
            }
            strResult = "";
            foreach (XmlElement edge in edges_xml)//ѭ���������ڵ�������(��ǰ�ڵ�,Ȩ��,Ŀ��ڵ�)һ�еĸ�ʽд���ַ���
            {
                target = edge.Attributes.GetNamedItem("Target").Value;//����Ŀ��ڵ�
                value = edge.InnerText;                           //��������Ȩ��
                if (Convert.ToInt32(target) < Convert.ToInt32(strNum))//��������߱��뱣֤��Ŀ��ڵ�ֵ<��ǰ�ڵ㣬����ֻ�����һ��
                {
                    if (strResult != "")
                    {
                        strResult += "\r\n";//����
                    }
                    strResult += strNum + strSeparator + target + strSeparator + value;
                }
            }
            return strResult;
        }
    }
}
