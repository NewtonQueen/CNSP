using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CNSP.Platform.Parameter
{
    public partial class DiaParaChoice : Form
    {
        public int intChoice = 0;
        const int intDistance = 0x1;
        const int intCenter = 0x2;
        const int intPageRank = 0x4;
        const int intKshell = 0x8;

        public DiaParaChoice()
        {
            InitializeComponent();
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            UpdateChoice();
        }

        void UpdateChoice()
        {
            if (DistanceBox.Checked == true)
            {
                intChoice |= intDistance;
            }
            if (CenterBox.Checked == true)
            {
                intChoice |= intCenter;
            }
            if (PageRankBox.Checked == true)
            {
                intChoice |= intPageRank;
            }
            if (KshellBox.Checked == true)
            {
                intChoice |= intKshell;
            }
        }
    }
}
