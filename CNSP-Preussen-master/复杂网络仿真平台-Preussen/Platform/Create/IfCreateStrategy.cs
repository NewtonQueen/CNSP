using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNSP.Core;
using CNSP.Platform;
using System.Xml;

namespace CNSP.Platform.Create
{
    interface IfCreateStrategy//创建算法功能接口
    {
        cNet Create(CreateParameter cParam);//创建函数，输入用户参数，输出构建完成的平台网络
    }
}
