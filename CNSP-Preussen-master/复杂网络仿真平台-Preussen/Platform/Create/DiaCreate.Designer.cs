namespace CNSP.Platform.Create
{
    partial class DiaCreate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TabTypes = new System.Windows.Forms.TabControl();
            this.TabBA = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ERNet = new System.Windows.Forms.RadioButton();
            this.FullNet = new System.Windows.Forms.RadioButton();
            this.Label11 = new System.Windows.Forms.Label();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.BANum = new System.Windows.Forms.NumericUpDown();
            this.BAInit = new System.Windows.Forms.NumericUpDown();
            this.BALimit = new System.Windows.Forms.NumericUpDown();
            this.TabER = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BasePro = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ERNum = new System.Windows.Forms.NumericUpDown();
            this.EREdge = new System.Windows.Forms.NumericUpDown();
            this.ERPro = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.BaseEdge = new System.Windows.Forms.RadioButton();
            this.TabSW = new System.Windows.Forms.TabPage();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.NW_SW = new System.Windows.Forms.RadioButton();
            this.Label13 = new System.Windows.Forms.Label();
            this.WS_SW = new System.Windows.Forms.RadioButton();
            this.TableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.SWPro = new System.Windows.Forms.NumericUpDown();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.SWNum = new System.Windows.Forms.NumericUpDown();
            this.SWnei = new System.Windows.Forms.NumericUpDown();
            this.Label12 = new System.Windows.Forms.Label();
            this.TypeCombo = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.TabTypes.SuspendLayout();
            this.TabBA.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.TableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BANum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BAInit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BALimit)).BeginInit();
            this.TabER.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ERNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EREdge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ERPro)).BeginInit();
            this.TabSW.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.TableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SWPro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SWNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SWnei)).BeginInit();
            this.TableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabTypes
            // 
            this.TabTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TabTypes.Controls.Add(this.TabBA);
            this.TabTypes.Controls.Add(this.TabER);
            this.TabTypes.Controls.Add(this.TabSW);
            this.TabTypes.Location = new System.Drawing.Point(2, 38);
            this.TabTypes.Name = "TabTypes";
            this.TabTypes.SelectedIndex = 0;
            this.TabTypes.Size = new System.Drawing.Size(358, 196);
            this.TabTypes.TabIndex = 7;
            // 
            // TabBA
            // 
            this.TabBA.BackColor = System.Drawing.SystemColors.Control;
            this.TabBA.Controls.Add(this.GroupBox1);
            this.TabBA.Location = new System.Drawing.Point(4, 22);
            this.TabBA.Name = "TabBA";
            this.TabBA.Padding = new System.Windows.Forms.Padding(3);
            this.TabBA.Size = new System.Drawing.Size(350, 170);
            this.TabBA.TabIndex = 0;
            this.TabBA.Text = "BA无标度网络";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.ERNet);
            this.GroupBox1.Controls.Add(this.FullNet);
            this.GroupBox1.Controls.Add(this.Label11);
            this.GroupBox1.Controls.Add(this.TableLayoutPanel2);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox1.Location = new System.Drawing.Point(3, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(344, 164);
            this.GroupBox1.TabIndex = 6;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "网络参数";
            // 
            // ERNet
            // 
            this.ERNet.AutoSize = true;
            this.ERNet.Location = new System.Drawing.Point(222, 120);
            this.ERNet.Name = "ERNet";
            this.ERNet.Size = new System.Drawing.Size(76, 17);
            this.ERNet.TabIndex = 37;
            this.ERNet.Text = "ER随机图";
            this.ERNet.UseVisualStyleBackColor = true;
            // 
            // FullNet
            // 
            this.FullNet.AutoSize = true;
            this.FullNet.Checked = true;
            this.FullNet.Location = new System.Drawing.Point(136, 120);
            this.FullNet.Name = "FullNet";
            this.FullNet.Size = new System.Drawing.Size(61, 17);
            this.FullNet.TabIndex = 36;
            this.FullNet.TabStop = true;
            this.FullNet.Text = "完全图";
            this.FullNet.UseVisualStyleBackColor = true;
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(23, 122);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(106, 13);
            this.Label11.TabIndex = 35;
            this.Label11.Text = "自动生成网络类型:";
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.ColumnCount = 2;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel2.Controls.Add(this.Label2, 0, 2);
            this.TableLayoutPanel2.Controls.Add(this.Label3, 0, 1);
            this.TableLayoutPanel2.Controls.Add(this.Label4, 0, 0);
            this.TableLayoutPanel2.Controls.Add(this.BANum, 1, 0);
            this.TableLayoutPanel2.Controls.Add(this.BAInit, 1, 1);
            this.TableLayoutPanel2.Controls.Add(this.BALimit, 1, 2);
            this.TableLayoutPanel2.Location = new System.Drawing.Point(3, 18);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 3;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.TableLayoutPanel2.Size = new System.Drawing.Size(307, 95);
            this.TableLayoutPanel2.TabIndex = 0;
            // 
            // Label2
            // 
            this.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(21, 72);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(58, 13);
            this.Label2.TabIndex = 40;
            this.Label2.Text = "连接上限:";
            // 
            // Label3
            // 
            this.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(21, 40);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(58, 13);
            this.Label3.TabIndex = 38;
            this.Label3.Text = "初始节点:";
            // 
            // Label4
            // 
            this.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(33, 9);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(46, 13);
            this.Label4.TabIndex = 36;
            this.Label4.Text = "节点数:";
            // 
            // BANum
            // 
            this.BANum.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BANum.Location = new System.Drawing.Point(85, 5);
            this.BANum.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.BANum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BANum.Name = "BANum";
            this.BANum.Size = new System.Drawing.Size(219, 20);
            this.BANum.TabIndex = 42;
            this.BANum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BANum.Value = new decimal(new int[] {
            240,
            0,
            0,
            0});
            // 
            // BAInit
            // 
            this.BAInit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BAInit.Location = new System.Drawing.Point(85, 36);
            this.BAInit.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.BAInit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BAInit.Name = "BAInit";
            this.BAInit.Size = new System.Drawing.Size(219, 20);
            this.BAInit.TabIndex = 42;
            this.BAInit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BAInit.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // BALimit
            // 
            this.BALimit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BALimit.Location = new System.Drawing.Point(85, 68);
            this.BALimit.Maximum = new decimal(new int[] {
            240,
            0,
            0,
            0});
            this.BALimit.Name = "BALimit";
            this.BALimit.Size = new System.Drawing.Size(219, 20);
            this.BALimit.TabIndex = 42;
            this.BALimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BALimit.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // TabER
            // 
            this.TabER.BackColor = System.Drawing.SystemColors.Control;
            this.TabER.Controls.Add(this.groupBox2);
            this.TabER.Location = new System.Drawing.Point(4, 22);
            this.TabER.Name = "TabER";
            this.TabER.Padding = new System.Windows.Forms.Padding(3);
            this.TabER.Size = new System.Drawing.Size(350, 170);
            this.TabER.TabIndex = 1;
            this.TabER.Text = "ER随机图";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BasePro);
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.BaseEdge);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 164);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "网络参数";
            // 
            // BasePro
            // 
            this.BasePro.AutoSize = true;
            this.BasePro.Location = new System.Drawing.Point(236, 128);
            this.BasePro.Name = "BasePro";
            this.BasePro.Size = new System.Drawing.Size(73, 17);
            this.BasePro.TabIndex = 37;
            this.BasePro.Text = "基于概率";
            this.BasePro.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.ERNum, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.EREdge, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.ERPro, 1, 2);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(307, 95);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "连接概率(%):";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 38;
            this.label7.Text = "连边数:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "节点数:";
            // 
            // ERNum
            // 
            this.ERNum.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ERNum.Location = new System.Drawing.Point(86, 5);
            this.ERNum.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.ERNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ERNum.Name = "ERNum";
            this.ERNum.Size = new System.Drawing.Size(218, 20);
            this.ERNum.TabIndex = 42;
            this.ERNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ERNum.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.ERNum.ValueChanged += new System.EventHandler(this.ERNum_ValueChanged);
            // 
            // EREdge
            // 
            this.EREdge.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.EREdge.Location = new System.Drawing.Point(86, 36);
            this.EREdge.Maximum = new decimal(new int[] {
            19900,
            0,
            0,
            0});
            this.EREdge.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.EREdge.Name = "EREdge";
            this.EREdge.Size = new System.Drawing.Size(218, 20);
            this.EREdge.TabIndex = 42;
            this.EREdge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.EREdge.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // ERPro
            // 
            this.ERPro.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ERPro.Location = new System.Drawing.Point(86, 68);
            this.ERPro.Name = "ERPro";
            this.ERPro.Size = new System.Drawing.Size(218, 20);
            this.ERPro.TabIndex = 42;
            this.ERPro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ERPro.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "自动生成网络类型:";
            // 
            // BaseEdge
            // 
            this.BaseEdge.AutoSize = true;
            this.BaseEdge.Checked = true;
            this.BaseEdge.Location = new System.Drawing.Point(134, 128);
            this.BaseEdge.Name = "BaseEdge";
            this.BaseEdge.Size = new System.Drawing.Size(73, 17);
            this.BaseEdge.TabIndex = 36;
            this.BaseEdge.TabStop = true;
            this.BaseEdge.Text = "基于连边";
            this.BaseEdge.UseVisualStyleBackColor = true;
            // 
            // TabSW
            // 
            this.TabSW.BackColor = System.Drawing.SystemColors.Control;
            this.TabSW.Controls.Add(this.GroupBox4);
            this.TabSW.Location = new System.Drawing.Point(4, 22);
            this.TabSW.Name = "TabSW";
            this.TabSW.Padding = new System.Windows.Forms.Padding(3);
            this.TabSW.Size = new System.Drawing.Size(350, 170);
            this.TabSW.TabIndex = 2;
            this.TabSW.Text = "小世界网络";
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.NW_SW);
            this.GroupBox4.Controls.Add(this.Label13);
            this.GroupBox4.Controls.Add(this.WS_SW);
            this.GroupBox4.Controls.Add(this.TableLayoutPanel5);
            this.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox4.Location = new System.Drawing.Point(3, 3);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(344, 164);
            this.GroupBox4.TabIndex = 9;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "网络参数";
            // 
            // NW_SW
            // 
            this.NW_SW.AutoSize = true;
            this.NW_SW.Location = new System.Drawing.Point(224, 132);
            this.NW_SW.Name = "NW_SW";
            this.NW_SW.Size = new System.Drawing.Size(104, 17);
            this.NW_SW.TabIndex = 40;
            this.NW_SW.Text = "NW小世界网络";
            this.NW_SW.UseVisualStyleBackColor = true;
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(10, 134);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(106, 13);
            this.Label13.TabIndex = 38;
            this.Label13.Text = "自动生成网络类型:";
            // 
            // WS_SW
            // 
            this.WS_SW.AutoSize = true;
            this.WS_SW.Checked = true;
            this.WS_SW.Location = new System.Drawing.Point(123, 132);
            this.WS_SW.Name = "WS_SW";
            this.WS_SW.Size = new System.Drawing.Size(103, 17);
            this.WS_SW.TabIndex = 39;
            this.WS_SW.TabStop = true;
            this.WS_SW.Text = "WS小世界网络";
            this.WS_SW.UseVisualStyleBackColor = true;
            // 
            // TableLayoutPanel5
            // 
            this.TableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel5.ColumnCount = 2;
            this.TableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.TableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel5.Controls.Add(this.SWPro, 1, 2);
            this.TableLayoutPanel5.Controls.Add(this.Label9, 0, 0);
            this.TableLayoutPanel5.Controls.Add(this.Label10, 0, 2);
            this.TableLayoutPanel5.Controls.Add(this.SWNum, 1, 0);
            this.TableLayoutPanel5.Controls.Add(this.SWnei, 1, 1);
            this.TableLayoutPanel5.Controls.Add(this.Label12, 0, 1);
            this.TableLayoutPanel5.Location = new System.Drawing.Point(3, 18);
            this.TableLayoutPanel5.Name = "TableLayoutPanel5";
            this.TableLayoutPanel5.RowCount = 3;
            this.TableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.TableLayoutPanel5.Size = new System.Drawing.Size(338, 96);
            this.TableLayoutPanel5.TabIndex = 1;
            // 
            // SWPro
            // 
            this.SWPro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SWPro.Location = new System.Drawing.Point(87, 70);
            this.SWPro.Name = "SWPro";
            this.SWPro.Size = new System.Drawing.Size(248, 20);
            this.SWPro.TabIndex = 35;
            this.SWPro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SWPro.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // Label9
            // 
            this.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(35, 9);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(46, 13);
            this.Label9.TabIndex = 30;
            this.Label9.Text = "节点数:";
            // 
            // Label10
            // 
            this.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(33, 73);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(48, 13);
            this.Label10.TabIndex = 34;
            this.Label10.Text = "概率(%):";
            // 
            // SWNum
            // 
            this.SWNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SWNum.Location = new System.Drawing.Point(87, 6);
            this.SWNum.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.SWNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SWNum.Name = "SWNum";
            this.SWNum.Size = new System.Drawing.Size(248, 20);
            this.SWNum.TabIndex = 42;
            this.SWNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SWNum.Value = new decimal(new int[] {
            240,
            0,
            0,
            0});
            // 
            // SWnei
            // 
            this.SWnei.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SWnei.Location = new System.Drawing.Point(87, 38);
            this.SWnei.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.SWnei.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SWnei.Name = "SWnei";
            this.SWnei.Size = new System.Drawing.Size(248, 20);
            this.SWnei.TabIndex = 42;
            this.SWnei.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SWnei.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.SWnei.ValueChanged += new System.EventHandler(this.SWnei_ValueChanged);
            // 
            // Label12
            // 
            this.Label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(35, 41);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(46, 13);
            this.Label12.TabIndex = 32;
            this.Label12.Text = "邻居数:";
            // 
            // TypeCombo
            // 
            this.TypeCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeCombo.FormattingEnabled = true;
            this.TypeCombo.Items.AddRange(new object[] {
            "BA无标度网络",
            "ER随机图",
            "小世界网络"});
            this.TypeCombo.Location = new System.Drawing.Point(95, 10);
            this.TypeCombo.Name = "TypeCombo";
            this.TypeCombo.Size = new System.Drawing.Size(110, 21);
            this.TypeCombo.TabIndex = 6;
            this.TypeCombo.SelectedIndexChanged += new System.EventHandler(this.TypeCombo_SelectedIndexChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 13);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(91, 13);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "选择网络类型：";
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Controls.Add(this.OK_Button, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.Cancel_Button, 1, 0);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(214, 241);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(146, 29);
            this.TableLayoutPanel1.TabIndex = 4;
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OK_Button.Location = new System.Drawing.Point(3, 3);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(67, 23);
            this.OK_Button.TabIndex = 0;
            this.OK_Button.Text = "确定";
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(76, 3);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(67, 23);
            this.Cancel_Button.TabIndex = 1;
            this.Cancel_Button.Text = "取消";
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // DiaCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 276);
            this.Controls.Add(this.TabTypes);
            this.Controls.Add(this.TypeCombo);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.TableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DiaCreate";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "创建新网络";
            this.Load += new System.EventHandler(this.DiaCreate_Load);
            this.TabTypes.ResumeLayout(false);
            this.TabBA.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.TableLayoutPanel2.ResumeLayout(false);
            this.TableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BANum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BAInit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BALimit)).EndInit();
            this.TabER.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ERNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EREdge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ERPro)).EndInit();
            this.TabSW.ResumeLayout(false);
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.TableLayoutPanel5.ResumeLayout(false);
            this.TableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SWPro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SWNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SWnei)).EndInit();
            this.TableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TabControl TabTypes;
        internal System.Windows.Forms.TabPage TabBA;
        internal System.Windows.Forms.TabPage TabER;
        internal System.Windows.Forms.TabPage TabSW;
        internal System.Windows.Forms.ComboBox TypeCombo;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Button OK_Button;
        internal System.Windows.Forms.Button Cancel_Button;
        internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.RadioButton FullNet;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.NumericUpDown BANum;
        internal System.Windows.Forms.NumericUpDown BAInit;
        internal System.Windows.Forms.NumericUpDown BALimit;
        private System.Windows.Forms.RadioButton ERNet;
        internal System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton BasePro;
        internal System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.NumericUpDown ERNum;
        internal System.Windows.Forms.NumericUpDown EREdge;
        internal System.Windows.Forms.NumericUpDown ERPro;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton BaseEdge;
        internal System.Windows.Forms.GroupBox GroupBox4;
        private System.Windows.Forms.RadioButton NW_SW;
        internal System.Windows.Forms.Label Label13;
        private System.Windows.Forms.RadioButton WS_SW;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel5;
        internal System.Windows.Forms.NumericUpDown SWPro;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.NumericUpDown SWNum;
        internal System.Windows.Forms.NumericUpDown SWnei;
        internal System.Windows.Forms.Label Label12;
    }
}