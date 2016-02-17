namespace CNSP.Platform
{
    partial class DiaNodeInfo
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
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ExitButton = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.TableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.PosBox = new System.Windows.Forms.TextBox();
            this.TypeBox = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.NodeNum = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.NodeDeg = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.WordBox = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.NodePos = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.LineBox = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.NodeImage = new System.Windows.Forms.PictureBox();
            this.EdgeList = new System.Windows.Forms.ListBox();
            this.TableLayoutPanel1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.TableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NodeImage)).BeginInit();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.TableLayoutPanel1.Controls.Add(this.ExitButton, 0, 2);
            this.TableLayoutPanel1.Controls.Add(this.GroupBox1, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.NodeImage, 1, 0);
            this.TableLayoutPanel1.Controls.Add(this.EdgeList, 1, 1);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 3;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.6755F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.3245F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(332, 364);
            this.TableLayoutPanel1.TabIndex = 1;
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TableLayoutPanel1.SetColumnSpan(this.ExitButton, 2);
            this.ExitButton.Location = new System.Drawing.Point(105, 332);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(121, 26);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "退出";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.TableLayoutPanel2);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupBox1.Location = new System.Drawing.Point(3, 3);
            this.GroupBox1.Name = "GroupBox1";
            this.TableLayoutPanel1.SetRowSpan(this.GroupBox1, 2);
            this.GroupBox1.Size = new System.Drawing.Size(182, 321);
            this.GroupBox1.TabIndex = 2;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "节点信息";
            // 
            // TableLayoutPanel2
            // 
            this.TableLayoutPanel2.ColumnCount = 2;
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 109F));
            this.TableLayoutPanel2.Controls.Add(this.PosBox, 1, 5);
            this.TableLayoutPanel2.Controls.Add(this.TypeBox, 1, 3);
            this.TableLayoutPanel2.Controls.Add(this.Label3, 0, 0);
            this.TableLayoutPanel2.Controls.Add(this.NodeNum, 1, 0);
            this.TableLayoutPanel2.Controls.Add(this.Label4, 0, 1);
            this.TableLayoutPanel2.Controls.Add(this.NodeDeg, 1, 1);
            this.TableLayoutPanel2.Controls.Add(this.Label5, 0, 2);
            this.TableLayoutPanel2.Controls.Add(this.WordBox, 1, 2);
            this.TableLayoutPanel2.Controls.Add(this.Label1, 0, 6);
            this.TableLayoutPanel2.Controls.Add(this.NodePos, 1, 6);
            this.TableLayoutPanel2.Controls.Add(this.Label2, 0, 4);
            this.TableLayoutPanel2.Controls.Add(this.LineBox, 1, 4);
            this.TableLayoutPanel2.Controls.Add(this.Label6, 0, 3);
            this.TableLayoutPanel2.Controls.Add(this.Label7, 0, 5);
            this.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.TableLayoutPanel2.Name = "TableLayoutPanel2";
            this.TableLayoutPanel2.RowCount = 7;
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.TableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.TableLayoutPanel2.Size = new System.Drawing.Size(176, 302);
            this.TableLayoutPanel2.TabIndex = 1;
            // 
            // PosBox
            // 
            this.PosBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PosBox.Location = new System.Drawing.Point(70, 226);
            this.PosBox.Name = "PosBox";
            this.PosBox.ReadOnly = true;
            this.PosBox.Size = new System.Drawing.Size(103, 20);
            this.PosBox.TabIndex = 52;
            // 
            // TypeBox
            // 
            this.TypeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TypeBox.Location = new System.Drawing.Point(70, 140);
            this.TypeBox.Name = "TypeBox";
            this.TypeBox.ReadOnly = true;
            this.TypeBox.Size = new System.Drawing.Size(103, 20);
            this.TypeBox.TabIndex = 51;
            // 
            // Label3
            // 
            this.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(6, 15);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(58, 13);
            this.Label3.TabIndex = 14;
            this.Label3.Text = "节点编号:";
            // 
            // NodeNum
            // 
            this.NodeNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NodeNum.Location = new System.Drawing.Point(70, 11);
            this.NodeNum.Name = "NodeNum";
            this.NodeNum.ReadOnly = true;
            this.NodeNum.Size = new System.Drawing.Size(103, 20);
            this.NodeNum.TabIndex = 24;
            // 
            // Label4
            // 
            this.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(18, 58);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(46, 13);
            this.Label4.TabIndex = 25;
            this.Label4.Text = "节点度:";
            // 
            // NodeDeg
            // 
            this.NodeDeg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NodeDeg.Location = new System.Drawing.Point(70, 54);
            this.NodeDeg.Name = "NodeDeg";
            this.NodeDeg.ReadOnly = true;
            this.NodeDeg.Size = new System.Drawing.Size(103, 20);
            this.NodeDeg.TabIndex = 26;
            // 
            // Label5
            // 
            this.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(6, 101);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(58, 13);
            this.Label5.TabIndex = 39;
            this.Label5.Text = "词语内容:";
            // 
            // WordBox
            // 
            this.WordBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.WordBox.Location = new System.Drawing.Point(70, 97);
            this.WordBox.Name = "WordBox";
            this.WordBox.ReadOnly = true;
            this.WordBox.Size = new System.Drawing.Size(103, 20);
            this.WordBox.TabIndex = 40;
            // 
            // Label1
            // 
            this.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(6, 273);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(58, 13);
            this.Label1.TabIndex = 47;
            this.Label1.Text = "节点位置:";
            // 
            // NodePos
            // 
            this.NodePos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NodePos.Location = new System.Drawing.Point(70, 270);
            this.NodePos.Name = "NodePos";
            this.NodePos.ReadOnly = true;
            this.NodePos.Size = new System.Drawing.Size(103, 20);
            this.NodePos.TabIndex = 48;
            // 
            // Label2
            // 
            this.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(6, 187);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(58, 13);
            this.Label2.TabIndex = 43;
            this.Label2.Text = "语句编号:";
            // 
            // LineBox
            // 
            this.LineBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LineBox.Location = new System.Drawing.Point(70, 183);
            this.LineBox.Name = "LineBox";
            this.LineBox.ReadOnly = true;
            this.LineBox.Size = new System.Drawing.Size(103, 20);
            this.LineBox.TabIndex = 46;
            // 
            // Label6
            // 
            this.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(30, 144);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(34, 13);
            this.Label6.TabIndex = 49;
            this.Label6.Text = "词性:";
            // 
            // Label7
            // 
            this.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(6, 230);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(58, 13);
            this.Label7.TabIndex = 50;
            this.Label7.Text = "句中位置:";
            // 
            // NodeImage
            // 
            this.NodeImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NodeImage.Location = new System.Drawing.Point(191, 3);
            this.NodeImage.Name = "NodeImage";
            this.NodeImage.Size = new System.Drawing.Size(138, 152);
            this.NodeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.NodeImage.TabIndex = 3;
            this.NodeImage.TabStop = false;
            // 
            // EdgeList
            // 
            this.EdgeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EdgeList.FormattingEnabled = true;
            this.EdgeList.Location = new System.Drawing.Point(191, 162);
            this.EdgeList.Name = "EdgeList";
            this.EdgeList.Size = new System.Drawing.Size(138, 162);
            this.EdgeList.TabIndex = 4;
            // 
            // DiaNodeInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 364);
            this.Controls.Add(this.TableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DiaNodeInfo";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "节点信息查看";
            this.Load += new System.EventHandler(this.DiaNodeInfo_Load);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.TableLayoutPanel2.ResumeLayout(false);
            this.TableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NodeImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Button ExitButton;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel2;
        internal System.Windows.Forms.TextBox PosBox;
        internal System.Windows.Forms.TextBox TypeBox;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox NodeNum;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox NodeDeg;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox WordBox;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox NodePos;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox LineBox;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.PictureBox NodeImage;
        internal System.Windows.Forms.ListBox EdgeList;
    }
}