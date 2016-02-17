namespace CNSP.Platform.Parameter
{
    partial class DiaParaChoice
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
            this.MainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ControlLayout = new System.Windows.Forms.TableLayoutPanel();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.OK_Button = new System.Windows.Forms.Button();
            this.DistanceBox = new System.Windows.Forms.CheckBox();
            this.CenterBox = new System.Windows.Forms.CheckBox();
            this.PageRankBox = new System.Windows.Forms.CheckBox();
            this.KshellBox = new System.Windows.Forms.CheckBox();
            this.MainLayout.SuspendLayout();
            this.ControlLayout.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainLayout
            // 
            this.MainLayout.ColumnCount = 5;
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.MainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.MainLayout.Controls.Add(this.ControlLayout, 1, 5);
            this.MainLayout.Controls.Add(this.DistanceBox, 2, 1);
            this.MainLayout.Controls.Add(this.CenterBox, 2, 2);
            this.MainLayout.Controls.Add(this.PageRankBox, 2, 3);
            this.MainLayout.Controls.Add(this.KshellBox, 2, 4);
            this.MainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayout.Location = new System.Drawing.Point(0, 0);
            this.MainLayout.Name = "MainLayout";
            this.MainLayout.RowCount = 6;
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.MainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.MainLayout.Size = new System.Drawing.Size(294, 348);
            this.MainLayout.TabIndex = 0;
            // 
            // ControlLayout
            // 
            this.ControlLayout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ControlLayout.ColumnCount = 2;
            this.MainLayout.SetColumnSpan(this.ControlLayout, 3);
            this.ControlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ControlLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ControlLayout.Controls.Add(this.Cancel_Button, 1, 0);
            this.ControlLayout.Controls.Add(this.OK_Button, 0, 0);
            this.ControlLayout.Location = new System.Drawing.Point(64, 300);
            this.ControlLayout.Name = "ControlLayout";
            this.ControlLayout.RowCount = 1;
            this.ControlLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ControlLayout.Size = new System.Drawing.Size(164, 29);
            this.ControlLayout.TabIndex = 6;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel_Button.Location = new System.Drawing.Point(85, 3);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(76, 23);
            this.Cancel_Button.TabIndex = 1;
            this.Cancel_Button.Text = "取消";
            // 
            // OK_Button
            // 
            this.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK_Button.Location = new System.Drawing.Point(3, 3);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(76, 23);
            this.OK_Button.TabIndex = 0;
            this.OK_Button.Text = "确定";
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // DistanceBox
            // 
            this.DistanceBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DistanceBox.AutoSize = true;
            this.DistanceBox.Checked = true;
            this.DistanceBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DistanceBox.Location = new System.Drawing.Point(101, 46);
            this.DistanceBox.Name = "DistanceBox";
            this.DistanceBox.Size = new System.Drawing.Size(86, 17);
            this.DistanceBox.TabIndex = 7;
            this.DistanceBox.Text = "节点间距离";
            this.DistanceBox.UseVisualStyleBackColor = true;
            // 
            // CenterBox
            // 
            this.CenterBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CenterBox.AutoSize = true;
            this.CenterBox.Checked = true;
            this.CenterBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CenterBox.Location = new System.Drawing.Point(101, 111);
            this.CenterBox.Name = "CenterBox";
            this.CenterBox.Size = new System.Drawing.Size(86, 17);
            this.CenterBox.TabIndex = 8;
            this.CenterBox.Text = "中心度参数";
            this.CenterBox.UseVisualStyleBackColor = true;
            // 
            // PageRankBox
            // 
            this.PageRankBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PageRankBox.AutoSize = true;
            this.PageRankBox.Checked = true;
            this.PageRankBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PageRankBox.Location = new System.Drawing.Point(101, 176);
            this.PageRankBox.Name = "PageRankBox";
            this.PageRankBox.Size = new System.Drawing.Size(77, 17);
            this.PageRankBox.TabIndex = 9;
            this.PageRankBox.Text = "PageRank";
            this.PageRankBox.UseVisualStyleBackColor = true;
            // 
            // KshellBox
            // 
            this.KshellBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.KshellBox.AutoSize = true;
            this.KshellBox.Checked = true;
            this.KshellBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.KshellBox.Location = new System.Drawing.Point(101, 241);
            this.KshellBox.Name = "KshellBox";
            this.KshellBox.Size = new System.Drawing.Size(59, 17);
            this.KshellBox.TabIndex = 10;
            this.KshellBox.Text = "K-Shell";
            this.KshellBox.UseVisualStyleBackColor = true;
            // 
            // DiaParaChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(294, 348);
            this.Controls.Add(this.MainLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DiaParaChoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "待计算参数选择";
            this.MainLayout.ResumeLayout(false);
            this.MainLayout.PerformLayout();
            this.ControlLayout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainLayout;
        internal System.Windows.Forms.TableLayoutPanel ControlLayout;
        internal System.Windows.Forms.Button Cancel_Button;
        internal System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.CheckBox DistanceBox;
        private System.Windows.Forms.CheckBox CenterBox;
        private System.Windows.Forms.CheckBox PageRankBox;
        private System.Windows.Forms.CheckBox KshellBox;
    }
}