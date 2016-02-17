using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CNSP.DataBase
{
    public class InvalidWordProxy
    {
        const string strTablePath = "Data/KeyWord/tabInvalidWord.xml";
        DataProxy dbHandler;

        //读取所有停用词记录，并以string列表形式返回
        public List<string> ReadAll()
        {
            List<XmlElement> Result;
            List<string> WordList;

            //新建数据库读写代理对象
            dbHandler = new DataProxy();
            //获取路径下文件所有数据
            Result = dbHandler.ReadAll(strTablePath);
            if (Result == null)
            {
                return null;
            }
            WordList = new List<string>();
            //将xml节点中数据提取，并保存在list中
            foreach (XmlElement xmlNode in Result)
            {
                WordList.Add(xmlNode.LastChild.InnerText);
            }
            return WordList;
        }

    }
}
