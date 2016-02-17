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
    public partial class DiaNodeInfo : Form//节点信息显示窗体
    {
        private FrmMain father;
        public DiaNodeInfo(FrmMain owner)
        {
            InitializeComponent();
            //设置FrmMain为父窗体，可以读取父窗体数据
            father = owner;
        }

        private void DiaNodeInfo_Load(object sender, EventArgs e)
        {
            int intNum;

            intNum =  father.NodeList .SelectedIndex;
            LoadNodeInfo(intNum);
        }

        //读入节点数据
        private void LoadNodeInfo(int iNum)     //读取节点数据信息
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
            //节点所属连边数据
            foreach (Edge edge in father.ComplexNet.Network[iNum])
            {
                EdgeList.Items.Add("节点:" + edge.Target.ToString() + ",权重:" + edge.Value.ToString());
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            EdgeList.Items.Clear();
            this.Close();
        }
    }
}
