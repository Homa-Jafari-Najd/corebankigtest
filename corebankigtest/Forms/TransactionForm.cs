using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using corebankigtest.BLL;

namespace corebankigtest.Forms
{

    public partial class TransactionForm : Form
    {
        private readonly int _accountId;
        private readonly AccountService _accountService = new AccountService();
        public TransactionForm(int accountId)
        {
            InitializeComponent();
            _accountId = accountId;
        }
        public TransactionForm()
        {
            InitializeComponent();
            cmbTransactionType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTransactionType.Items.Clear();
            cmbTransactionType.Items.Add("Deposit");
            cmbTransactionType.Items.Add("Withdraw");
            cmbTransactionType.SelectedIndex = 0;

        }

        private void TransactionForm_Load(object sender, EventArgs e)
        {
            var accounts = _accountService.GetAccountsForCombo();

            MessageBox.Show("Accounts count = " + accounts.Count);

            cmbAccount.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbAccount.DataSource = null;
            cmbAccount.DisplayMember = "DisplayText";
            cmbAccount.ValueMember = "AccountId";
            cmbAccount.DataSource = accounts;

            if (accounts.Count > 0)
                cmbAccount.SelectedIndex = 0;
        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int accountId = _accountId;
                decimal amount = decimal.Parse(txtAmount.Text.Trim());

                string type = cmbTransactionType.Text; 

                _accountService.MakeTransaction(accountId, amount, type);

                MessageBox.Show("Transaction successful ✅");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Transaction Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
