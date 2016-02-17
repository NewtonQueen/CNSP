using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CNSP.Platform.Paint
{
    public class PaintParameter//网络绘制输入参数类
    {
        public int intRand;         //节点半径
        public int intOffset;       //编号绘制偏置
        public int intUnit;         //字体size
        public int x;                   //编号起点x坐标
        public int y;                   //编号起点y坐标
        public int intNum;          //节点编号
        private int intDegree;      //节点度
        private int intMaxDeg;      //网络最大度
        private int intMinDeg;      //网络最小度
        private float intFactor;     //节点半径最小单位

        //构造函数，输入节点编号，度，网络最大和最小度
        public PaintParameter(int iNum, int iDegree, int iMax, int iMin)
        {
            intNum = iNum;
            intDegree = iDegree;
            intMinDeg = iMin;
            intMaxDeg = iMax;
            CalParameter();
        }

        //绘制用参数计算
        private void CalParameter()
        {
            //首先对基本参数进行计算
            intFactor = (intMaxDeg - intMinDeg) * 1.0F / 30;//计算比例系数
            if (intMaxDeg == intMinDeg)
            {
                intFactor = intMaxDeg * 1.0F / 30;
            }
            intUnit = Convert.ToInt32(SystemFonts.DefaultFont.Size);
            intOffset = Convert.ToInt32(Math.Floor(Math.Log10(intNum+1)));
            intRand = Convert.ToInt32(Math.Round((intDegree - intMinDeg) / intFactor + 7));
            //如果半径过大或过小则加以限制
            if (intRand < 7)
            {
                intRand = 7;
            }
            else if (intRand > 70)
            {
                intRand = 70;
            }
            //求出字符的起始位置
            x = intOffset * intUnit / 2 + 4;
            y = intUnit / 2 + 2;
        }

    }
}
