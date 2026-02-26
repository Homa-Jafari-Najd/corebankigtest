using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;
using CoreBanking.BusinessLogic;
using corebankigtest.UI;

namespace corebankigtest.Forms

{
    public partial class AccountManagmentForm : Form
    {
        private readonly AccountService _accountService;
        private readonly TransactionService _transactionService;

        private int pageNumber = 1;
        private int pageSize = 5;
        private int totalPages = 1;
        private int totalRecords = 0;
        string currentSearch = "";
        public AccountManagmentForm(AccountService accountService, TransactionService transactionService)
        {
            InitializeComponent();

            _accountService = accountService;
            _transactionService = transactionService;
        }
        private void AccountDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadAccountsFromDB(string search = "")
        {

            currentSearch = (search ?? "").Trim();

            totalRecords = _accountService.GetTotalAccounts(currentSearch);
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (totalPages == 0) totalPages = 1;

            var dt = _accountService.GetAccountsPaged(pageNumber, pageSize, currentSearch);

            AccountDataGridView.DataSource = null;
            AccountDataGridView.DataSource = dt;
            if (AccountDataGridView.Columns.Contains("AccountId"))
            {
                var col = AccountDataGridView.Columns["AccountId"];
                if (col != null)
                {
                    col.Visible = false;
                }

                UpdatePageLabel();
                UpdateButtons();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            pageNumber = 1;

            string s = NationalCodeTextBox.Text
                .Replace("-", "")
                .Replace("_", "")
                .Trim();

            currentSearch = s;
            LoadAccountsFromDB(currentSearch);

        }
        private void AccountManagementForm_Load(object sender, EventArgs e)
        {
            SetupGridOnce();
            pageNumber = 1;
            LoadAccountsFromDB("");
            UpdatePageLabel();
            UpdateButtons();
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (pageNumber > 1)
            {
                pageNumber--;
                LoadAccountsFromDB(currentSearch);
                UpdatePageLabel();
            }

        }


        private void SetupGridOnce()

        {
            AccountDataGridView.AutoGenerateColumns = false;
            AccountDataGridView.Columns.Clear();

            AccountDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Account Number",
                DataPropertyName = "AccountNumber"
            });

            AccountDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Create Date",
                DataPropertyName = "CreateDate",
                DefaultCellStyle = { Format = "yyyy-MM-dd" }
            });

            AccountDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "First Name",
                DataPropertyName = "FirstName"
            });

            AccountDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Last Name",
                DataPropertyName = "LastName"
            });

            AccountDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "National Code",
                DataPropertyName = "NationalCode"
            });

            AccountDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Account Type",
                DataPropertyName = "AccountType"
            });

            AccountDataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Balance",
                DataPropertyName = "Balance"
            });

            AccountDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AccountDataGridView.AllowUserToAddRows = false;
            AccountDataGridView.RowHeadersVisible = false;
            AccountDataGridView.ReadOnly = true;
            AccountDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pageNumber < totalPages)
            {
                pageNumber++;
                LoadAccountsFromDB(currentSearch);
            }

        }

        private void NationalCodeTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        private void UpdatePageLabel()
        {
            lblPage.Text = $"Page {pageNumber} /{totalPages}";

        }
        private void UpdateButtons()

        {
            btnPrev.Enabled = pageNumber > 1;
            btnNext.Enabled = pageNumber < totalPages;
        }



        private void btnTransaction_Click(object sender, EventArgs e)
        {
            if (AccountDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Please select an account first.");
                return;
            }

            var rowView = AccountDataGridView.CurrentRow.DataBoundItem as System.Data.DataRowView;
            if (rowView == null)
            {
                MessageBox.Show("Row binding is not DataRowView.");
                return;
            }

            int accountId = Convert.ToInt32(rowView["AccountId"]);

            using (var frm = new TransactionManagementForm(accountId, _accountService, _transactionService))
            {
                var result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadAccountsFromDB();
                    UpdatePageLabel();
                }
            }
        }
    }
}


