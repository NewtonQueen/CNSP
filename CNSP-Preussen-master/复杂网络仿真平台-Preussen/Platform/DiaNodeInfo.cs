using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNSP.Core;
using CNSP.KeyWord;

namespace CNSP.Platform
{
    public partial class DiaNodeInfo : Form//�ڵ���Ϣ��ʾ����
    {
        private FrmMain father;
        public DiaNodeInfo(FrmMain owner)
        {
            InitializeComponent();
            //����FrmMainΪ�����壬���Զ�ȡ����������
            father = owner;
        }

        private void DiaNodeInfo_Load(object sender, EventArgs e)
        {
            int intNum;

            intNum =  father.NodeList .SelectedIndex;
            LoadNodeInfo(intNum);
        }

        //����ڵ�����
        private void LoadNodeInfo(int iNum)     //��ȡ�ڵ�������Ϣ
        {
            int intDegree;
            kNode typeNode = new kNode(0);
            IfKeyWord ShowNode;

            if (father.ComplexNet.Network[iNum].GetType() == typeNode.GetType())
            {
                ShowNode = (IfKeyWord)father.ComplexNet.Network[iNum];
                WordBox.Text = ShowNode.Word;
                TypeBox.Text = ShowNode.Type;
                LineBox.Text = ShowNode.Line.ToString();
                PosBox.Text = ShowNode.Position.ToString();
            }
            NodeNum.Text = father.ComplexNet.Network[iNum].Number.ToString();
            NodeDeg.Text =  father.ComplexNet.Network[iNum].Degree.ToString();
            NodePos.Text =  father.ComplexNet.Network[iNum].Location.ToString();
            intDegree = father.ComplexNet.Network[iNum].Degree;
            NodeImage.Image = father.ComplexNet.NetPainter.Images[intDegree];
            EdgeList.Items.Clear();
            //�ڵ�������������
            foreach (Edge edge in father.ComplexNet.Network[iNum])
            {
                EdgeList.Items.Add("�ڵ�:" + edge.Target.ToString() + ",Ȩ��:" + edge.Value.ToString());
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            EdgeList.Items.Clear();
            this.Close();
        }
    }
}
