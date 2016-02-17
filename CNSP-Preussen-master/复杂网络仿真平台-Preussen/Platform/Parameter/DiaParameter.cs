using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace CNSP.Platform.Parameter
{
    public partial class DiaParameter : Form
    {
        FrmMain father;
        pNet curNetwork;
        int intChoice = 0;
        DistanceStrategy disStrategy;
        CoefficientStrategy coeStrategy;
        PageRankStrategy prStrategy;
        KShellStrategy kshellStrategy;

        const int intDistance = 0x1;
        const int intCenter = 0x2;
        const int intPageRank = 0x4;
        const int intKshell = 0x8;

        public DiaParameter(FrmMain owner)
        {
            InitializeComponent();
            //设置FrmMain为父窗体，可以读取父窗体数据
            father = owner;
            XmlDocument doc = father.ComplexNet.ToXML();
            curNetwork = new pNet(doc);
        }

        private void DiaParameter_Load(object sender, EventArgs e)
        {
            DiaParaChoice diaParaChoice = null;

            if (diaParaChoice == null)
            {
                diaParaChoice = new DiaParaChoice();
            }
            tabMain.TabPages.Clear();
            TargetBox.Maximum = curNetwork.intNumber - 1;
            LoadList();
            diaParaChoice.ShowDialog(this);
            intChoice = diaParaChoice.intChoice;
            diaParaChoice.Dispose();
            Calculate();
        }

        //执行参数计算
        void Calculate()
        {
            //距离参数
            if ((intChoice & intDistance) == intDistance)
            {
                disStrategy = new DistanceStrategy(curNetwork.Number);
                disStrategy.Calculate(curNetwork);
                tabMain.TabPages.Add(tabDistance);
                LoadDistanceResult(disStrategy);
            }
            //中心度参数
            if ((intChoice & intCenter) == intCenter)
            {
                coeStrategy = new CoefficientStrategy(curNetwork.Number);
                coeStrategy.Calculate(curNetwork);
                tabMain.TabPages.Add(tabCenter);
                LoadCenterResult(coeStrategy);
            }
            //PageRank
            if ((intChoice & intPageRank) == intPageRank)
            {
                prStrategy = new PageRankStrategy(curNetwork.Number);
                prStrategy.Calculate(curNetwork, 30);
                tabMain.TabPages.Add(tabPageRank);
                LoadPageRankResult(prStrategy);
            }
            //K-Shell
            if ((intChoice & intKshell) == intKshell)
            {
                kshellStrategy = new KShellStrategy(curNetwork.Number);
                kshellStrategy.Calculate(curNetwork);
                tabMain.TabPages.Add(tabKshell);
                LoadKshellResult(kshellStrategy);
            }
        }

        //读取节点列表
        private void LoadList()
        {
            string strNode = "";
            int i;

            for (i = 0; i < curNetwork.intNumber; i++)
            {
                strNode = "节点" + i.ToString() + ",度：" + curNetwork.Network[i].Degree.ToString();
                NodeList.Items.Add(strNode);
            }
        }

        //读取距离参数计算结果
        void LoadDistanceResult(DistanceStrategy disStrategy)
        {
            DensityBox.Text = Convert.ToSingle(disStrategy.AveDistance).ToString();
            DiameterBox.Text = disStrategy.Diameter.ToString();
        }

        //读取中心度参数计算结果
        void LoadCenterResult(CoefficientStrategy coeStrategy)
        {
            AveClusterBox.Text = Convert.ToSingle(coeStrategy.AveCluster).ToString();
            AveLoopBox.Text = Convert.ToSingle(coeStrategy.AveLoop).ToString();
            AveCloseBox.Text = Convert.ToSingle(coeStrategy.AveClose).ToString();
        }

        //读取PageRank计算结果
        void LoadPageRankResult(PageRankStrategy prStrategy)
        {

        }

        //读取Kshell计算结果
        void LoadKshellResult(KShellStrategy kshellStrategy)
        {

        }

        //目标节点选择框
        private void TargetBox_ValueChanged(object sender, EventArgs e)
        {
            ShortestPath();
        }

        //起始节点选择框选择函数
        private void NodeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabMain.Contains(tabDistance) == true)
            {
                ShortestPath();
            }
            if (tabMain.Contains(tabCenter) == true)
            {
                CenterPara();
            }
            if (tabMain.Contains(tabPageRank) == true)
            {
                PageRankValue();
            }
            if (tabMain.Contains(tabKshell) == true)
            {
                KshellValue();
            }
        }

        // 获取最短距离
        void ShortestPath()
        {
            int intSource, intTarget;

            intSource = NodeList.SelectedIndex;
            if (intSource == -1)
            {
                return;
            }
            intTarget = (int)TargetBox.Value;
            PathBox.Text = disStrategy.Distance[intSource,intTarget].ToString();
        }

        //读取中心度参数
        void CenterPara()
        {
            int intSource;

            intSource = NodeList.SelectedIndex;
            if (intSource == -1)
            {
                return;
            }
            ClusterBox.Text = Convert.ToSingle(coeStrategy.dubCluster[intSource]).ToString();
            LoopBox.Text = Convert.ToSingle(coeStrategy.dubLoop[intSource]).ToString();
            CloseBox.Text = Convert.ToSingle(coeStrategy.dubClose[intSource]).ToString();
        }

        //读取PageRank
        void PageRankValue()
        {
            int intSource;

            intSource = NodeList.SelectedIndex;
            if (intSource == -1)
            {
                return;
            }
            PageRankBox.Text = Convert.ToSingle(prStrategy.dubPageRank[intSource]).ToString();
        }

        //读取K-Shell
        void KshellValue()
        {
            int intSource;

            intSource = NodeList.SelectedIndex;
            if (intSource == -1)
            {
                return;
            }
            KshellBox.Text = Convert.ToSingle(kshellStrategy.intKShell[intSource]).ToString();
        }

    }
}
