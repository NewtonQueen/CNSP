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
    public partial class DiaCreate : Form//网络创建窗体
    {
        private FrmMain father;
        public  cNet cNetwork;

        //构造函数
        public DiaCreate(FrmMain owner)
        {
            InitializeComponent();
            father = owner;
        }

        //窗体初始化函数
        private void DiaCreate_Load(object sender, EventArgs e)
        {
            TabTypes.TabPages.Clear();
            switch (TypeCombo.Text)
            {
                case "BA无标度网络":
                    TabTypes.TabPages.Add(TabBA);
                    break;
                case "ER随机图":
                    TabTypes.TabPages.Add(TabER);
                    break;
                case "小世界网络":
                    TabTypes.TabPages.Add(TabSW);
                    break;
            }
        }

        //OK按钮响应函数
        private void OK_Button_Click(object sender, EventArgs e)
        {
            CreateParameter cParam;
            IfCreateStrategy Creator;
            int iNumber, iPara1, iPara2;
            bool bOption = true;

            if (TypeCombo.Text == "")
            {
                MessageBox.Show("请先选择一种网络类型！", "警告", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            }
            Cursor = Cursors.WaitCursor;
            this.Refresh();
            //根据用户选择项，装载不同参数
            switch (TypeCombo.Text) //选择网络类型
            {
                case "BA无标度网络":
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
                case "ER随机图":
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
                case "小世界网络":
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
            //调用接口Create创建函数
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

        //网络类型组合框选择响应函数
        private void TypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabTypes.TabPages.Clear();
            switch(TypeCombo.Text)
            {
                case "BA无标度网络":
                    TabTypes.TabPages.Add(TabBA);
                    break ;
                case "ER随机图":
                    TabTypes.TabPages.Add(TabER);
                    break ;
                case "小世界网络":
                    TabTypes.TabPages.Add(TabSW);
                    break ;
            }
        }

        //参数输入框校验函数，确保输入值有效
        private void ERNum_ValueChanged(object sender, EventArgs e) 
        {
            int iNode;

            iNode = Convert .ToInt32 ( ERNum.Value);
            EREdge.Maximum = (iNode - 1) * iNode/2;
        }

        //参数输入框校验函数，确保输入值有效
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
