using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D; 
using System.Xml;
using CNSP.Core;

namespace CNSP.Platform
{
    public class cNode:IfPlatform//��������ڵ��ࣺ����洢��һ����ڵ����Ϣ�������ϲ����ṩ���ܽӿں���
    {
        //��Ա����
        Node node;
        //����///////////////////////////////
        int IfPlatform.Number
        {
            get
            {
                return this.node.Number;
            }
        }
        int IfPlatform.Degree
        {
            get
            {
                return this.node.Degree;
            }
        }
        Point IfPlatform.Location
        {
            get
            {
                return this.node.Location;
            }
            set
            {
                this.node.Location = value;
            }
        }
        //����///////////////////////////////
        public cNode(int iNum)    //���캯�����½�
        {
            this.node = new Node(iNum);
        }
        //��������
        bool IfPlatform.AddEdge(int iTarget, double dValue)
        {
            return this.node.AddEdge(iTarget, dValue);
        }

        //ɾ������
        bool IfPlatform.DecEdge(int iTarget)
        {
            return this.node.DecEdge(iTarget);
        }

        //��ȡָ������Ȩ��
        double IfPlatform.GetWeight(int iTarget)
        {
            if (node.ContainsEdge(iTarget) == true)
            {
                return node.Links[iTarget].Value;
            }
            return 0;
        }

        //����Ƿ������ĳ���ڵ������
        bool IfPlatform.Contains(int iTarget)
        {
            return this.node.ContainsEdge(iTarget);
        }
        //����ö������foreach���ʹ��
        NodeEnumerator IfPlatform.GetEnumerator()
        {
            return this.node.GetEnumerator();
        }
        //��xml���������ɽڵ�
        void IfPlatform.XMLinput(XmlElement xNode, int intNumOffset)
        {
            XmlNode degree_xml, x_xml, y_xml, edges_xml;
            Node newNode;
            int intNum, x, y, tar;
            double value;

            intNum = Convert.ToInt32(xNode.Attributes.GetNamedItem("num").Value) - intNumOffset;
            newNode = new Node(intNum);                                            //�½��ڵ�
            degree_xml = x_xml = y_xml = edges_xml = null;
            foreach (XmlNode curNode in xNode.ChildNodes)       //�ڵ�λ������
            {
                if (curNode.Name == "Degree")//�ڵ��
                {
                    degree_xml = curNode;
                }
                if (curNode.Name == "Xpos")//�ڵ�λ��
                {
                    x_xml = curNode;
                }
                if (curNode.Name == "Ypos")
                {
                    y_xml = curNode;
                }
                if (curNode.Name == "Edges")//��ȡ�����б�
                {
                    edges_xml = curNode;
                }
            }
            if (x_xml == null || y_xml == null || edges_xml == null)
            {
                return;
            }
            x = Convert.ToInt32(x_xml.InnerText);
            y = Convert.ToInt32(y_xml.InnerText);
            newNode.Location = new Point(x, y);
            
            foreach (XmlNode edge in edges_xml.ChildNodes)                                     //���������б�
            {
                tar = Convert.ToInt32(edge.Attributes.GetNamedItem("Target").Value) - intNumOffset;//����Ŀ��ڵ�
                value = Convert.ToDouble(edge.InnerText);                           //��������Ȩ��
                newNode.AddEdge(tar, value);                                        //��������
            }
            this.node = newNode;
        }
        
        //���ڵ����ݱ���Ϊxml��ʽ
        XmlElement IfPlatform.XMLoutput(ref XmlDocument doc)
        {
            XmlElement curNode = doc.CreateElement("Node");
            XmlElement degree_xml, x_xml, y_xml, edges_xml;
            XmlText deg_txt, x_txt, y_txt;

            curNode.SetAttribute("num", this.node.Number.ToString());                   //���������Ե�TagԪ��
            //�ڵ��
            degree_xml = doc.CreateElement("Degree");
            //�ڵ�λ��
            x_xml = doc.CreateElement("Xpos");
            y_xml = doc.CreateElement("Ypos");
            //�ڵ�����
            edges_xml = doc.CreateElement("Edges");

            deg_txt = doc.CreateTextNode(this.node.Degree.ToString());               //���������Ե��ı�Ԫ��
            x_txt = doc.CreateTextNode(this.node.Location.X.ToString());
            y_txt = doc.CreateTextNode(this.node.Location.Y.ToString());


            degree_xml.AppendChild(deg_txt);                                    //������Ԫ�ظ����ı�����
            x_xml.AppendChild(x_txt);
            y_xml.AppendChild(y_txt);

            curNode.AppendChild(degree_xml);                                   //��ǰ�ڵ��м�������Խڵ�
            curNode.AppendChild(x_xml);
            curNode.AppendChild(y_xml);

            foreach (Edge edge in this.node)                    //�������������߽ڵ�
            {
                edges_xml.AppendChild(edge.XMLItem(ref doc));
            }
            curNode.AppendChild(edges_xml);
            return curNode;
        }
    }
}
