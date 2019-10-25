using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Apriori
{
    public partial class frmOutput : Form
    {
        public frmOutput(Dictionary<string, double> dicFrequentItems, Dictionary<string, Dictionary<string, double>> dicClosedItemSets, List<string> lstMaximalItemSets, List<clssRules> lstStrongRules)
        {
            InitializeComponent();
            LoadClosedItems(dicClosedItemSets);
            lb_maximal.DataSource = lstMaximalItemSets;
            LoadFrequentItems(dicFrequentItems);
            LoadRules(lstStrongRules);
        }

        private void LoadClosedItems(Dictionary<string, Dictionary<string, double>> dicClosedItemSets)
        {
            foreach (string strItem in dicClosedItemSets.Keys)
            {
                lb_closed.Items.Add(strItem);
            }
        }

        private void LoadRules(List<clssRules> lstStrongRules)
        {
            foreach (clssRules Rule in lstStrongRules)
            {
                ListViewItem lvi = new ListViewItem(Rule.X + "-->" + Rule.Y);
                lvi.SubItems.Add(String.Format("{0:0.00}", (Rule.Confidence * 100)) + "%");
                lv_Rules.Items.Add(lvi);
            }
        }

        private void LoadFrequentItems(Dictionary<string, double> dicFrequentItems)
        {
            foreach (string strItem in dicFrequentItems.Keys)
            {
                ListViewItem lvi = new ListViewItem(strItem);
                lvi.SubItems.Add(dicFrequentItems[strItem].ToString());
                lv_Frequent.Items.Add(lvi);
            }
        }
    }
}
