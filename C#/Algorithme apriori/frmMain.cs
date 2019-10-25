using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Apriori
{
    public partial class frmMain : Form
    {
        #region Global Variables
        Dictionary<int, string> m_dicTransactions = new Dictionary<int, string>();
        Dictionary<string, double> m_dicAllFrequentItems = new Dictionary<string, double>();
        int m_nLastTransId = 1;
        #endregion

        public frmMain()
        {
            InitializeComponent();
        }

        private void btn_AddItem_Click(object sender, EventArgs e)
        {
            if (ValidateInput(txt_Item, false))
            {
                string strNewItem = txt_Item.Text;
                foreach (ListViewItem lvItem in lv_Items.Items)
                {
                    if (lvItem.Text == strNewItem)
                    {
                        MessageBox.Show("Item (" + strNewItem + ") already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_Item.Text = string.Empty;
                        return;
                    }
                }
                lv_Items.Items.Add(strNewItem);
                txt_Item.Text = string.Empty;
            }
        }

        private void btn_DeleteItem_Click(object sender, EventArgs e)
        {
            if (lv_Items.CheckedItems.Count > 0)
            {
                for (int i = lv_Items.CheckedItems.Count - 1; i >= 0; i--)
                {
                    List<int> lst_Transactions = new List<int>();
                    string strItemtoDelete = lv_Items.CheckedItems[i].ToString();
                    if (ItemIsRemovable(strItemtoDelete, ref lst_Transactions))
                    {
                        lv_Items.Items.Remove(lv_Items.CheckedItems[i]);
                    }
                    else
                    {
                        string strTransactions = string.Empty;
                        foreach (int nTransactionId in lst_Transactions)
                        {
                            strTransactions += nTransactionId.ToString() + ",";
                        }
                        strTransactions = strTransactions.Remove(strTransactions.Length - 1);
                        MessageBox.Show("Can not delete item " + strItemtoDelete + ", item exists in transactions " + strTransactions, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
                MessageBox.Show("please choose items to add", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private bool ValidateInput(TextBox txtBox, bool bIsNumber)
        {
            if (txtBox.Text.Length == 0)
            {
                errorProvider1.SetError(txtBox, "please enter value");
                return false;
            }
            else
            {
                if (bIsNumber && int.Parse(txtBox.Text) > 100)
                {
                    errorProvider1.SetError(txtBox, "please enter value between 0 and 100");
                    return false;
                }
                else
                {
                    errorProvider1.SetError(txtBox, "");
                    return true;
                }
            }
        }

        private void btn_AddTrans_Click(object sender, EventArgs e)
        {
            if (lv_Items.CheckedItems.Count <= 0)
            {
                MessageBox.Show("please choose items to add", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string strTransactiondic;
            string strTransactionLV = GetTransactionFromListView(out strTransactiondic);
            ListViewItem lvi = new ListViewItem(m_nLastTransId.ToString());
            lvi.Tag = m_nLastTransId;
            lvi.SubItems.Add(strTransactionLV);
            lv_Transactions.Items.Add(lvi);
            m_dicTransactions.Add(m_nLastTransId, strTransactiondic);
            m_nLastTransId++;

        }

        private void btn_EditTrans_Click(object sender, EventArgs e)
        {
            int nChosenTransactions = lv_Transactions.CheckedItems.Count;
            if (nChosenTransactions > 1 || nChosenTransactions == 0)
            {
                MessageBox.Show("please choose one transaction to modify", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            EnableControls(false);
            int nTransId = (int)lv_Transactions.CheckedItems[0].Tag;
            string strTransaction = m_dicTransactions[nTransId];
            foreach (ListViewItem lvi in lv_Items.Items)
            {
                lvi.Checked = false;
            }
            foreach (char cItem in strTransaction)
            {
                for (int i = 0; i < lv_Items.Items.Count; i++)
                {
                    if (lv_Items.Items[i].Text == cItem.ToString())
                    {
                        lv_Items.Items[i].Checked = true;
                    }
                }
            }
        }

        private void btn_EndEdit_Click(object sender, EventArgs e)
        {
            EnableControls(true);
            int nTransId = (int)lv_Transactions.CheckedItems[0].Tag;
            string strTransactiondic;
            string strTransactionLV = GetTransactionFromListView(out strTransactiondic);
            m_dicTransactions[nTransId] = strTransactiondic;
            ListViewItem lvi = lv_Transactions.CheckedItems[0];
            lvi.SubItems.Clear();
            lvi.SubItems[0].Text = nTransId.ToString();
            lvi.SubItems.Add(strTransactionLV);
        }

        private void btn_DeleteTrans_Click(object sender, EventArgs e)
        {
            int nChosenTransactions = lv_Transactions.CheckedItems.Count;
            if (nChosenTransactions < 1)
            {
                MessageBox.Show("please choose at least one transaction to delete", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            for (int i = 0; i < lv_Transactions.CheckedItems.Count; i++)
            {
                m_dicTransactions.Remove((int)lv_Transactions.CheckedItems[i].Tag);
                lv_Transactions.Items.Remove(lv_Transactions.CheckedItems[i]);
            }
        }

        private void btn_ClearTransactions_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear All Transactions ?", "Apriori", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                m_nLastTransId = 1;
                lv_Transactions.Items.Clear();
                m_dicTransactions.Clear();
            }
        }

        private void btn_Solve_Click(object sender, EventArgs e)
        {
            #region validation
            if (!ValidateInput(txt_Support, true) || !ValidateInput(txt_Confidence, true))
            {
                return;
            }
            if (lv_Transactions.Items.Count <= 0)
            {
                MessageBox.Show("Enter Transactions first", "Apriori", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            #endregion
            Solve();
        }

        private void txt_Confidence_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private void txt_Item_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back;
        }

        private string GetTransactionFromListView(out string strTransactiondic)
        {
            strTransactiondic = string.Empty;
            string strTransactionReturn = string.Empty;
            foreach (ListViewItem lviCheckedItem in lv_Items.CheckedItems)
            {
                strTransactiondic += lviCheckedItem.Text;
                strTransactionReturn += lviCheckedItem.Text + ",";
            }
            strTransactionReturn = strTransactionReturn.Remove(strTransactionReturn.Length - 1);
            return strTransactionReturn;
        }

        private void Solve()
        {
            double dMinSupport = double.Parse(txt_Support.Text) / 100;
            double dMinConfidence = double.Parse(txt_Confidence.Text) / 100;
            ////Scan the transaction database to get the support S of each 1-itemset,
            Dictionary<string, double> dic_FrequentItemsL1 = GetL1FrequentItems(dMinSupport);

            Dictionary<string, double> dic_FrequentItems = dic_FrequentItemsL1;
            Dictionary<string, double> dic_Candidates = new Dictionary<string, double>();
            do
            {
                dic_Candidates = GenerateCandidates(dic_FrequentItems);
                dic_FrequentItems = GetFrequentItems(dic_Candidates, dMinSupport);
            }
            while (dic_Candidates.Count != 0);

            Dictionary<string, Dictionary<string, double>> dicClosedItemSets = GetClosedItemSets();
            List<string> lstMaximalItemSets = GetMaximalItemSets(dicClosedItemSets);
            List<clssRules> lstRules = GenerateRules();
            List<clssRules> lstStrongRules = GetStrongRules(dMinConfidence, lstRules);
            frmOutput objfrmOutput = new frmOutput(m_dicAllFrequentItems,
                                                   dicClosedItemSets,
                                                   lstMaximalItemSets,
                                                   lstStrongRules);
            objfrmOutput.ShowDialog();
        }

        private Dictionary<string, Dictionary<string, double>> GetClosedItemSets()
        {
            Dictionary<string, Dictionary<string, double>> dicClosedItemSetsReturn = new Dictionary<string, Dictionary<string, double>>();
            Dictionary<string, double> dicParents;
            for (int i = 0; i < m_dicAllFrequentItems.Count; i++)
            {
                string strChild = m_dicAllFrequentItems.Keys.ElementAt(i);
                dicParents = GetItemParents(strChild, i + 1);
                if (IsClosed(strChild, dicParents))
                    dicClosedItemSetsReturn.Add(strChild, dicParents);
            }
            return dicClosedItemSetsReturn;
        }

        private List<string> GetMaximalItemSets(Dictionary<string, Dictionary<string, double>> dicClosedItemSets)
        {
            List<string> lstMaximalItemSetsReturn = new List<string>();
            Dictionary<string, double> dicParents;
            foreach (string strItem in dicClosedItemSets.Keys)
            {
                dicParents = dicClosedItemSets[strItem];
                if (dicParents.Count == 0)
                    lstMaximalItemSetsReturn.Add(strItem);
            }
            return lstMaximalItemSetsReturn;
        }

        private bool IsClosed(string strChild, Dictionary<string, double> dicParents)
        {
            foreach (string strParent in dicParents.Keys)
            {
                if (m_dicAllFrequentItems[strChild] == m_dicAllFrequentItems[strParent])
                {
                    return false;
                }
            }
            return true;
        }

        private Dictionary<string, double> GetItemParents(string strChild, int nIndex)
        {
            Dictionary<string, double> dicParents = new Dictionary<string, double>();
            for (int j = nIndex; j < m_dicAllFrequentItems.Count; j++)
            {
                string strParent = m_dicAllFrequentItems.Keys.ElementAt(j);
                if (strParent.Length == strChild.Length + 1)
                {
                    if (IsSubstring(strChild, strParent))
                    {
                        dicParents.Add(strParent, m_dicAllFrequentItems[strParent]);
                    }
                }
            }
            return dicParents;
        }

        private List<clssRules> GetStrongRules(double dMinConfidence, List<clssRules> lstRules)
        {
            List<clssRules> lstStrongRulesReturn = new List<clssRules>();
            foreach (clssRules Rule in lstRules)
            {
                string strXY = Alphabetize(Rule.X + Rule.Y);
                AddStrongRule(Rule, strXY, ref lstStrongRulesReturn, dMinConfidence);
            }
            lstStrongRulesReturn.Sort();
            return lstStrongRulesReturn;
        }

        private void AddStrongRule(clssRules Rule, string strXY, ref List<clssRules> lstStrongRulesReturn, double dMinConfidence)
        {
            double dConfidence = GetConfidence(Rule.X, strXY);
            clssRules NewRule;
            if (dConfidence >= dMinConfidence)
            {
                NewRule = new clssRules(Rule.X, Rule.Y, dConfidence);
                lstStrongRulesReturn.Add(NewRule);
            }
            dConfidence = GetConfidence(Rule.Y, strXY);
            if (dConfidence >= dMinConfidence)
            {
                NewRule = new clssRules(Rule.Y, Rule.X, dConfidence);
                lstStrongRulesReturn.Add(NewRule);
            }
        }

        private double GetConfidence(string strX, string strXY)
        {
            double dSupport_X, dSupport_XY;
            dSupport_X = m_dicAllFrequentItems[strX];
            dSupport_XY = m_dicAllFrequentItems[strXY];
            return dSupport_XY / dSupport_X;
        }

        private List<clssRules> GenerateRules()
        {
            List<clssRules> lstRulesReturn = new List<clssRules>();
            foreach (string strItem in m_dicAllFrequentItems.Keys)
            {
                if (strItem.Length > 1)
                {
                    int nMaxCombinationLength = strItem.Length / 2;
                    GenerateCombination(strItem, nMaxCombinationLength, ref lstRulesReturn);
                }
            }
            return lstRulesReturn;
        }

        private void GenerateCombination(string strItem, int nCombinationLength, ref List<clssRules> lstRulesReturn)
        {
            int nItemLength = strItem.Length;
            if (nItemLength == 2)
            {
                AddItem(strItem[0].ToString(), strItem, ref lstRulesReturn);
                return;
            }
            else if (nItemLength == 3)
            {
                for (int i = 0; i < nItemLength; i++)
                {
                    AddItem(strItem[i].ToString(), strItem, ref lstRulesReturn);
                }
                return;
            }
            else
            {
                for (int i = 0; i < nItemLength; i++)
                {
                    GetCombinationRecursive(strItem[i].ToString(), strItem, nCombinationLength, ref lstRulesReturn);
                }
            }
        }

        private void AddItem(string strCombination, string strItem, ref List<clssRules> lstRulesReturn)
        {
            string strRemaining = GetRemaining(strCombination, strItem);
            clssRules Rule = new clssRules(strCombination, strRemaining, 0);
            lstRulesReturn.Add(Rule);
        }

        private string GetCombinationRecursive(string strCombination, string strItem, int nCombinationLength, ref List<clssRules> lstRulesReturn)
        {
            AddItem(strCombination, strItem, ref lstRulesReturn);
            char cLastTokenCharacter = strCombination[strCombination.Length - 1];
            int nLastTokenCharcaterIndex = strCombination.IndexOf(cLastTokenCharacter);
            int nLastTokenCharcaterIndexInParent = strItem.IndexOf(cLastTokenCharacter);
            char cNextCharacter;
            char cLastItemCharacter = strItem[strItem.Length - 1];
            if (strCombination.Length == nCombinationLength)
            {
                if (cLastTokenCharacter != cLastItemCharacter)
                {
                    strCombination = strCombination.Remove(nLastTokenCharcaterIndex, 1);
                    cNextCharacter = strItem[nLastTokenCharcaterIndexInParent + 1];
                    string strNewToken = strCombination + cNextCharacter;
                    return (GetCombinationRecursive(strNewToken, strItem, nCombinationLength, ref lstRulesReturn));
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                if (strCombination != cLastItemCharacter.ToString())
                {
                    cNextCharacter = strItem[nLastTokenCharcaterIndexInParent + 1];
                    string strNewToken = strCombination + cNextCharacter;
                    return (GetCombinationRecursive(strNewToken, strItem, nCombinationLength, ref lstRulesReturn));
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        private string GetRemaining(string strChild, string strParent)
        {
            for (int i = 0; i < strChild.Length; i++)
            {
                int nIndex = strParent.IndexOf(strChild[i]);
                strParent = strParent.Remove(nIndex, 1);
            }
            return strParent;
        }

        private Dictionary<string, double> GetFrequentItems(Dictionary<string, double> dic_Candidates, double dMinSupport)
        {
            Dictionary<string, double> dic_FrequentReturn = new Dictionary<string, double>();
            for (int i = dic_Candidates.Count - 1; i >= 0; i--)
            {
                string strItem = dic_Candidates.Keys.ElementAt(i);
                double dSupport = dic_Candidates[strItem];
                if ((dSupport / (double)(m_nLastTransId - 1) >= dMinSupport))
                {
                    dic_FrequentReturn.Add(strItem, dSupport);
                    m_dicAllFrequentItems.Add(strItem, dSupport);
                }
            }
            return dic_FrequentReturn;
        }

        private Dictionary<string, double> GenerateCandidates(Dictionary<string, double> dic_FrequentItems)
        {
            Dictionary<string, double> dic_CandidatesReturn = new Dictionary<string, double>();
            for (int i = 0; i < dic_FrequentItems.Count - 1; i++)
            {
                string strFirstItem = Alphabetize(dic_FrequentItems.Keys.ElementAt(i));
                for (int j = i + 1; j < dic_FrequentItems.Count; j++)
                {
                    string strSecondItem = Alphabetize(dic_FrequentItems.Keys.ElementAt(j));
                    string strGeneratedCandidate = GetCandidate(strFirstItem, strSecondItem);
                    if (strGeneratedCandidate != string.Empty)
                    {
                        strGeneratedCandidate = Alphabetize(strGeneratedCandidate);
                        double dSupport = GetSupport(strGeneratedCandidate);
                        dic_CandidatesReturn.Add(strGeneratedCandidate, dSupport);
                    }
                }
            }
            return dic_CandidatesReturn;
        }

        private string Alphabetize(string strToken)
        {
            // Convert to char array, then sort and return
            char[] arrToken = strToken.ToCharArray();
            Array.Sort(arrToken);
            return new string(arrToken);
        }

        private double GetSupport(string strGeneratedCandidate)
        {
            double dSupportReturn = 0;
            foreach (string strTransaction in m_dicTransactions.Values)
            {
                if (IsSubstring(strGeneratedCandidate, strTransaction))
                {
                    dSupportReturn++;
                }
            }
            return dSupportReturn;
        }

        private bool IsSubstring(string strChild, string strParent)
        {
            foreach (char c in strChild)
            {
                if (!strParent.Contains(c))
                {
                    return false;
                }
            }
            return true;
        }

        private string GetCandidate(string strFirstItem, string strSecondItem)
        {
            int nLength = strFirstItem.Length;
            if (nLength == 1)
            {
                return strFirstItem + strSecondItem;
            }
            else
            {
                string strFirstSubString = strFirstItem.Substring(0, nLength - 1);
                string strSecondSubString = strSecondItem.Substring(0, nLength - 1);
                if (strFirstSubString == strSecondSubString)
                {
                    return strFirstItem + strSecondItem[nLength - 1];
                }
                else
                    return string.Empty;
            }
        }

        private Dictionary<string, double> GetL1FrequentItems(double dMinSupport)
        {
            Dictionary<string, double> dic_FrequentItemsReturn = new Dictionary<string, double>();
            foreach (ListViewItem lviItem in lv_Items.Items)
            {
                double dSupport = GetSupport(lviItem.Text);
                if ((dSupport / (double)(m_nLastTransId - 1) >= dMinSupport))
                {
                    dic_FrequentItemsReturn.Add(lviItem.Text, dSupport);
                    m_dicAllFrequentItems.Add(lviItem.Text, dSupport);
                }
            }
            return dic_FrequentItemsReturn;
        }

        private bool ItemIsRemovable(string strItem, ref List<int> lst_Transactions)
        {
            string strTransaction;
            bool bItemRemovable = true;
            foreach (int nTransaction in m_dicTransactions.Keys)
            {
                strTransaction = m_dicTransactions[nTransaction];
                if (strTransaction.Contains(strItem))
                {
                    lst_Transactions.Add(nTransaction);
                    bItemRemovable = false;
                }
            }
            return bItemRemovable;
        }

        private void EnableControls(bool bEnable)
        {
            btn_AddItem.Enabled = bEnable;
            btn_DeleteItem.Enabled = bEnable;
            btn_AddTrans.Enabled = bEnable;
            btn_EditTrans.Visible = bEnable;
            btn_DeleteTrans.Enabled = bEnable;
            btn_ClearTransactions.Enabled = bEnable;
            btn_Solve.Enabled = bEnable;
            lv_Transactions.Enabled = bEnable;
        }
    }
}
