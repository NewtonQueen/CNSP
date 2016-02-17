namespace CNSP.Platform.Parameter
{
    partial class DiaParameter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiaParameter));
            this.BottomLayout = new System.Windows.Forms.TableLayoutPanel();
            this.NodeList = new System.Windows.Forms.ListBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabDistance = new System.Windows.Forms.TabPage();
            this.DistanceLayout = new System.Windows.Forms.TableLayoutPanel();
            this.Label9 = new System.Windows.Forms.Label();
            this.DensityBox = new System.Windows.Forms.TextBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.DiameterBox = new System.Windows.Forms.TextBox();
            this.Label15 = new System.Windows.Forms.Label();
            this.TargetBox = new System.Windows.Forms.NumericUpDown();
            this.Label16 = new System.Windows.Forms.Label();
            this.PathBox = new System.Windows.Forms.TextBox();
            this.tabCenter = new System.Windows.Forms.TabPage();
            this.CenterLayout = new System.Windows.Forms.TableLayoutPanel();
            this.Label13 = new System.Windows.Forms.Label();
            this.LoopBox = new System.Windows.Forms.TextBox();
            this.ClusterBox = new System.Windows.Forms.TextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.CloseBox = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AveClusterBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AveLoopBox = new System.Windows.Forms.TextBox();
            this.AveCloseBox = new System.Windows.Forms.TextBox();
            this.tabPageRank = new System.Windows.Forms.TabPage();
            this.PageRankLayout = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.PageRankBox = new System.Windows.Forms.TextBox();
            this.tabKshell = new System.Windows.Forms.TabPage();
            this.KshellLayout = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.KshellBox = new System.Windows.Forms.TextBox();
            this.BottomLayout.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabDistance.SuspendLayout();
            this.DistanceLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TargetBox)).BeginInit();
            this.tabCenter.SuspendLayout();
            this.CenterLayout.SuspendLayout();
            this.tabPageRank.SuspendLayout();
            this.PageRankLayout.SuspendLayout();
            this.tabKshell.SuspendLayout();
            this.KshellLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // BottomLayout
            // 
            this.BottomLayout.ColumnCount = 2;
            this.BottomLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.BottomLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BottomLayout.Controls.Add(this.NodeList, 0, 0);
            this.BottomLayout.Controls.Add(this.tabMain, 1, 0);
            this.BottomLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BottomLayout.Location = new System.Drawing.Point(0, 0);
            this.BottomLayout.Name = "BottomLayout";
            this.BottomLayout.RowCount = 1;
            this.BottomLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.BottomLayout.Size = new System.Drawing.Size(628, 433);
            this.BottomLayout.TabIndex = 0;
            // 
            // NodeList
            // 
            this.NodeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NodeList.FormattingEnabled = true;
            this.NodeList.Location = new System.Drawing.Point(3, 3);
            this.NodeList.Name = "NodeList";
            this.NodeList.Size = new System.Drawing.Size(174, 427);
            this.NodeList.TabIndex = 1;
            this.NodeList.SelectedIndexChanged += new System.EventHandler(this.NodeList_SelectedIndexChanged);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabDistance);
            this.tabMain.Controls.Add(this.tabCenter);
            this.tabMain.Controls.Add(this.tabPageRank);
            this.tabMain.Controls.Add(this.tabKshell);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(183, 3);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(442, 427);
            this.tabMain.TabIndex = 2;
            // 
            // tabDistance
            // 
            this.tabDistance.BackColor = System.Drawing.SystemColors.Control;
            this.tabDistance.Controls.Add(this.DistanceLayout);
            this.tabDistance.Location = new System.Drawing.Point(4, 22);
            this.tabDistance.Name = "tabDistance";
            this.tabDistance.Padding = new System.Windows.Forms.Padding(3);
            this.tabDistance.Size = new System.Drawing.Size(434, 401);
            this.tabDistance.TabIndex = 0;
            this.tabDistance.Text = "距离参数";
            // 
            // DistanceLayout
            // 
            this.DistanceLayout.ColumnCount = 4;
            this.DistanceLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.DistanceLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DistanceLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.DistanceLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DistanceLayout.Controls.Add(this.Label9, 0, 0);
            this.DistanceLayout.Controls.Add(this.DensityBox, 1, 0);
            this.DistanceLayout.Controls.Add(this.Label11, 2, 0);
            this.DistanceLayout.Controls.Add(this.DiameterBox, 3, 0);
            this.DistanceLayout.Controls.Add(this.Label15, 0, 1);
            this.DistanceLayout.Controls.Add(this.TargetBox, 1, 1);
            this.DistanceLayout.Controls.Add(this.Label16, 2, 1);
            this.DistanceLayout.Controls.Add(this.PathBox, 3, 1);
            this.DistanceLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DistanceLayout.Location = new System.Drawing.Point(3, 3);
            this.DistanceLayout.Name = "DistanceLayout";
            this.DistanceLayout.RowCount = 3;
            this.DistanceLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DistanceLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.DistanceLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 313F));
            this.DistanceLayout.Size = new System.Drawing.Size(428, 395);
            this.DistanceLayout.TabIndex = 1;
            // 
            // Label9
            // 
            this.Label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(39, 14);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(58, 13);
            this.Label9.TabIndex = 2;
            this.Label9.Text = "网络密度:";
            // 
            // DensityBox
            // 
            this.DensityBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DensityBox.Location = new System.Drawing.Point(103, 10);
            this.DensityBox.Name = "DensityBox";
            this.DensityBox.ReadOnly = true;
            this.DensityBox.Size = new System.Drawing.Size(108, 20);
            this.DensityBox.TabIndex = 3;
            this.DensityBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label11
            // 
            this.Label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(253, 14);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(58, 13);
            this.Label11.TabIndex = 5;
            this.Label11.Text = "网络直径:";
            // 
            // DiameterBox
            // 
            this.DiameterBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DiameterBox.Location = new System.Drawing.Point(317, 10);
            this.DiameterBox.Name = "DiameterBox";
            this.DiameterBox.ReadOnly = true;
            this.DiameterBox.Size = new System.Drawing.Size(108, 20);
            this.DiameterBox.TabIndex = 7;
            this.DiameterBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label15
            // 
            this.Label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(39, 55);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(58, 13);
            this.Label15.TabIndex = 8;
            this.Label15.Text = "目标节点:";
            // 
            // TargetBox
            // 
            this.TargetBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TargetBox.Location = new System.Drawing.Point(103, 51);
            this.TargetBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TargetBox.Name = "TargetBox";
            this.TargetBox.Size = new System.Drawing.Size(108, 20);
            this.TargetBox.TabIndex = 9;
            this.TargetBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TargetBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TargetBox.ValueChanged += new System.EventHandler(this.TargetBox_ValueChanged);
            // 
            // Label16
            // 
            this.Label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(229, 55);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(82, 13);
            this.Label16.TabIndex = 10;
            this.Label16.Text = "最短路径长度:";
            // 
            // PathBox
            // 
            this.PathBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PathBox.Location = new System.Drawing.Point(317, 51);
            this.PathBox.Name = "PathBox";
            this.PathBox.ReadOnly = true;
            this.PathBox.Size = new System.Drawing.Size(108, 20);
            this.PathBox.TabIndex = 11;
            this.PathBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabCenter
            // 
            this.tabCenter.BackColor = System.Drawing.SystemColors.Control;
            this.tabCenter.Controls.Add(this.CenterLayout);
            this.tabCenter.Location = new System.Drawing.Point(4, 22);
            this.tabCenter.Name = "tabCenter";
            this.tabCenter.Padding = new System.Windows.Forms.Padding(3);
            this.tabCenter.Size = new System.Drawing.Size(434, 401);
            this.tabCenter.TabIndex = 1;
            this.tabCenter.Text = "中心度参数";
            // 
            // CenterLayout
            // 
            this.CenterLayout.ColumnCount = 4;
            this.CenterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.CenterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CenterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.CenterLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.CenterLayout.Controls.Add(this.Label13, 2, 1);
            this.CenterLayout.Controls.Add(this.LoopBox, 3, 1);
            this.CenterLayout.Controls.Add(this.ClusterBox, 3, 0);
            this.CenterLayout.Controls.Add(this.Label12, 2, 0);
            this.CenterLayout.Controls.Add(this.CloseBox, 3, 2);
            this.CenterLayout.Controls.Add(this.Label14, 2, 2);
            this.CenterLayout.Controls.Add(this.label1, 0, 0);
            this.CenterLayout.Controls.Add(this.AveClusterBox, 1, 0);
            this.CenterLayout.Controls.Add(this.label2, 0, 1);
            this.CenterLayout.Controls.Add(this.label3, 0, 2);
            this.CenterLayout.Controls.Add(this.AveLoopBox, 1, 1);
            this.CenterLayout.Controls.Add(this.AveCloseBox, 1, 2);
            this.CenterLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterLayout.Location = new System.Drawing.Point(3, 3);
            this.CenterLayout.Name = "CenterLayout";
            this.CenterLayout.RowCount = 4;
            this.CenterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.CenterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.CenterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.CenterLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 246F));
            this.CenterLayout.Size = new System.Drawing.Size(428, 395);
            this.CenterLayout.TabIndex = 1;
            // 
            // Label13
            // 
            this.Label13.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(263, 67);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(58, 13);
            this.Label13.TabIndex = 3;
            this.Label13.Text = "环路系数:";
            // 
            // LoopBox
            // 
            this.LoopBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LoopBox.Location = new System.Drawing.Point(327, 63);
            this.LoopBox.Name = "LoopBox";
            this.LoopBox.ReadOnly = true;
            this.LoopBox.Size = new System.Drawing.Size(98, 20);
            this.LoopBox.TabIndex = 4;
            // 
            // ClusterBox
            // 
            this.ClusterBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ClusterBox.Location = new System.Drawing.Point(327, 14);
            this.ClusterBox.Name = "ClusterBox";
            this.ClusterBox.ReadOnly = true;
            this.ClusterBox.Size = new System.Drawing.Size(98, 20);
            this.ClusterBox.TabIndex = 2;
            // 
            // Label12
            // 
            this.Label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(263, 18);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(58, 13);
            this.Label12.TabIndex = 1;
            this.Label12.Text = "聚类系数:";
            // 
            // CloseBox
            // 
            this.CloseBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseBox.Location = new System.Drawing.Point(327, 112);
            this.CloseBox.Name = "CloseBox";
            this.CloseBox.ReadOnly = true;
            this.CloseBox.Size = new System.Drawing.Size(98, 20);
            this.CloseBox.TabIndex = 7;
            // 
            // Label14
            // 
            this.Label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(251, 116);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(70, 13);
            this.Label14.TabIndex = 5;
            this.Label14.Text = "接近中心度:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "平均聚类系数:";
            // 
            // AveClusterBox
            // 
            this.AveClusterBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AveClusterBox.Location = new System.Drawing.Point(113, 14);
            this.AveClusterBox.Name = "AveClusterBox";
            this.AveClusterBox.ReadOnly = true;
            this.AveClusterBox.Size = new System.Drawing.Size(98, 20);
            this.AveClusterBox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "平均环路系数:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "平均接近中心度:";
            // 
            // AveLoopBox
            // 
            this.AveLoopBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AveLoopBox.Location = new System.Drawing.Point(113, 63);
            this.AveLoopBox.Name = "AveLoopBox";
            this.AveLoopBox.ReadOnly = true;
            this.AveLoopBox.Size = new System.Drawing.Size(98, 20);
            this.AveLoopBox.TabIndex = 12;
            // 
            // AveCloseBox
            // 
            this.AveCloseBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AveCloseBox.Location = new System.Drawing.Point(113, 112);
            this.AveCloseBox.Name = "AveCloseBox";
            this.AveCloseBox.ReadOnly = true;
            this.AveCloseBox.Size = new System.Drawing.Size(98, 20);
            this.AveCloseBox.TabIndex = 13;
            // 
            // tabPageRank
            // 
            this.tabPageRank.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageRank.Controls.Add(this.PageRankLayout);
            this.tabPageRank.Location = new System.Drawing.Point(4, 22);
            this.tabPageRank.Name = "tabPageRank";
            this.tabPageRank.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRank.Size = new System.Drawing.Size(434, 401);
            this.tabPageRank.TabIndex = 2;
            this.tabPageRank.Text = "PageRank";
            // 
            // PageRankLayout
            // 
            this.PageRankLayout.ColumnCount = 4;
            this.PageRankLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.PageRankLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PageRankLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.PageRankLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.PageRankLayout.Controls.Add(this.label4, 0, 0);
            this.PageRankLayout.Controls.Add(this.PageRankBox, 1, 0);
            this.PageRankLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PageRankLayout.Location = new System.Drawing.Point(3, 3);
            this.PageRankLayout.Name = "PageRankLayout";
            this.PageRankLayout.RowCount = 2;
            this.PageRankLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PageRankLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 349F));
            this.PageRankLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.PageRankLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.PageRankLayout.Size = new System.Drawing.Size(428, 395);
            this.PageRankLayout.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "PageRank:";
            // 
            // PageRankBox
            // 
            this.PageRankBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PageRankBox.Location = new System.Drawing.Point(113, 13);
            this.PageRankBox.Name = "PageRankBox";
            this.PageRankBox.ReadOnly = true;
            this.PageRankBox.Size = new System.Drawing.Size(98, 20);
            this.PageRankBox.TabIndex = 10;
            this.PageRankBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabKshell
            // 
            this.tabKshell.BackColor = System.Drawing.SystemColors.Control;
            this.tabKshell.Controls.Add(this.KshellLayout);
            this.tabKshell.Location = new System.Drawing.Point(4, 22);
            this.tabKshell.Name = "tabKshell";
            this.tabKshell.Padding = new System.Windows.Forms.Padding(3);
            this.tabKshell.Size = new System.Drawing.Size(434, 401);
            this.tabKshell.TabIndex = 3;
            this.tabKshell.Text = "K-Shell";
            // 
            // KshellLayout
            // 
            this.KshellLayout.ColumnCount = 4;
            this.KshellLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.KshellLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.KshellLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.KshellLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.KshellLayout.Controls.Add(this.label5, 0, 0);
            this.KshellLayout.Controls.Add(this.KshellBox, 1, 0);
            this.KshellLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KshellLayout.Location = new System.Drawing.Point(3, 3);
            this.KshellLayout.Name = "KshellLayout";
            this.KshellLayout.RowCount = 2;
            this.KshellLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.KshellLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 349F));
            this.KshellLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.KshellLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.KshellLayout.Size = new System.Drawing.Size(428, 395);
            this.KshellLayout.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(64, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "K-Shell:";
            // 
            // KshellBox
            // 
            this.KshellBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.KshellBox.Location = new System.Drawing.Point(113, 13);
            this.KshellBox.Name = "KshellBox";
            this.KshellBox.ReadOnly = true;
            this.KshellBox.Size = new System.Drawing.Size(98, 20);
            this.KshellBox.TabIndex = 10;
            this.KshellBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DiaParameter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 433);
            this.Controls.Add(this.BottomLayout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DiaParameter";
            this.Text = "参数计算";
            this.Load += new System.EventHandler(this.DiaParameter_Load);
            this.BottomLayout.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabDistance.ResumeLayout(false);
            this.DistanceLayout.ResumeLayout(false);
            this.DistanceLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TargetBox)).EndInit();
            this.tabCenter.ResumeLayout(false);
            this.CenterLayout.ResumeLayout(false);
            this.CenterLayout.PerformLayout();
            this.tabPageRank.ResumeLayout(false);
            this.PageRankLayout.ResumeLayout(false);
            this.PageRankLayout.PerformLayout();
            this.tabKshell.ResumeLayout(false);
            this.KshellLayout.ResumeLayout(false);
            this.KshellLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel BottomLayout;
        internal System.Windows.Forms.ListBox NodeList;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabDistance;
        private System.Windows.Forms.TabPage tabCenter;
        private System.Windows.Forms.TabPage tabPageRank;
        private System.Windows.Forms.TabPage tabKshell;
        internal System.Windows.Forms.TableLayoutPanel DistanceLayout;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.TextBox DensityBox;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.TextBox DiameterBox;
        internal System.Windows.Forms.Label Label15;
        internal System.Windows.Forms.NumericUpDown TargetBox;
        internal System.Windows.Forms.Label Label16;
        internal System.Windows.Forms.TextBox PathBox;
        internal System.Windows.Forms.TableLayoutPanel CenterLayout;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.TextBox ClusterBox;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.TextBox LoopBox;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.TextBox CloseBox;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox AveClusterBox;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox AveLoopBox;
        internal System.Windows.Forms.TextBox AveCloseBox;
        internal System.Windows.Forms.TableLayoutPanel PageRankLayout;
        internal System.Windows.Forms.TableLayoutPanel KshellLayout;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox PageRankBox;
        internal System.Windows.Forms.TextBox KshellBox;


    }
}