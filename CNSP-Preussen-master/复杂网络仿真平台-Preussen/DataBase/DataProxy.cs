using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Text;
using System.IO;

namespace CNSP.DataBase
{
    class DataProxy//数据库底层代理，将数据从文件读入内存，用XML格式传递
    {
        //读取指定路径XML文件中所有记录，并以xml元素列表形式返回
        public List<XmlElement> ReadAll(string sPath)
        {
            return ReadFromTo(sPath, 0);
        }

        //读取指定路径XML文件中指定索引的记录，并以xml元素形式返回
        public XmlElement ReadIndexOf(string sPath, int index)
        {
            List<XmlElement> Result;

            Result = ReadFromTo(sPath, index, index);
            if (Result == null)
            {
                return null;
            }
            return Result[0];
        }

        //读取记录从iStart读到iEnd,如果iEnd空缺，则默认读到底
        public List<XmlElement> ReadFromTo(string sPath, int iStart, int iEnd = -1)
        {
            XmlDocument doc;
            XmlNode xmlroot;
            List<XmlElement> Result;
            int intCount;

            if(iStart < 0 )
            {
                return null;
            }
            //调用成员函数读取xml文档
            doc = Read(sPath);
            if (doc == null)
            {
                return null;
            }
            Result = new List<XmlElement>();
            //找到access导出xml中固定的dataroot节点
            xmlroot = doc.SelectSingleNode("dataroot");
            if (xmlroot == null)
            {
                return null;
            }
            intCount = 0;
            if (iEnd < iStart)
            {
                iEnd = xmlroot.ChildNodes.Count - 1;
            }
            //遍历该节点的所有直接子节点，依次加入返回值列表
            foreach (XmlElement xmlNode in xmlroot.ChildNodes)
            {
                if (intCount < iStart || intCount > iEnd)
                {
                    intCount++;
                    continue;
                }
                Result.Add(xmlNode);
                intCount++;
            }
            if (Result.Count == 0)
            {
                return null;
            }
            return Result;
        }

        //将XML文档读入内存
        public XmlDocument Read(string sPath)
        {
            FileStream stream = null;
            XmlDocument doc = new XmlDocument();

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
            return doc;
        }
        
        //保存所有数据到xml文档
        int SaveAll(string sPath, List<XmlElement> xData)
        {
            int intRet = 0;

            return intRet;
        }
        
        //保存数据到指定位置
        int SaveIndexOf(string sPath, int index, XmlElement xData)
        {
            int intRet = 0;

            return intRet;
        }

        //将XML对象保存到文件
        public int Save(string sPath, XmlDocument doc)
        {
            FileStream stream = null;

            try
            {
                //新建数据流
                stream = new FileStream(sPath, FileMode.Create);
                //保存xml文档到流
                doc.Save(stream);     
                //关闭数据流
                stream.Close();
            }
            catch (Exception ex)
            {
                if (stream != null)
                {
                    ex.ToString();
                    stream.Dispose();
                }
                return -1;
            }
            stream.Dispose();
            return 0;
        }
    }
}
