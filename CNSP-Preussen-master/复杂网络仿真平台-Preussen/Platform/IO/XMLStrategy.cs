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
    public class XMLStrategy:IfIOStrategy//XML文件读写算法
    {
        /*
         * Function: ReadFile
         * Description:XMLStrategy算法读取函数
         * Parameters:
         *      string sPath 文件路径
         *      StyleSet pStyle 绘制样式集
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
                doc.Load(stream);               //从流文件读入xml文档
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
            Nodelist = xmlroot.ChildNodes;                                             //获取节点列表
            xmltmp = Nodelist[0].ChildNodes[3];
            //创建网络
            NewNet = new cNet(Nodelist.Count);
            for (iNum = 0; iNum < Nodelist.Count; iNum++)
            {
                switch (xmltmp.Name)
                {//区分XML数据类型
                    case "Word"://如果包含Word标签，就是关键词网络文件，生成KNode
                        NewNet.Network.Add(new kNode(iNum));
                        break;
                    default://默认都是cNode
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
         * Description:XMLStrategy算法保存函数
         * Parameters:
         *      string sPath 文件路径
         *      XmlDocument doc 待保存xml数据
         * Return Value:
         */
        void IfIOStrategy.SaveFile(XmlDocument doc, string sPath)
        {
            FileStream stream = null;

            try
            {
                stream = new FileStream(sPath, FileMode.Create);
                doc.Save(stream);               //保存xml文档到流
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
