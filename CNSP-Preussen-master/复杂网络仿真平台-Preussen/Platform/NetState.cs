using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNSP.Platform
{
    public class NetState
    {
        string strType;			//��������(���� ����)
        float sngAveDeg;        //����ƽ����
        int intMaxDeg;          //��������
        int intMinDeg;          //������С��
        string strMaster;       //���ڵ��б�
        public int[] intDegDist;        //����ȷֲ�

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
