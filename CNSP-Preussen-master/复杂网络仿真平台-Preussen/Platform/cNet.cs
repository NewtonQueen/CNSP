using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Xml;
using Microsoft.VisualBasic;
using CNSP.Platform;
using CNSP.Core;
using CNSP.Platform.Paint;
using CNSP.Platform.IO;

namespace CNSP.Platform
{
    public class cNet//����������
    {      
        public List<IfPlatform> Network; //����ڵ㼯��
        public int intNumber;           //�ڵ�����
        public int intEdge;             //��������
        //˽�б�����
        public NetState netState;
        public IfIOStrategy IOhandle;   //�����������
        public IfPaintStrategy NetPainter;              //��������㷨����

        //����///////////////////////////////////////
        public float AveDeg
        {
            get
            {
                return netState.AveDeg;
            }
        }
        public int MaxDeg
        {
            get
            {
                return netState.MaxDeg;
            }
        }
        public int MinDeg
        {
            get
            {
                return netState.MinDeg;
            }
        }
        public string Master
        {
            get
            {
                return netState.Master;
            }
        }
        public string Type
        {
            get
            {
                return netState.Type;
            }
        }
        //����///////////////////////////////////////
        public cNet(int intNum)//�ⲿ���캯��
        {
            intNumber = intNum;
            intEdge = 0;
            Network = new List<IfPlatform>();    //�ڵ����鳤���ض���
            netState = new NetState();
        }

        //�����ʼ�����ڼ������нڵ�֮��ִ��һ��
        public void Initialized(StyleSet PaintStyle)
        {
            NetworkType();//�������ͷ���
            DegreeStat();//�ڵ��ͳ��
            switch (PaintStyle.Sharp)
            {
                case StyleSet.sharp.Round:
                    NetPainter = new DefaultStrategy(PaintStyle);
                    break;
            }
            NetPainter.UpdateLocation(this.ToXML());//�ڵ�����ˢ��
            NetPainter.UpdateImage();//�ڵ�ͼ��ˢ��
        }

        //�������ͷ���������ȷ�������Ƿ�����
        private void NetworkType()
        {
            int i, intTarget, intSource;
            for (i = 0; i < intNumber; i++)
            {
                foreach (Edge edge in Network[i])
                {
                    intTarget = edge.Target;
                    intSource = i;
                    if (Network[intTarget].Contains(intSource) == false)
                    {
                        netState.Type = "����ͼ";
                        return;
                    }
                }
            }
            netState.Type = "����ͼ";
            return;
        }

        //�ڵ��ͳ�ƺ��������ȣ���С�ȣ����б�
        private void DegreeStat()
        {
            int intTarget;
            int intTotal;
            int i, intMaxDeg, intMinDeg;
            string strMaster;
            float sngAveDeg;

            intMaxDeg = 0;
            intMinDeg = intNumber;
            strMaster = "";
            intTotal = 0;
            //�ҳ�������С��
            for (i = 0; i < intNumber; i++)
            {
                intTarget = Network[i].Degree;
                intTotal += intTarget;
                if (intTarget > intMaxDeg)
                {
                    intMaxDeg = intTarget;
                }
                if (intTarget < intMinDeg)
                {
                    intMinDeg = intTarget;
                }
            }
            //��������ƽ����
            sngAveDeg = intTotal / intNumber;

            if (netState.Type == "����ͼ")
            {
                intEdge = intTotal;
            }
            else
            {
                intEdge = intTotal / 2;
            }
            netState.intDegDist = new int[intMaxDeg + 1];
            for (i = 0; i < intNumber; i++)
            {
                intTarget = Network[i].Degree;
                netState.intDegDist[intTarget] += 1;
                if (intTarget == intMaxDeg)
                {
                    strMaster += i.ToString() + ",";
                }
            }
            netState.MinDeg = intMinDeg;
            netState.MaxDeg = intMaxDeg;
            netState.AveDeg = sngAveDeg;
            netState.Master = strMaster;

        }

        //�����������ߺ������ṩ���˵�����Ȩ��
        public void AddEdge(int iNum, int iTarget, double dValue)
        {
            bool a, b;
            if (iNum != iTarget)//���˵㲻ͬ
            {
                a = Network[iNum].AddEdge(iTarget, dValue);//�ֱ���������ڵ�ĳ�Ա������ʵ�ּӱߡ�
                b = Network[iTarget].AddEdge(iNum, dValue);
                if (a == true && b == true)//���ε��ö��ɹ����ܱ���+1
                {
                    intEdge += 1;
                }
                else
                {
                    //throw new Exception("�ڽڵ�" + iNum.ToString() + "," + iTarget.ToString() + "֮���޷������ӱߡ�");
                }
            }
        }

        //ȥ�����ߣ��ṩ���˵���
        public void DecEdge(int iNum, int iTarget)
        {
            if (netState.Type == "����ͼ")
            {
                Network[iNum].DecEdge(iTarget);
            }
            else
            {
                Network[iNum].DecEdge(iTarget);
                Network[iTarget].DecEdge(iNum);
            }
            intEdge -= 1;
        }
        
        //��������ṹͼ������Ŀ��ͼԪ���͸����ڵ��ţ�Ĭ��Ϊû�У�
        public void Draw(ref Graphics GraCam, int intExclude = -1)//
        {
            NetPainter.Draw(ref GraCam, intExclude);
        }

        //���Ƹ����ڵ�����������
        public void DrawHighLightNodeEdge(int iNum, Point newLoc, ref Graphics GraCam)
        {
            NetPainter.DrawHighLightNodeEdge(iNum, newLoc, ref GraCam);
        }
        
        //����������ʽ������ˢ�½ڵ�ͼƬ�б�
        //public void UpdateStyle(StyleSet GlobalStyle)
        //{
        //    if (GlobalStyle == null)
        //    {
        //        return;
        //    }
        //    //��ͬ��ʽ�����˳�
        //    if (NetPainter.PaintStyle.Equals(GlobalStyle) == true)
        //    {
        //        return;
        //    }
        //    if (GlobalStyle.Sharp == NetPainter.PaintStyle.Sharp)
        //    {
        //        NetPainter.UpdateStyle(GlobalStyle);
        //    }
        //    else
        //    {
        //        switch (GlobalStyle.Sharp)
        //        {
        //            case (StyleSet.sharp.Round):
        //                NetPainter = new DefaultStrategy(GlobalStyle);
        //                break;
        //        }
        //    }
        //}

        //����������ʽ������ˢ�½ڵ�ͼƬ�б�
        public void UpdateStyle(Object sender, StyleUpdateEventArgs e)
        {
            if (e.NewStyleSet == null)
            {
                return;
            }
            //��ͬ��ʽ�����˳�
            if (NetPainter.PaintStyle.Equals(e.NewStyleSet) == true)
            {
                return;
            }
            if (e.NewStyleSet.Sharp == NetPainter.PaintStyle.Sharp)
            {
                NetPainter.UpdateStyle(e.NewStyleSet);
            }
            else
            {
                switch (e.NewStyleSet.Sharp)
                {
                    case (StyleSet.sharp.Round):
                        NetPainter = new DefaultStrategy(e.NewStyleSet);
                        break;
                }
            }
        }

        //ˢ������ͼƬ�б�
        public void UpdateImage()
        {
            NetPainter.UpdateImage();
        }

        //�����ļ���ȡ����
        public static cNet Read(string sPath,ref Error eRet)
        {
            string strExpand;
            cNet NewNet;
            IfIOStrategy Reader;
			
            //1.��ȡ��չ��
            strExpand = cNet.GetExpandName(sPath).ToLower();
            //2.ѡ�������㷨
            switch (strExpand)
            {
                case ".sst":
                    Reader = new SSTStrategy();
                    break;
                case ".xml":
                    Reader = new XMLStrategy();
                    break;
                case ".tri":
                    Reader = new TRIStrategy();
                    break;
                case ".mat":
                    Reader = new MATStrategy();
                    break;
                case ".kwt":
                    Reader = new KWTStrategy();
                    break;
                default:
                    eRet = new Error("�ļ���ʽ����");
                    return null;
            }
			
            //3.��������
            NewNet = Reader.ReadFile(sPath);
            if (NewNet == null)
            {
                eRet = new Error("�ļ���ʽ����");
            }
            else
            {
                eRet = new Error("OK");
            }
            return NewNet;
        }

        //���籣��Ϊ�ļ�
        public Error Save(string sPath)
        {
            string strExpand;
            XmlDocument doc;
            IfIOStrategy Saver;

            //1.��ȡ��չ��
            strExpand = GetExpandName(sPath).ToLower();
            //2.ѡ�������㷨
            switch (strExpand)
            {
                case ".sst":
                    Saver = new SSTStrategy();
                    break;
                case ".xml":
                    Saver = new XMLStrategy();
                    break;
                case ".tri":
                    Saver = new TRIStrategy();
                    break;
                case ".mat":
                    Saver = new MATStrategy();
                    break;
                default:
                    return new Error("�ļ���ʽ����");
            }
            //�����������ݶ�����Ϊxml��ʽ
            doc = this.ToXML();
            Saver.SaveFile(doc, sPath);
            return new Error("OK");
        }

        //�ļ���չ����ȡ����
        private static string GetExpandName(string sName)
        {
            string strExpand;
            int intPos;
            int intLength;

            //�з����һ��.֮����ַ���
            intPos = sName.LastIndexOf(".");
            intLength = sName.Length;
            strExpand = sName.Substring(intPos, (intLength - intPos));
            return strExpand;
        }

        //��xml�ļ�ת��Ϊ����
        public void XMLtoNet(XmlDocument doc)
        {
            int i;
            XmlNodeList Nodelist;
            XmlNode xmlroot;
            int intNumOffset = 0; 

            xmlroot = doc.ChildNodes.Item(0);
            Nodelist = xmlroot.ChildNodes;                                             //��ȡ�ڵ��б�
            i = 0;
            foreach (XmlElement curNode in Nodelist)                                      //�����ڵ��б�
            {
                if (i == 0)
                {
                    if (curNode.GetAttribute("num").Trim() == "1")
                    {
                        intNumOffset = 1;
                    }
                }
                this.Network[i].XMLinput(curNode, intNumOffset);                           //�����²㺯���������½ڵ�
                i++;
            }
        }

        public XmlDocument ToXML()
        {
            XmlDocument doc = new XmlDocument();
            //�����������ݶ�����Ϊxml��ʽ
            XmlElement root = doc.CreateElement("Network");
            root.SetAttribute("Nodes", intNumber.ToString());
            root.SetAttribute("Edges", intEdge.ToString());

            foreach(IfPlatform xNode in Network)
            {
                root.AppendChild(xNode.XMLoutput(ref doc));     //ѭ�����õײ�ڵ���������
            }
            doc.AppendChild(root);
            return doc;
        }

    }
}
