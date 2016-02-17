using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Drawing;
using CNSP.Core;
using CNSP.Platform;
using CNSP.KeyWord;

namespace CNSP.Platform.IO
{
    public class XMLStrategy:IfIOStrategy//XML�ļ���д�㷨
    {
        /*
         * Function: ReadFile
         * Description:XMLStrategy�㷨��ȡ����
         * Parameters:
         *      string sPath �ļ�·��
         *      StyleSet pStyle ������ʽ��
         * Return Value:cNet
         */
        cNet IfIOStrategy.ReadFile(string sPath)
        {
            FileStream stream = null;
            XmlDocument doc = new XmlDocument();
            XmlNodeList Nodelist;
            XmlNode xmlroot, xmltmp;
            cNet NewNet;
            int iNum;

            try
            {
                stream = new FileStream(sPath, FileMode.Open);
                doc.Load(stream);               //�����ļ�����xml�ĵ�
                stream.Close();
            }
            catch (Exception ex)
            {
                if (stream != null)
                {
                    ex.ToString();
                    stream.Dispose();
                }
                return null;
            }
            stream.Dispose();
            xmlroot = doc.ChildNodes.Item(0);
            Nodelist = xmlroot.ChildNodes;                                             //��ȡ�ڵ��б�
            xmltmp = Nodelist[0].ChildNodes[3];
            //��������
            NewNet = new cNet(Nodelist.Count);
            for (iNum = 0; iNum < Nodelist.Count; iNum++)
            {
                switch (xmltmp.Name)
                {//����XML��������
                    case "Word"://�������Word��ǩ�����ǹؼ��������ļ�������KNode
                        NewNet.Network.Add(new kNode(iNum));
                        break;
                    default://Ĭ�϶���cNode
                        NewNet.Network.Add(new cNode(iNum));
                        break;
                } 
            }
            NewNet.XMLtoNet(doc);
            if (NewNet.intNumber == 0)
            {
                return null;
            }
            return NewNet;
        }

        /*
         * Function: SaveFile
         * Description:XMLStrategy�㷨���溯��
         * Parameters:
         *      string sPath �ļ�·��
         *      XmlDocument doc ������xml����
         * Return Value:
         */
        void IfIOStrategy.SaveFile(XmlDocument doc, string sPath)
        {
            FileStream stream = null;

            try
            {
                stream = new FileStream(sPath, FileMode.Create);
                doc.Save(stream);               //����xml�ĵ�����
                stream.Close();
            }
            catch (Exception ex)
            {
                if (stream != null)
                {
                    ex.ToString();
                    stream.Dispose();
                }
            }
            stream.Dispose();
        }
    }
}
