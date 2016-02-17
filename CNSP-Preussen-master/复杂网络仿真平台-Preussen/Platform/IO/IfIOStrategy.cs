using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNSP.Core;
using CNSP.Platform;
using System.Xml;

namespace CNSP.Platform.IO
{
    public interface IfIOStrategy//文件读写算法接口
    {
        cNet ReadFile(string sPath);
        void SaveFile(XmlDocument doc, string sPath);
    }
}
