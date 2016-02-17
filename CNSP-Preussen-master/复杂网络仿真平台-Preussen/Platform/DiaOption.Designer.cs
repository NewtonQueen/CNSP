namespace CNSP.Platform
{
    partial class DiaOption
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
            this.components = new System.ComponentModel.Container();
            this.ControlLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.OK_Button = new System.Windows.Forms.Button();
            this.MainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.OptionControl = new System.Windows.Forms.TabControl();
            this.PaintPage = new System.Windows.Forms.TabPage();
            this.StyleTabLayout = new System.Windows.Forms.TableLayoutPanel();
            this.FontBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StyleList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DescBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SizeBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ForeLabel = new System.Windows.Forms.Label();
            this.ForeButton = new System.Windows.Forms.Button();
            this.BackLabel = new System.Windows.Forms.Label();
            this.BackButton = new System.Windows.Forms.Button();
            this.FrameLabel = new System.Windows.Forms.Label();
            this.FrameButton = new System.Windows.Forms.Button();
            this.HLForeButton = new System.Windows.Forms.Button();
            this.HLBackButton = new System.Windows.Forms.Button();
            this.HLFrameButton = new System.Windows.Forms.Button();
            this.HLFrameLabel = new System.Windows.Forms.Label();
            this.HLBackLabel = new System.Windows.Forms.Label();
            this.HLForeLabel = new System.Windows.Forms.Label();
            this.FontButton = new System.Windows.Forms.Button();
            this.NodeImage = new System.Windows.Forms.PictureBox();
            this.HLImage = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SmoothBox = new System.Windows.Forms.ComboBox();
            this.StartTimer = new System.Windows.Forms.Timer(this.components);
            this.CheckTimer = new System.Windows.Forms.Timer(this.components);
            this.diaColor = new System.Windows.Forms.ColorDialog();
            this.diaFont = new System.Windows.Forms.FontDialog();
            this.ControlLayout.SuspendLayout();
            this.MainLayout.SuspendLayout();
            this.OptionControl.SuspendLayout();
            this.PaintPage.SuspendLayout();
            this.StyleTabLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NodeImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HLImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ControlLayout
            // 
            this.ControlLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlLayout.ColumnCount = 3;
            this.ControlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ControlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ControlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ControlLayout.Controls.Add(this.ApplyButton, 0, 0);
            this.ControlLayout.Controls.Add(this.Cancel_Button, 2, 0);
            this.ControlLayout.Controls.Add(this.OK_Button, 1, 0);
            this.ControlLayout.Location = new System.Drawing.Point(473, 408);
            this.ControlLayout.Name = "ControlLayout";
            this.ControlLayout.RowCount = 1;
            this.ControlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ControlLayout.Size = new System.Drawing.Size(229, 27);
            this.ControlLayout.TabIndex = 5;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ApplyButton.Enabled = false;
            this.ApplyButton.Location = new System.Drawing.Point(4, 3);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(67, 21);
            this.ApplyButton.TabIndex = 2;
            this.ApplyButton.Text = "应用";
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(157, 3);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(67, 21);
            this.Cancel_Button.TabIndex = 1;
            this.Cancel_Button.Text = "取消";
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_Button.Location = new System.Drawing.Point(80, 3);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(67, 21);
            this.OK_Button.TabIndex = 0;
            this.OK_Button.Text = "确定";
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // MainLayout
            // 
            this.MainLayout.ColumnCount = 2;
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 235F));
            this.MainLayout.Controls.Add(this.OptionControl, 0, 0);
            this.MainLayout.Controls.Add(this.ControlLayout, 1, 1);
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.Location = new System.Drawing.Point(0, 0);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.RowCount = 2;
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.MainLayout.Size = new System.Drawing.Size(705, 438);
            this.MainLayout.TabIndex = 6;
            // 
            // OptionControl
            // 
            this.MainLayout.SetColumnSpan(this.OptionControl, 2);
            this.OptionControl.Controls.Add(this.PaintPage);
            this.OptionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionControl.Location = new System.Drawing.Point(3, 3);
            this.OptionControl.Name = "OptionControl";
            this.OptionControl.SelectedIndex = 0;
            this.OptionControl.Size = new System.Drawing.Size(699, 398);
            this.OptionControl.TabIndex = 6;
            // 
            // PaintPage
            // 
            this.PaintPage.AutoScroll = true;
            this.PaintPage.Controls.Add(this.StyleTabLayout);
            this.PaintPage.Location = new System.Drawing.Point(4, 22);
            this.PaintPage.Name = "PaintPage";
            this.PaintPage.Padding = new System.Windows.Forms.Padding(3);
            this.PaintPage.Size = new System.Drawing.Size(691, 372);
            this.PaintPage.TabIndex = 0;
            this.PaintPage.Text = "绘图样式";
            this.PaintPage.UseVisualStyleBackColor = true;
            // 
            // StyleTabLayout
            // 
            this.StyleTabLayout.ColumnCount = 7;
            this.StyleTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.StyleTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.StyleTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.StyleTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.StyleTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.StyleTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.StyleTabLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.StyleTabLayout.Controls.Add(this.FontBox, 1, 3);
            this.StyleTabLayout.Controls.Add(this.label1, 0, 0);
            this.StyleTabLayout.Controls.Add(this.StyleList, 0, 1);
            this.StyleTabLayout.Controls.Add(this.label2, 1, 0);
            this.StyleTabLayout.Controls.Add(this.DescBox, 1, 1);
            this.StyleTabLayout.Controls.Add(this.label3, 1, 2);
            this.StyleTabLayout.Controls.Add(this.SizeBox, 6, 3);
            this.StyleTabLayout.Controls.Add(this.label4, 6, 2);
            this.StyleTabLayout.Controls.Add(this.label5, 1, 4);
            this.StyleTabLayout.Controls.Add(this.label6, 1, 5);
            this.StyleTabLayout.Controls.Add(this.label7, 1, 6);
            this.StyleTabLayout.Controls.Add(this.label8, 4, 4);
            this.StyleTabLayout.Controls.Add(this.label9, 4, 5);
            this.StyleTabLayout.Controls.Add(this.label10, 4, 6);
            this.StyleTabLayout.Controls.Add(this.ForeLabel, 2, 4);
            this.StyleTabLayout.Controls.Add(this.ForeButton, 3, 4);
            this.StyleTabLayout.Controls.Add(this.BackLabel, 2, 5);
            this.StyleTabLayout.Controls.Add(this.BackButton, 3, 5);
            this.StyleTabLayout.Controls.Add(this.FrameLabel, 2, 6);
            this.StyleTabLayout.Controls.Add(this.FrameButton, 3, 6);
            this.StyleTabLayout.Controls.Add(this.HLForeButton, 6, 4);
            this.StyleTabLayout.Controls.Add(this.HLBackButton, 6, 5);
            this.StyleTabLayout.Controls.Add(this.HLFrameButton, 6, 6);
            this.StyleTabLayout.Controls.Add(this.HLFrameLabel, 5, 6);
            this.StyleTabLayout.Controls.Add(this.HLBackLabel, 5, 5);
            this.StyleTabLayout.Controls.Add(this.HLForeLabel, 5, 4);
            this.StyleTabLayout.Controls.Add(this.FontButton, 5, 3);
            this.StyleTabLayout.Controls.Add(this.NodeImage, 2, 8);
            this.StyleTabLayout.Controls.Add(this.HLImage, 5, 8);
            this.StyleTabLayout.Controls.Add(this.label11, 1, 8);
            this.StyleTabLayout.Controls.Add(this.label12, 4, 8);
            this.StyleTabLayout.Controls.Add(this.label13, 1, 7);
            this.StyleTabLayout.Controls.Add(this.SmoothBox, 2, 7);
            this.StyleTabLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StyleTabLayout.Location = new System.Drawing.Point(3, 3);
            this.StyleTabLayout.Name = "StyleTabLayout";
            this.StyleTabLayout.RowCount = 9;
            this.StyleTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.StyleTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.StyleTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.StyleTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.StyleTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.StyleTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.StyleTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.StyleTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.StyleTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.StyleTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.StyleTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.StyleTabLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.StyleTabLayout.Size = new System.Drawing.Size(685, 366);
            this.StyleTabLayout.TabIndex = 8;
            // 
            // FontBox
            // 
            this.FontBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.StyleTabLayout.SetColumnSpan(this.FontBox, 4);
            this.FontBox.Enabled = false;
            this.FontBox.Location = new System.Drawing.Point(153, 115);
            this.FontBox.Name = "FontBox";
            this.FontBox.Size = new System.Drawing.Size(340, 21);
            this.FontBox.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "预设样式：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StyleList
            // 
            this.StyleList.DisplayMember = "ID";
            this.StyleList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StyleList.FormattingEnabled = true;
            this.StyleList.ItemHeight = 12;
            this.StyleList.Location = new System.Drawing.Point(3, 39);
            this.StyleList.Name = "StyleList";
            this.StyleTabLayout.SetRowSpan(this.StyleList, 8);
            this.StyleList.Size = new System.Drawing.Size(144, 324);
            this.StyleList.TabIndex = 10;
            this.StyleList.ValueMember = "ID";
            this.StyleList.SelectedIndexChanged += new System.EventHandler(this.StyleList_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "样式描述：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DescBox
            // 
            this.DescBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.StyleTabLayout.SetColumnSpan(this.DescBox, 6);
            this.DescBox.Enabled = false;
            this.DescBox.Location = new System.Drawing.Point(153, 43);
            this.DescBox.Name = "DescBox";
            this.DescBox.Size = new System.Drawing.Size(529, 21);
            this.DescBox.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "字体：";
            // 
            // SizeBox
            // 
            this.SizeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SizeBox.FormattingEnabled = true;
            this.SizeBox.Items.AddRange(new object[] {
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.SizeBox.Location = new System.Drawing.Point(592, 116);
            this.SizeBox.Name = "SizeBox";
            this.SizeBox.Size = new System.Drawing.Size(90, 20);
            this.SizeBox.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(592, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 14;
            this.label4.Text = "字号：";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(153, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 18;
            this.label5.Text = "前景色：";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(153, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "背景色：";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(153, 228);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "边框色：";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(414, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "高亮前景色：";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(414, 192);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 22;
            this.label9.Text = "高亮背景色：";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(414, 228);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 23;
            this.label10.Text = "高亮边框色：";
            // 
            // ForeLabel
            // 
            this.ForeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ForeLabel.AutoSize = true;
            this.ForeLabel.BackColor = System.Drawing.Color.Black;
            this.ForeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ForeLabel.Location = new System.Drawing.Point(238, 155);
            this.ForeLabel.Name = "ForeLabel";
            this.ForeLabel.Size = new System.Drawing.Size(67, 14);
            this.ForeLabel.TabIndex = 32;
            this.ForeLabel.Text = "          ";
            this.ForeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ForeButton
            // 
            this.ForeButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ForeButton.Location = new System.Drawing.Point(324, 147);
            this.ForeButton.Name = "ForeButton";
            this.ForeButton.Size = new System.Drawing.Size(80, 30);
            this.ForeButton.TabIndex = 26;
            this.ForeButton.Text = "自定义";
            this.ForeButton.UseVisualStyleBackColor = true;
            this.ForeButton.Click += new System.EventHandler(this.ForeButton_Click);
            // 
            // BackLabel
            // 
            this.BackLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BackLabel.AutoSize = true;
            this.BackLabel.BackColor = System.Drawing.Color.Black;
            this.BackLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BackLabel.Location = new System.Drawing.Point(238, 191);
            this.BackLabel.Name = "BackLabel";
            this.BackLabel.Size = new System.Drawing.Size(67, 14);
            this.BackLabel.TabIndex = 33;
            this.BackLabel.Text = "          ";
            this.BackLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BackButton
            // 
            this.BackButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BackButton.Location = new System.Drawing.Point(324, 183);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(80, 30);
            this.BackButton.TabIndex = 27;
            this.BackButton.Text = "自定义";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // FrameLabel
            // 
            this.FrameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FrameLabel.AutoSize = true;
            this.FrameLabel.BackColor = System.Drawing.Color.Black;
            this.FrameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FrameLabel.Location = new System.Drawing.Point(238, 227);
            this.FrameLabel.Name = "FrameLabel";
            this.FrameLabel.Size = new System.Drawing.Size(67, 14);
            this.FrameLabel.TabIndex = 34;
            this.FrameLabel.Text = "          ";
            this.FrameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrameButton
            // 
            this.FrameButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FrameButton.Location = new System.Drawing.Point(324, 219);
            this.FrameButton.Name = "FrameButton";
            this.FrameButton.Size = new System.Drawing.Size(80, 30);
            this.FrameButton.TabIndex = 28;
            this.FrameButton.Text = "自定义";
            this.FrameButton.UseVisualStyleBackColor = true;
            this.FrameButton.Click += new System.EventHandler(this.FrameButton_Click);
            // 
            // HLForeButton
            // 
            this.HLForeButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HLForeButton.Location = new System.Drawing.Point(597, 147);
            this.HLForeButton.Name = "HLForeButton";
            this.HLForeButton.Size = new System.Drawing.Size(80, 30);
            this.HLForeButton.TabIndex = 29;
            this.HLForeButton.Text = "自定义";
            this.HLForeButton.UseVisualStyleBackColor = true;
            this.HLForeButton.Click += new System.EventHandler(this.HLForeButton_Click);
            // 
            // HLBackButton
            // 
            this.HLBackButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HLBackButton.Location = new System.Drawing.Point(597, 183);
            this.HLBackButton.Name = "HLBackButton";
            this.HLBackButton.Size = new System.Drawing.Size(80, 30);
            this.HLBackButton.TabIndex = 30;
            this.HLBackButton.Text = "自定义";
            this.HLBackButton.UseVisualStyleBackColor = true;
            this.HLBackButton.Click += new System.EventHandler(this.HLBackButton_Click);
            // 
            // HLFrameButton
            // 
            this.HLFrameButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HLFrameButton.Location = new System.Drawing.Point(597, 219);
            this.HLFrameButton.Name = "HLFrameButton";
            this.HLFrameButton.Size = new System.Drawing.Size(80, 30);
            this.HLFrameButton.TabIndex = 31;
            this.HLFrameButton.Text = "自定义";
            this.HLFrameButton.UseVisualStyleBackColor = true;
            this.HLFrameButton.Click += new System.EventHandler(this.HLFrameButton_Click);
            // 
            // HLFrameLabel
            // 
            this.HLFrameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HLFrameLabel.AutoSize = true;
            this.HLFrameLabel.BackColor = System.Drawing.Color.Black;
            this.HLFrameLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HLFrameLabel.Location = new System.Drawing.Point(509, 227);
            this.HLFrameLabel.Name = "HLFrameLabel";
            this.HLFrameLabel.Size = new System.Drawing.Size(67, 14);
            this.HLFrameLabel.TabIndex = 37;
            this.HLFrameLabel.Text = "          ";
            this.HLFrameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HLBackLabel
            // 
            this.HLBackLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HLBackLabel.AutoSize = true;
            this.HLBackLabel.BackColor = System.Drawing.Color.Black;
            this.HLBackLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HLBackLabel.Location = new System.Drawing.Point(509, 191);
            this.HLBackLabel.Name = "HLBackLabel";
            this.HLBackLabel.Size = new System.Drawing.Size(67, 14);
            this.HLBackLabel.TabIndex = 36;
            this.HLBackLabel.Text = "          ";
            this.HLBackLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HLForeLabel
            // 
            this.HLForeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HLForeLabel.AutoSize = true;
            this.HLForeLabel.BackColor = System.Drawing.Color.Black;
            this.HLForeLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HLForeLabel.Location = new System.Drawing.Point(509, 155);
            this.HLForeLabel.Name = "HLForeLabel";
            this.HLForeLabel.Size = new System.Drawing.Size(67, 14);
            this.HLForeLabel.TabIndex = 35;
            this.HLForeLabel.Text = "          ";
            this.HLForeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FontButton
            // 
            this.FontButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FontButton.Location = new System.Drawing.Point(502, 111);
            this.FontButton.Name = "FontButton";
            this.FontButton.Size = new System.Drawing.Size(80, 30);
            this.FontButton.TabIndex = 17;
            this.FontButton.Text = "自定义";
            this.FontButton.UseVisualStyleBackColor = true;
            this.FontButton.Click += new System.EventHandler(this.FontButton_Click);
            // 
            // NodeImage
            // 
            this.NodeImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NodeImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.NodeImage.Location = new System.Drawing.Point(228, 292);
            this.NodeImage.Name = "NodeImage";
            this.NodeImage.Size = new System.Drawing.Size(71, 71);
            this.NodeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.NodeImage.TabIndex = 7;
            this.NodeImage.TabStop = false;
            // 
            // HLImage
            // 
            this.HLImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.HLImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.HLImage.Location = new System.Drawing.Point(499, 292);
            this.HLImage.Name = "HLImage";
            this.HLImage.Size = new System.Drawing.Size(71, 71);
            this.HLImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.HLImage.TabIndex = 8;
            this.HLImage.TabStop = false;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(153, 321);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 24;
            this.label11.Text = "普通模式：";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(414, 321);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 25;
            this.label12.Text = "高亮模式：";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(153, 264);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 38;
            this.label13.Text = "抗锯齿：";
            // 
            // SmoothBox
            // 
            this.SmoothBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.StyleTabLayout.SetColumnSpan(this.SmoothBox, 2);
            this.SmoothBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SmoothBox.FormattingEnabled = true;
            this.SmoothBox.Items.AddRange(new object[] {
            "Default",
            "HighSpeed",
            "HighQuality",
            "None",
            "AntiAlias"});
            this.SmoothBox.Location = new System.Drawing.Point(228, 260);
            this.SmoothBox.Name = "SmoothBox";
            this.SmoothBox.Size = new System.Drawing.Size(180, 20);
            this.SmoothBox.TabIndex = 39;
            this.SmoothBox.SelectedIndexChanged += new System.EventHandler(this.SmoothBox_SelectedIndexChanged);
            // 
            // StartTimer
            // 
            this.StartTimer.Enabled = true;
            this.StartTimer.Tick += new System.EventHandler(this.StartTimer_Tick);
            // 
            // CheckTimer
            // 
            this.CheckTimer.Interval = 300;
            this.CheckTimer.Tick += new System.EventHandler(this.CheckTimer_Tick);
            // 
            // DiaOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(705, 438);
            this.Controls.Add(this.MainLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DiaOption";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户选项";
            this.Load += new System.EventHandler(this.DiaOption_Load);
            this.ControlLayout.ResumeLayout(false);
            this.MainLayout.ResumeLayout(false);
            this.OptionControl.ResumeLayout(false);
            this.PaintPage.ResumeLayout(false);
            this.StyleTabLayout.ResumeLayout(false);
            this.StyleTabLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NodeImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HLImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel ControlLayout;
        internal System.Windows.Forms.Button ApplyButton;
        internal System.Windows.Forms.Button Cancel_Button;
        internal System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.TableLayoutPanel MainLayout;
        private System.Windows.Forms.TabControl OptionControl;
        private System.Windows.Forms.TabPage PaintPage;
        internal System.Windows.Forms.Timer StartTimer;
        internal System.Windows.Forms.PictureBox NodeImage;
        private System.Windows.Forms.Timer CheckTimer;
        private System.Windows.Forms.TableLayoutPanel StyleTabLayout;
        internal System.Windows.Forms.PictureBox HLImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox StyleList;
        private System.Windows.Forms.ColorDialog diaColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DescBox;
        private System.Windows.Forms.TextBox FontBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox SizeBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button FontButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.FontDialog diaFont;
        private System.Windows.Forms.Button ForeButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button FrameButton;
        private System.Windows.Forms.Button HLForeButton;
        private System.Windows.Forms.Button HLBackButton;
        private System.Windows.Forms.Button HLFrameButton;
        private System.Windows.Forms.Label ForeLabel;
        private System.Windows.Forms.Label BackLabel;
        private System.Windows.Forms.Label FrameLabel;
        private System.Windows.Forms.Label HLForeLabel;
        private System.Windows.Forms.Label HLBackLabel;
        private System.Windows.Forms.Label HLFrameLabel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox SmoothBox;
    }
}