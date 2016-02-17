using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CNSP.Core;
using System.Xml;

namespace CNSP.Platform
{
    public interface IfPlatform//ƽ̨���ܽӿ�
    {
        int Number { get; }
        int Degree { get; }
        Point Location { get; set; }
        bool AddEdge(int iTarget, double iValue);
        bool DecEdge(int iTarget);
        bool Contains(int iTarget);
        double GetWeight(int iTarget);
        NodeEnumerator GetEnumerator();
        XmlElement XMLoutput(ref XmlDocument doc);
        void XMLinput(XmlElement xNode, int intNumOffset); //intNumOffset�������ְ汾���������0������°汾����Ŵ�0��ʼ�����Ϊ1�������ϰ汾����Ŵ�1��ʼ��
    }
}
