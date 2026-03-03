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
        private int? _selectedAccountId = null;
        private bool _isLoadingAccounts = false;

        private void AccountDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (_isLoadingAccounts) return;   // ✅ هنگام Load مقدار رو عوض نکن

            if (AccountDataGridView.CurrentRow?.DataBoundItem is System.Data.DataRowView rowView)
            {
                _selectedAccountId = Convert.ToInt32(rowView["AccountId"]);
            }
        }
        public void AccountDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }
        public AccountManagmentForm(AccountService accountService, TransactionService transactionService)
        {
            InitializeComponent();
            AccountDataGridView.AutoGenerateColumns = false;
            _accountService = accountService;
            _transactionService = transactionService;

            AccountDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AccountDataGridView.MultiSelect = false;
            AccountDataGridView.ReadOnly = true;
        }
        private void AccountDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadAccountsFromDB(string search = "")
        {
            _isLoadingAccounts = true;

            currentSearch = (search ?? "").Trim();

            totalRecords = _accountService.GetTotalAccounts(currentSearch);
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (totalPages == 0) totalPages = 1;

            var dt = _accountService.GetAccountsPaged(pageNumber, pageSize, currentSearch);

            AccountDataGridView.DataSource = null;
            AccountDataGridView.DataSource = dt;

            // 👇 اضافه شده
            if (_selectedAccountId == null && AccountDataGridView.Rows.Count > 0)
            {
                var rv = AccountDataGridView.Rows[0].DataBoundItem as System.Data.DataRowView;
                if (rv != null)
                    _selectedAccountId = Convert.ToInt32(rv["AccountId"]);
            }

            if (AccountDataGridView.Columns.Contains("AccountId"))
            {
                var col = AccountDataGridView.Columns["AccountId"];
                if (col != null)
                    col.Visible = false;
            }

            _isLoadingAccounts = false; // 👈 بیرون از if

            UpdatePageLabel();
            UpdateButtons();
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
            //SetupGridOnce();
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
                UpdateButtons();
            }

        }

        private void AccountDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // هدر

            AccountDataGridView.CurrentCell = AccountDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
            AccountDataGridView.Rows[e.RowIndex].Selected = true;

            if (AccountDataGridView.Rows[e.RowIndex].DataBoundItem is System.Data.DataRowView rv)
            {
                _selectedAccountId = Convert.ToInt32(rv["AccountId"]);
            }
        }


        //private void SetupGridOnce()

        //{
        //    AccountDataGridView.AutoGenerateColumns = false;
        //    AccountDataGridView.Columns.Clear();

        //    AccountDataGridView.Columns.Add(new DataGridViewTextBoxColumn
        //    {
        //        HeaderText = "Account Number",
        //        DataPropertyName = "AccountNumber"
        //    });

        //    AccountDataGridView.Columns.Add(new DataGridViewTextBoxColumn
        //    {
        //        HeaderText = "Create Date",
        //        DataPropertyName = "CreateDate",
        //        DefaultCellStyle = { Format = "yyyy-MM-dd" }
        //    });

        //    AccountDataGridView.Columns.Add(new DataGridViewTextBoxColumn
        //    {
        //        HeaderText = "First Name",
        //        DataPropertyName = "FirstName"
        //    });

        //    AccountDataGridView.Columns.Add(new DataGridViewTextBoxColumn
        //    {
        //        HeaderText = "Last Name",
        //        DataPropertyName = "LastName"
        //    });

        //    AccountDataGridView.Columns.Add(new DataGridViewTextBoxColumn
        //    {
        //        HeaderText = "National Code",
        //        DataPropertyName = "NationalCode"
        //    });

        //    AccountDataGridView.Columns.Add(new DataGridViewTextBoxColumn
        //    {
        //        HeaderText = "Account Type",
        //        DataPropertyName = "AccountType"
        //    });

        //    AccountDataGridView.Columns.Add(new DataGridViewTextBoxColumn
        //    {
        //        HeaderText = "Balance",
        //        DataPropertyName = "Balance"
        //    });

        //    AccountDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //    AccountDataGridView.AllowUserToAddRows = false;
        //    AccountDataGridView.RowHeadersVisible = false;
        //    AccountDataGridView.ReadOnly = true;
        //    AccountDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //}


        private void btnNext_Click(object sender, EventArgs e)
        {
            if (pageNumber < totalPages)
            {
                pageNumber++;
                LoadAccountsFromDB(currentSearch);
                UpdatePageLabel();
                UpdateButtons();
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
            if (_selectedAccountId == null)
            {
                MessageBox.Show("Please select an account first.");
                return;
            }

            int accountId = _selectedAccountId.Value;

            using (var frm = new TransactionManagementForm(accountId, _accountService, _transactionService))
            {
                var result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadAccountsFromDB(currentSearch);
                    UpdatePageLabel();
                    _selectedAccountId = accountId; // نگه دار
                }
            }
        }

        private void AccountManagmentForm_Enter(object sender, EventArgs e)
        {
            LoadAccountsFromDB();
        }
    }
}


