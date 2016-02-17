using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNSP.KeyWord
{
    public interface IfKeyWord//关键词平台节点接口
    {
        int Number { get;}
        string Word { get;}
        string Type { get;}
        int Position { get;}
        int Line { get; }
    }
}
