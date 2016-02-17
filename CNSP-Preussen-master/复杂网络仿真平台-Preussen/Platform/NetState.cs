using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNSP.Platform
{
    public class NetState
    {
        string strType;			//网络类型(有向 无向)
        float sngAveDeg;        //网络平均度
        int intMaxDeg;          //网络最大度
        int intMinDeg;          //网络最小度
        string strMaster;       //最大节点列表
        public int[] intDegDist;        //网络度分布

        public float AveDeg
        {
            get
            {
                return sngAveDeg;
            }
            set
            {
                sngAveDeg = value;
            }
        }
        public int MaxDeg
        {
            get
            {
                return intMaxDeg;
            }
            set
            {
                intMaxDeg = value;
            }
        }
        public int MinDeg
        {
            get
            {
                return intMinDeg;
            }
            set
            {
                intMinDeg = value;
            }
        }
        public string Type
        {
            get
            {
                return strType;
            }
            set
            {
                strType = value;
            }
        }
        public string Master
        {
            get
            {
                return strMaster;
            }
            set
            {
                strMaster = value;
            }
        }

        public NetState()
        {

        }

        public void Update()
        {

        }
    }
}
