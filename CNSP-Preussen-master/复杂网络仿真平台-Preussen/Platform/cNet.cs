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
    public class cNet//复杂网络类
    {      
        public List<IfPlatform> Network; //网络节点集合
        public int intNumber;           //节点总数
        public int intEdge;             //连边总数
        //私有变量区
        public NetState netState;
        public IfIOStrategy IOhandle;   //输入输出对象
        public IfPaintStrategy NetPainter;              //网络绘制算法对象

        //属性///////////////////////////////////////
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
        //方法///////////////////////////////////////
        public cNet(int intNum)//外部构造函数
        {
            intNumber = intNum;
            intEdge = 0;
            Network = new List<IfPlatform>();    //节点数组长度重定义
            netState = new NetState();
        }

        //网络初始化，在加入所有节点之后执行一次
        public void Initialized(StyleSet PaintStyle)
        {
            NetworkType();//网络类型分析
            DegreeStat();//节点度统计
            switch (PaintStyle.Sharp)
            {
                case StyleSet.sharp.Round:
                    NetPainter = new DefaultStrategy(PaintStyle);
                    break;
            }
            NetPainter.UpdateLocation(this.ToXML());//节点坐标刷新
            NetPainter.UpdateImage();//节点图像刷新
        }

        //网络类型分析函数，确定网络是否有向
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
                        netState.Type = "有向图";
                        return;
                    }
                }
            }
            netState.Type = "无向图";
            return;
        }

        //节点度统计函数，最大度，最小度，度列表
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
            //找出最大和最小度
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
            //计算网络平均度
            sngAveDeg = intTotal / intNumber;

            if (netState.Type == "有向图")
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

        //新增单条连边函数，提供两端点编号与权重
        public void AddEdge(int iNum, int iTarget, double dValue)
        {
            bool a, b;
            if (iNum != iTarget)//两端点不同
            {
                a = Network[iNum].AddEdge(iTarget, dValue);//分别调用两个节点的成员函数，实现加边。
                b = Network[iTarget].AddEdge(iNum, dValue);
                if (a == true && b == true)//两次调用都成功则将总边数+1
                {
                    intEdge += 1;
                }
                else
                {
                    //throw new Exception("在节点" + iNum.ToString() + "," + iTarget.ToString() + "之间无法正常加边。");
                }
            }
        }

        //去除连边，提供两端点编号
        public void DecEdge(int iNum, int iTarget)
        {
            if (netState.Type == "有向图")
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
        
        //绘制网络结构图，输入目标图元，和高亮节点编号（默认为没有）
        public void Draw(ref Graphics GraCam, int intExclude = -1)//
        {
            NetPainter.Draw(ref GraCam, intExclude);
        }

        //绘制高亮节点和其相关连边
        public void DrawHighLightNodeEdge(int iNum, Point newLoc, ref Graphics GraCam)
        {
            NetPainter.DrawHighLightNodeEdge(iNum, newLoc, ref GraCam);
        }
        
        //更新网络样式集，并刷新节点图片列表
        //public void UpdateStyle(StyleSet GlobalStyle)
        //{
        //    if (GlobalStyle == null)
        //    {
        //        return;
        //    }
        //    //相同样式集则退出
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

        //更新网络样式集，并刷新节点图片列表
        public void UpdateStyle(Object sender, StyleUpdateEventArgs e)
        {
            if (e.NewStyleSet == null)
            {
                return;
            }
            //相同样式集则退出
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

        //刷新网络图片列表
        public void UpdateImage()
        {
            NetPainter.UpdateImage();
        }

        //网络文件读取函数
        public static cNet Read(string sPath,ref Error eRet)
        {
            string strExpand;
            cNet NewNet;
            IfIOStrategy Reader;
			
            //1.获取扩展名
            strExpand = cNet.GetExpandName(sPath).ToLower();
            //2.选定构造算法
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
                    eRet = new Error("文件格式错误");
                    return null;
            }
			
            //3.构造网络
            NewNet = Reader.ReadFile(sPath);
            if (NewNet == null)
            {
                eRet = new Error("文件格式错误");
            }
            else
            {
                eRet = new Error("OK");
            }
            return NewNet;
        }

        //网络保存为文件
        public Error Save(string sPath)
        {
            string strExpand;
            XmlDocument doc;
            IfIOStrategy Saver;

            //1.获取扩展名
            strExpand = GetExpandName(sPath).ToLower();
            //2.选定保存算法
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
                    return new Error("文件格式错误");
            }
            //所有网络数据都保存为xml格式
            doc = this.ToXML();
            Saver.SaveFile(doc, sPath);
            return new Error("OK");
        }

        //文件扩展名获取函数
        private static string GetExpandName(string sName)
        {
            string strExpand;
            int intPos;
            int intLength;

            //切分最后一个.之后的字符串
            intPos = sName.LastIndexOf(".");
            intLength = sName.Length;
            strExpand = sName.Substring(intPos, (intLength - intPos));
            return strExpand;
        }

        //将xml文件转化为网络
        public void XMLtoNet(XmlDocument doc)
        {
            int i;
            XmlNodeList Nodelist;
            XmlNode xmlroot;
            int intNumOffset = 0; 

            xmlroot = doc.ChildNodes.Item(0);
            Nodelist = xmlroot.ChildNodes;                                             //获取节点列表
            i = 0;
            foreach (XmlElement curNode in Nodelist)                                      //遍历节点列表
            {
                if (i == 0)
                {
                    if (curNode.GetAttribute("num").Trim() == "1")
                    {
                        intNumOffset = 1;
                    }
                }
                this.Network[i].XMLinput(curNode, intNumOffset);                           //调用下层函数，生成新节点
                i++;
            }
        }

        public XmlDocument ToXML()
        {
            XmlDocument doc = new XmlDocument();
            //所有网络数据都保存为xml格式
            XmlElement root = doc.CreateElement("Network");
            root.SetAttribute("Nodes", intNumber.ToString());
            root.SetAttribute("Edges", intEdge.ToString());

            foreach(IfPlatform xNode in Network)
            {
                root.AppendChild(xNode.XMLoutput(ref doc));     //循环调用底层节点的输出函数
            }
            doc.AppendChild(root);
            return doc;
        }

    }
}
