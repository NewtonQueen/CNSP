using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CNSP.Platform.Paint
{
    public class PaintParameter//����������������
    {
        public int intRand;         //�ڵ�뾶
        public int intOffset;       //��Ż���ƫ��
        public int intUnit;         //����size
        public int x;                   //������x����
        public int y;                   //������y����
        public int intNum;          //�ڵ���
        private int intDegree;      //�ڵ��
        private int intMaxDeg;      //��������
        private int intMinDeg;      //������С��
        private float intFactor;     //�ڵ�뾶��С��λ

        //���캯��������ڵ��ţ��ȣ�����������С��
        public PaintParameter(int iNum, int iDegree, int iMax, int iMin)
        {
            intNum = iNum;
            intDegree = iDegree;
            intMinDeg = iMin;
            intMaxDeg = iMax;
            CalParameter();
        }

        //�����ò�������
        private void CalParameter()
        {
            //���ȶԻ����������м���
            intFactor = (intMaxDeg - intMinDeg) * 1.0F / 30;//�������ϵ��
            if (intMaxDeg == intMinDeg)
            {
                intFactor = intMaxDeg * 1.0F / 30;
            }
            intUnit = Convert.ToInt32(SystemFonts.DefaultFont.Size);
            intOffset = Convert.ToInt32(Math.Floor(Math.Log10(intNum+1)));
            intRand = Convert.ToInt32(Math.Round((intDegree - intMinDeg) / intFactor + 7));
            //����뾶������С���������
            if (intRand < 7)
            {
                intRand = 7;
            }
            else if (intRand > 70)
            {
                intRand = 70;
            }
            //����ַ�����ʼλ��
            x = intOffset * intUnit / 2 + 4;
            y = intUnit / 2 + 2;
        }

    }
}
