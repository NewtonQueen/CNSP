using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using CNSP.Platform;

namespace CNSP.Platform.Paint
{
    public interface IfPaintStrategy//�����㷨�ӿ�
    {
        StyleSet PaintStyle{get;}
        SortedList<int, Image> Images { get; }
        //����������ʽ������ˢ�½ڵ�ͼƬ�б�
        void UpdateStyle(StyleSet GlobalStyle);
        //��������ṹ���ڵ�����
        void UpdateLocation(XmlDocument doc);
        //ˢ������ͼƬ�б�
        void UpdateImage();
        //��������ṹͼ������Ŀ��ͼԪ���͸����ڵ��ţ�Ĭ��Ϊû�У�
        void Draw(ref Graphics GraCam, int intExclude);
        //���Ƹ����ڵ�����������
        void DrawHighLightNodeEdge(int iNum, Point newLoc, ref Graphics GraCam);
    }
}
