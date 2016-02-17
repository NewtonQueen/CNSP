using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Xml;
using CNSP.Platform;
using CNSP.Core;

namespace CNSP.Platform.Paint
{
    public class DefaultStrategy :IfPaintStrategy//Ĭ����������㷨
    {
        StyleSet NetStyle;   //����ʹ�õ���ʽ��
        dNet curNetwork;
        //����
        StyleSet IfPaintStrategy.PaintStyle
        {
            get
            {
                return NetStyle;
            }
        }
        SortedList<int, Image> IfPaintStrategy.Images
        {
            get
            {
                return curNetwork.SharedImages;
            }
        }
        //���캯���������û���ǰʹ�õ���ʽ��
        public DefaultStrategy(StyleSet GlobalStyle)
		{
            NetStyle = GlobalStyle;
		}

        //����������ʽ��
        void IfPaintStrategy.UpdateStyle(StyleSet GlobalStyle)
        {
            if (GlobalStyle != null)
            {
                NetStyle = GlobalStyle;
            }
        }

        //��������ڵ�����
        void IfPaintStrategy.UpdateLocation(XmlDocument doc)
        {
            if (doc != null)
            {
                curNetwork = new dNet(doc);
            }
        }

        //ˢ������ͼƬ�б�
        void IfPaintStrategy.UpdateImage()
        {
            PaintParameter curNodePara;
            Image IRet;
            int index;

            //����ÿ���ڵ�Ļ��Ʋ���
            foreach (dNode curNode in curNetwork.Network)
            {
                curNodePara = new PaintParameter(curNode.Number, curNode.Degree, curNetwork.MaxDeg, curNetwork.MinDeg);
                curNode.Offset = new Point(curNodePara.x, curNodePara.y);
            }
            //����ÿ����������ͼƬ
            foreach (KeyValuePair<int, int> img in curNetwork.DegreeList)
            {
                curNodePara = new PaintParameter(img.Key, img.Key, curNetwork.MaxDeg, curNetwork.MinDeg);
                IRet = this.DrawNode(curNodePara, false);
                index = img.Key;
                curNetwork.SharedImages.Remove(index);
                curNetwork.SharedImages.Add(index, IRet);
            }
        }

        //��������ڵ㣬������Ʋ������Ƿ����
        Image DrawNode(PaintParameter curNodePara, Boolean isHL)
        {
            Pen frame;					//��ʾ���� �߿򻭱�
            Image img;                  //����Image
            Graphics gGraphic;      //����Ŀ��ͼԪ
            GraphicsPath path;  //·��ͼ��
            PathGradientBrush pthGrBrush;   //·������
            int intRand;                    //�뾶

            intRand = curNodePara.intRand;
            //�½�λͼ����Žڵ�ͼ��
            img = new Bitmap(intRand * 2 + 1, intRand * 2 + 1);
            gGraphic = Graphics.FromImage(img);
            gGraphic.SmoothingMode = NetStyle.SmoothMode;//ƽ������
            //����Ч������
            path = new GraphicsPath();
            path.AddEllipse(0, 0, intRand * 2, intRand * 2);
            pthGrBrush = new PathGradientBrush(path);
            pthGrBrush.CenterColor = Color.FromArgb(255, 255, 255, 255);
            pthGrBrush.CenterPoint = new Point(Convert.ToInt32(2 * intRand * 0.618), Convert.ToInt32(intRand * 0.618));
            if (isHL == true)
            {//�����ڵ�ʹ�ø�������ɫ�ͱ߿�
                frame = new Pen(NetStyle.HLFrameColor);
                pthGrBrush.SurroundColors = new Color[] { NetStyle.HLBackColor };
            }
            else
            {//��ͨ�ڵ�ʹ����ͨ����ɫ�ͱ߿�
                frame = new Pen(NetStyle.FrameColor);
                pthGrBrush.SurroundColors = new Color[] { NetStyle.BackColor };
            }
            //���Բ��
            gGraphic.FillEllipse(pthGrBrush, 0, 0, intRand * 2, intRand * 2);
            //��Χ�߿����
            gGraphic.DrawEllipse(frame, 0, 0, 2 * intRand, 2 * intRand);
            return img;
        }
        
        //��Ż��ƺ����������ţ���ʼ�㣬Ŀ��ͼԪ
        void DrawString(string strNum, Point potStart, ref Graphics GraCam, Boolean isHL)
        {            
        	SolidBrush fore;				//��ʾ���� ����ɫˢ

            //���ɶ�Ӧǰ��ɫ��ˢ
            if (isHL == true)
            {
                fore = new SolidBrush(NetStyle.HLForeColor);
            }
            else
            {
                fore = new SolidBrush(NetStyle.ForeColor);
            }
			//�ַ�����
            GraCam.DrawString(strNum, NetStyle.charFont, fore, potStart.X, potStart.Y);
            fore.Dispose();
        }

        //��������ṹͼ������Ŀ��ͼԪ���͸����ڵ��ţ�Ĭ��Ϊû�У�
        void IfPaintStrategy.Draw(ref Graphics GraCam, int intExclude)//
        {
            int intTarget, intRadiusSource, intRadiusTarget;
            Image curImg;
            Point potStart;
            dNode tarNode;
            //��������
            foreach(dNode curNode in curNetwork.Network)
            {
                foreach (Edge edge in curNode)
                {
                    intTarget = edge.Target;
                    if (curNode.Number == intExclude || intTarget == intExclude)//��ѡ�еĽڵ����߲��û�
                    {
                        continue;
                    }
                    tarNode = curNetwork.Network[intTarget];
                    //��ʼ�ڵ�İ뾶
                    intRadiusSource = curNetwork.SharedImages[curNode.Degree].Width;
                    intRadiusSource = (intRadiusSource - 1) / 2;
                    //Ŀ��ڵ�İ뾶
                    intRadiusTarget = curNetwork.SharedImages[tarNode.Degree].Width;
                    intRadiusTarget = (intRadiusTarget - 1) / 2;
                    //������ڵ㴦��ͬһ��λ�ã��򲻻������߱�֤detX��detY��ͬʱΪ0
                    if ((curNode.Location.X == tarNode.Location.X)
                        && (curNode.Location.Y == tarNode.Location.Y))
                    {
                        continue;
                    }
                    DrawLine(ref GraCam, curNode.Location, intRadiusSource,
                                    tarNode.Location, intRadiusTarget, (int)Math.Ceiling(edge.Value));
                }
            }
            //���ƽڵ�
            foreach (dNode curNode in curNetwork.Network)
            {
                if (curNode.Number == intExclude)
                {
                    continue;
                }
                curImg = curNetwork.SharedImages[curNode.Degree];
                GraCam.DrawImage(curImg,
                                    new Point(curNode.Location.X - curImg.Width / 2,
                                                curNode.Location.Y - curImg.Height / 2));
                potStart = new Point(curNode.Location.X - curNode.Offset.X,
                                                curNode.Location.Y - curNode.Offset.Y);
                this.DrawString(curNode.Number.ToString(), potStart, ref GraCam, false);
            }
        }

        //�������ߺ���
        void DrawLine(ref Graphics GraCam, Point LocSource, int iRadiusSource, Point LocTarget, int iRadiusTarget, int iValue)
        {
            Pen LinePen;
            Point NewSource, NewTarget;

            LinePen = new Pen(Brushes.Gray);
            //���߿�ȣ���ʱΪȨ�أ��Ժ���չ
            LinePen.Width = iValue;
            //��ͷ
            if (curNetwork.Type == "����ͼ")
            {
                LinePen.CustomEndCap = new AdjustableArrowCap(3, 3, true);
            }
            //���������������յ㷽���ƶ�iRadiusSource����
            NewSource = LocationModify(LocSource, LocTarget, iRadiusSource);
            //������յ���������㷽���ƶ�iRadiusTarget����
            NewTarget = LocationModify(LocTarget, LocSource, iRadiusTarget);
            GraCam.DrawLine(LinePen, NewSource, NewTarget);
            LinePen.Dispose();
        }

        //����������������
        Point LocationModify(Point LocSource, Point LocTarget, int iRadiusSource)
        {
            double dubDistance;
            int detX, detY, offsetX, offsetY;

            //����������X��Y���������������ţ���Ҫȡ����ֵ��
            detX = LocTarget.X - LocSource.X;
            detY = LocTarget.Y - LocSource.Y;
            //�����������ȣ����Ǿ���ֵ
            dubDistance = Math.Sqrt(Math.Pow(detX, 2) + Math.Pow(detY, 2));
            //���ݱ����������̵İ뾶����ΪX,Y�����ϵķ��� x = r * (dx / D)
            offsetX = Convert.ToInt32(iRadiusSource * detX / dubDistance);
            offsetY = Convert.ToInt32(iRadiusSource * detY / dubDistance);
            //ƫ�ƹ�����������޸ĺ��������
            return new Point(LocSource.X + offsetX, LocSource.Y + offsetY);
        }

        //�����ڵ���ƺ���
        public void DrawHighLightNode(int iNum, ref Graphics GraCam)
        {
            Image img;
            PaintParameter curNodePara;
            Point potStart;
            dNode curNode = curNetwork.Network[iNum];

            //����������Ʋ���
            curNodePara = new PaintParameter(iNum, curNode.Degree, curNetwork.MaxDeg, curNetwork.MinDeg);
            //��ȡ������ɵ�ͼƬ
            img = this.DrawNode(curNodePara, true);
            //��ͼԪ��Ӧλ�û���ͼƬ
            GraCam.DrawImage(img, new Point(curNode.Location.X - img.Width / 2, curNode.Location.Y - img.Height / 2));
            //�����Ż������
            potStart = new Point(curNode.Location.X - curNode.Offset.X, curNode.Location.Y - curNode.Offset.Y);
            //���ƽڵ���
            this.DrawString(iNum.ToString(), potStart, ref GraCam, true);
        }

        //���Ƹ����ڵ�����������
        void IfPaintStrategy.DrawHighLightNodeEdge(int iNum, Point newLoc, ref Graphics GraCam)
        {
            int intRadiusSource, intRadiusTarget;
            dNode curNode = curNetwork.Network[iNum];

            curNode.Location = newLoc;
            //��ʼ�ڵ�İ뾶
            intRadiusSource = curNetwork.SharedImages[curNode.Degree].Width;
            intRadiusSource = (intRadiusSource - 1) / 2;
            foreach (Edge edge in curNode)
            {
                dNode tarNode = curNetwork.Network[edge.Target];
                //Ŀ��ڵ�İ뾶
                intRadiusTarget = curNetwork.SharedImages[tarNode.Degree].Width;
                intRadiusTarget = (intRadiusTarget - 1) / 2;
                //��ʼ�ڵ㵽Ŀ�������
                DrawLine(ref GraCam,
                               curNode.Location, intRadiusSource,
                               tarNode.Location, intRadiusTarget,
                               (int)Math.Ceiling(edge.Value));
                if (curNetwork.Type == "����ͼ")
                {
                    //Ŀ��㵽��ʼ�ڵ�����
                    DrawLine(ref GraCam,
                                    tarNode.Location, intRadiusTarget,
                                   curNode.Location, intRadiusSource,
                                   (int)Math.Ceiling(edge.Value));
                }
            }
            if (curNetwork.Type == "����ͼ")
            {
                foreach (dNode tarNode in curNetwork.Network)
                {
                    if (tarNode.Contains(iNum) == true)
                    {
                        //Ŀ��ڵ�İ뾶
                        intRadiusTarget = curNetwork.SharedImages[tarNode.Degree].Width;
                        intRadiusTarget = (intRadiusTarget - 1) / 2;
                        //Ŀ��ڵ㵽��ʼ�ڵ������
                        DrawLine(ref GraCam,
                                       tarNode.Location, intRadiusTarget,
                                       curNode.Location, intRadiusSource,
                                       (int)Math.Ceiling(tarNode.GetWeight(iNum)));
                    }
                }
            }
            //���Ƹ����ڵ�
            DrawHighLightNode(iNum, ref GraCam);
        }
    }
}
