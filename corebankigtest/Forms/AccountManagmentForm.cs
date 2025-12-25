using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using corebankigtest.Entities;

namespace corebankigtest.Forms
{
    public partial class AccountManagmentForm : Form
    {
        private List<Account> _accounts;
        public AccountManagmentForm()
        {
            InitializeComponent();
            LoadAccounts();
            BindGrid(_accounts);
        }
        private void LoadAccounts()
        {
            _accounts = BankData.Customers.SelectMany(c => c.Accounts).ToList();
        }
        private void BindGrid(List<Account> accountsToshow)
        {
            var data = accountsToshow.Select(a => new
            {
                a.AccountNumber,
                a.OpeningDate,
                FirstName = a.Customer.CustomerFirstName,
                LastName = a.Customer.CustomerLastName,
                NationalCode = a.Customer.CustomerNationalCode,
                a.AccountType,
                a.Address
            }).ToList();
            AccountDataGridView.DataSource = null;
            AccountDataGridView.Columns.Clear();
            AccountDataGridView.AutoGenerateColumns = true;
            AccountDataGridView.DataSource = data;
        }
        private void AccountManagmentForm_Load(object sender, EventArgs e)
        {

        }

        private void AccountDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
