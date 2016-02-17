using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using CNSP.Core;
using System.Xml;

namespace CNSP.Platform
{
    public interface IfPlatform//平台功能接口
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
        void XMLinput(XmlElement xNode, int intNumOffset); //intNumOffset用于区分版本，如果等于0则代表新版本，编号从0开始，如果为1，代表老版本，编号从1开始。
    }
}
