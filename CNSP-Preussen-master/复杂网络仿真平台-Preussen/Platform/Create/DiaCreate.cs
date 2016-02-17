using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNSP.Platform;
using CNSP.Core;

namespace CNSP.Platform.Create
{
    public partial class DiaCreate : Form//���紴������
    {
        private FrmMain father;
        public  cNet cNetwork;

        //���캯��
        public DiaCreate(FrmMain owner)
        {
            InitializeComponent();
            father = owner;
        }

        //�����ʼ������
        private void DiaCreate_Load(object sender, EventArgs e)
        {
            TabTypes.TabPages.Clear();
            switch (TypeCombo.Text)
            {
                case "BA�ޱ������":
                    TabTypes.TabPages.Add(TabBA);
                    break;
                case "ER���ͼ":
                    TabTypes.TabPages.Add(TabER);
                    break;
                case "С��������":
                    TabTypes.TabPages.Add(TabSW);
                    break;
            }
        }

        //OK��ť��Ӧ����
        private void OK_Button_Click(object sender, EventArgs e)
        {
            CreateParameter cParam;
            IfCreateStrategy Creator;
            int iNumber, iPara1, iPara2;
            bool bOption = true;

            if (TypeCombo.Text == "")
            {
                MessageBox.Show("����ѡ��һ���������ͣ�", "����", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            }
            Cursor = Cursors.WaitCursor;
            this.Refresh();
            //�����û�ѡ���װ�ز�ͬ����
            switch (TypeCombo.Text) //ѡ����������
            {
                case "BA�ޱ������":
                    iNumber = Convert.ToInt32(BANum.Value);
                    iPara1 = Convert.ToInt32(BAInit.Value);
                    iPara2 = Convert.ToInt32(BALimit.Value);
                    if (FullNet.Checked == true)
                    {
                        bOption = true;
                    }
                    else
                    {
                        bOption = false;
                    }
                    Creator = new BAStrategy();
                    break;
                case "ER���ͼ":
                    iNumber = Convert.ToInt32(ERNum.Value);
                    iPara1 = Convert.ToInt32(EREdge.Value);
                    iPara2 = Convert.ToInt32(ERPro.Value);
                    if (BaseEdge.Checked == true)
                    {
                        bOption = true;
                    }
                    else
                    {
                        bOption = false;
                    }
                    Creator = new ERStrategy();
                    break;
                case "С��������":
                    iNumber = Convert.ToInt32(SWNum.Value);
                    iPara1 = Convert.ToInt32(SWnei.Value);
                    iPara2 = Convert.ToInt32(SWPro.Value);
                    if (WS_SW.Checked == true)
                    {
                        bOption = true;
                    }
                    else if (NW_SW.Checked == true)
                    {
                        bOption = false;
                    }
                    Creator = new SWstrategy();
                    break;
                default:
                    return;
            }
            cParam = new CreateParameter(iNumber, iPara1, iPara2, bOption);
            //���ýӿ�Create��������
            cNetwork = Creator.Create(cParam);
            Cursor = Cursors.Arrow;
            if (cNetwork == null)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            this.Close();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close(); 
        }

        //����������Ͽ�ѡ����Ӧ����
        private void TypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabTypes.TabPages.Clear();
            switch(TypeCombo.Text)
            {
                case "BA�ޱ������":
                    TabTypes.TabPages.Add(TabBA);
                    break ;
                case "ER���ͼ":
                    TabTypes.TabPages.Add(TabER);
                    break ;
                case "С��������":
                    TabTypes.TabPages.Add(TabSW);
                    break ;
            }
        }

        //���������У�麯����ȷ������ֵ��Ч
        private void ERNum_ValueChanged(object sender, EventArgs e) 
        {
            int iNode;

            iNode = Convert .ToInt32 ( ERNum.Value);
            EREdge.Maximum = (iNode - 1) * iNode/2;
        }

        //���������У�麯����ȷ������ֵ��Ч
        private void SWnei_ValueChanged(object sender, EventArgs e)
        {
            int value;
            value=Convert.ToInt32 (SWnei .Value);
            if (value % 2 == 1)
            {
                SWnei.Value += 1;
            }
        }
    }
}
