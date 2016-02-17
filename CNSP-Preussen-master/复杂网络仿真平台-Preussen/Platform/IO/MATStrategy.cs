using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Xml;
using CNSP.Core;
using CNSP.Platform;

namespace CNSP.Platform.IO
{
    public class MATStrategy:IfIOStrategy//mat�ļ���д�㷨
    {
        const int intHeaderOffet = 128;
        const int intTextOffset = 116;
        const int intSubSystemOffset = 8;
		const int intMatrixType = 0x0E;
        const string strEncoding = "unicode";
        const string strInfoHeader = "MATLAB 5.0 MAT-file, Platform: PCWIN, Created on: ";
        byte[] bytHeadFlag = new byte[] { 0x00, 0x01, 0x49, 0x4D };
        byte[] bytDataFlag1 = new byte[] { 0x06, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00,
                                                            0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 
                                                            0x05, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00,
                                                            };
        byte[] bytDataFlag2 = new byte[] { 0x01, 0x00, 0x03, 0x00, 0x6E, 0x65, 0x74, 0x00,
                                                            0x02, 0x00, 0x00, 0x00 };

        /*
         * Function: ReadFile
         * Description:MATStrategy�㷨��ȡ����
         * Parameters:
         *      string sPath �ļ�·��
         *      StyleSet pStyle ������ʽ��
         * Return Value:cNet
         */
        cNet IfIOStrategy.ReadFile(string sPath)
        {
            int intType, intNum;
            cNet NewNet = null;
            Byte[,] bytMatrix;
            FileStream FS = null;
            BinaryReader Br = null;
            //�ļ�ϵͳ������
            FS = new FileStream(sPath, FileMode.Open);
            if (FS == null)
            {
                return null;
            }
            //�����ƶ�д������
            Br = new BinaryReader(FS, Encoding.ASCII);
            if (Br == null)
            {
                return null;
            }
            //��ȡ�ļ�ͷ
            Br.ReadBytes(intHeaderOffet);
            //ѭ����ȡ����Ԫ��
            while(Br.BaseStream.Position < Br.BaseStream.Length)
            {
                //����Ԫ������ 4Byte
            	intType = Br.ReadInt32();
                //���ݳ������� 4Byte
            	intNum = Br.ReadInt32();
            	if(intType == intMatrixType)
            	{//��������Ǿ���Ŷ��룬����������һ������Ԫ�ؿ�
            		if((Br.BaseStream.Length - Br.BaseStream.Position) >= intNum)
            		{
            			bytMatrix = DataInterpret(Br);
            			if(bytMatrix == null)
            			{
            				break;
            			}
            			NewNet = BuileNetwork(bytMatrix);
            		}
            		break;
            	}	//��Ԫ���ļ�ֻȡ��һ������
                Br.ReadBytes(intNum);
            }
            Br.Close();
            FS.Close();
            Br.Dispose();
            FS.Dispose();
            return NewNet;
        }
        /*
         * Function: DataInterpret
         * Description:Data���ݿ����������ת��Ϊ�ڽ�����
         * Parameters:
         *      BinaryReader Br     �������ļ�
         * Return Value:Byte[,]
         */
        Byte[,] DataInterpret(BinaryReader Br)
        {
        	int intType, intNum, intPad, intPointer;
        	int intRow, intCol, intData, i, j;
        	short sType, sNum;
        	Byte[] bytRead = null;
        	Byte[,] bytMatrix = null;
         	
			//1.Array Flags:Type(4) + Length(4) + Data(Length)
			intType = Br.ReadInt32();
            intNum = Br.ReadInt32();
            bytRead = Br.ReadBytes(intNum);
			//2.Dimensions:Type(4) + Length(4) + Data(Length)
			intType = Br.ReadInt32();
            intNum = Br.ReadInt32();
            intRow = Br.ReadInt32();
            intCol = Br.ReadInt32();
            intData = intRow * intCol;
			//3.Name:Type(2) + Length(2) + Data(Length)
			sType = Br.ReadInt16();
			sNum =Br.ReadInt16();
            bytRead = Br.ReadBytes((int)sNum);
			intPad = Padding((int)sNum, 4);
			if(intPad > 0)
			{
                Br.ReadBytes(intPad);
			}
			//4.Data:Type(4) + Length(4) + Data(Length)
			do
			{
				intType = Br.ReadInt32();
	            intNum = Br.ReadInt32();
                bytRead = Br.ReadBytes(intNum);
				intPad = Padding(intNum, 8);
				if(intPad > 0)
				{
                    Br.ReadBytes(intPad);
				}
				if(intNum == intData)
				{//if intNum == intData, this block is the matrix
					break;
				}
			}while(Br.BaseStream.Position < Br.BaseStream.Length);
			if(intNum == intData)
			{
				intPointer = 0;
				bytMatrix = new Byte[intRow, intCol];
				for(i = 0; i < intRow; i++)
				{
					for(j = 0; j<intCol; j++)
					{
						bytMatrix[i, j] = bytRead[intPointer];
						intPointer++;
					}
				}
			}
			return bytMatrix;
        }
        /*
         * Function: Padding
         * Description:���ݶβ��뺯��
         * Parameters:
         *      int iNum    ԭʼ����
         *      int iBase     ���ݿ���򳤶�
         * Return Value:cNet
         */
        int Padding(int iNum, int iBase)
        {
        	int intPad;

			if(iNum % iBase == 0)
			{
				return 0;
			}
        	intPad = iBase - iNum % iBase;
        	return intPad;
        }
        /*
         * Function: BuileNetwork
         * Description:MATStrategy�㷨��ȡ����
         * Parameters:
         *      Byte[,] bytMatrix ���ڽӾ�������cNet����
         *      StyleSet pStyle ������ʽ��
         * Return Value:cNet
         */
        cNet BuileNetwork(Byte[,] bytMatrix)
		{
			cNet NewNet;
			IfPlatform NewNode;
			int intRow, intCol, i, j;

            intRow = bytMatrix.GetLength(0);
			intCol = bytMatrix.GetLength(1);
			
			NewNet = new cNet(intRow);
			for(i = 0; i < intRow; i++)
			{
				NewNode = new cNode(i);
				for(j = 0; j<intCol; j++)
				{
					if(bytMatrix[i, j] != 0)
					{
						NewNode.AddEdge(j, (double)bytMatrix[i, j]);
					}
				}
				NewNet.Network.Add(NewNode);
			}
            if (NewNet.intNumber == 0)
            {
                return null;
            }
            return NewNet;
		}
        /*
         * Function: SaveFile
         * Description:MATStrategy�㷨д�뺯��
         * Parameters:
         *      string sPath �ļ�·��
         *      XmlDocument doc  ��д��xml����
         * Return Value:cNet
         */
        void IfIOStrategy.SaveFile(XmlDocument doc, string sPath)
        {
            FileStream FS = null;
            BinaryWriter Wr = null;

            FS = new FileStream(sPath, FileMode.Create);
            if (FS == null)
            {
                return;
            }
            Wr = new BinaryWriter(FS, Encoding.Unicode);
            if (Wr == null)
            {
                return;
            }
            //1.Format the Header
            HeaderFormat(Wr);
            //2.Matrix to Memory
            DataFormat(Wr, doc);
            Wr.Close();
            FS.Close();
            Wr.Dispose();
            FS.Dispose();
            return;
        }
        /*
         * Function: HeaderFormat
         * Description:mat�ļ��ļ�ͷд�뺯��
         * Parameters:
         *      BinaryWriter Wr     �������ļ�
         * Return Value:
         */
        void HeaderFormat(BinaryWriter Wr)
		{
            Byte[] bytWrite;
            string strWrite;
            DateTime datCreate;
            int intNum, intPad;

            datCreate = System.DateTime.Now;
            strWrite = strInfoHeader;
            strWrite += datCreate.ToString("ddd MMM dd HH:mm:ss yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            bytWrite = Encoding.Default.GetBytes(strWrite);
            intNum = Encoding.Default.GetByteCount(strWrite);
            Wr.Write(bytWrite);
            intPad = Padding(intNum, intTextOffset);
            bytWrite = Enumerable.Repeat((byte)0x20, intPad).ToArray();
            Wr.Write(bytWrite);
            bytWrite = Enumerable.Repeat((byte)0x20, intSubSystemOffset).ToArray();
            Wr.Write(bytWrite);
            Wr.Write(bytHeadFlag);
		}
        /*
         * Function: DataFormat
         * Description:MAT��������д�뺯��
         * Parameters:
         *      BinaryWriter Wr     �������ļ�
         *      XmlDocument doc XML�ļ�
         * Return Value:
         */
        void DataFormat(BinaryWriter Wr, XmlDocument doc)
		{
            Byte[] bytWrite, bytMatrix;
            int intWrite, intPad, intLength;

            bytMatrix = XMLtoMatrix(doc);
            if (bytMatrix == null)
            {
                return;
            }
            intWrite = bytDataFlag1.Length + 8 + bytDataFlag2.Length + 4 + bytMatrix.Length;
            //0E 00 00 00 -- Type Matrix
            Wr.Write(intMatrixType);
            //xx 00 00 00 -- Data Length
            Wr.Write(intWrite);
            //DataFlags1
            Wr.Write(bytDataFlag1);
            //Row Col
            intLength = (int)Math.Sqrt(bytMatrix.Length);
            Wr.Write(intLength);
            Wr.Write(intLength);
            //DataFlags2
            Wr.Write(bytDataFlag2);
            //XX 00 00 00  --Matrix Length
            intWrite = bytMatrix.Length;
            Wr.Write(intWrite);
            //Matrix
            Wr.Write(bytMatrix);
            intPad = Padding(intWrite, 8);
            bytWrite = Enumerable.Repeat((byte)0x0, intPad).ToArray();
            //Padding
            Wr.Write(bytWrite);
		}
        /*
         * Function: XMLtoMatrix
         * Description:XML�ļ�תΪ����
         * Parameters:
         *      XmlDocument doc
         * Return Value:Byte
         */
        Byte[] XMLtoMatrix(XmlDocument doc)
        {
            Byte[] bytWrite;
            Byte[,] bytMatrix;
            XmlNodeList Nodelist;
            XmlNode xmlroot, edges_xml;
            int intSize, intRow, intCol, intSource, intTarget, intPointer,i, j;
            Byte bytValue;

            xmlroot = doc.ChildNodes.Item(0);
            Nodelist = xmlroot.ChildNodes;                                             //��ȡ�ڵ��б�
            intCol = Nodelist.Count;
            intRow = intCol;
            intSize = intRow * intCol;
            bytWrite =new Byte[intSize];
            bytMatrix = new Byte[intRow, intCol];
            foreach(XmlElement curNode in Nodelist)                                            
            {
                intSource = Convert.ToInt32(curNode.Attributes.GetNamedItem("num").Value);
                edges_xml = null;
                foreach (XmlNode xNode in curNode.ChildNodes)       //�ڵ�λ������
                {
                    if (xNode.Name == "Edges")//��ȡ�����б�
                    {
                        edges_xml = xNode;
                    }
                }
                if (edges_xml == null)
                {
                    return null;
                }
                foreach (XmlNode edge in edges_xml.ChildNodes)                                     //���������б�
                {
                    intTarget = Convert.ToInt32(edge.Attributes.GetNamedItem("Target").Value);//����Ŀ��ڵ�
                    bytValue = Convert.ToByte((int)Math.Ceiling(Convert.ToDouble(edge.InnerText)));                           //��������Ȩ��
                    bytMatrix[intSource, intTarget] = bytValue;
                }
            }
            intPointer = 0;
            for (i = 0; i < intRow; i++)
            {
                for (j = 0; j < intCol; j++)
                {
                    bytWrite[intPointer] = bytMatrix[i, j];
                    intPointer++;
                }
            }
            return bytWrite;
        }
    }
}
