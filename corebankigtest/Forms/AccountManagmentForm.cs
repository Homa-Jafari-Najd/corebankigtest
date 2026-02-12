using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;
using corebankigtest.BLL;
using System.Windows.Forms;
using System;


namespace corebankigtest.Forms
{
    public partial class AccountManagmentForm : Form
    {
        private readonly AccountService _service = new AccountService();
        //private List<Account> _accounts;
        private int pageNumber = 1;
        private int pageSize = 5;
        private int totalPages = 1;
        private int totalRecords = 0;
        string currentSearch = "";
        public AccountManagmentForm()
        {
            InitializeComponent();

        }
        private void AccountDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadAccountsFromDB(string search = "")
        {

            currentSearch = (search ?? "").Trim();

            totalRecords = _service.GetTotalAccounts(currentSearch);
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (totalPages == 0) totalPages = 1;

            var dt = _service.GetAccountsPaged(pageNumber, pageSize, currentSearch);

            AccountDataGridView.DataSource = null;
            AccountDataGridView.DataSource = dt;

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
        
            using (var frm = new TransactionForm())
            {
                var result = frm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoadAccountsFromDB("");
                    UpdatePageLabel(); 
                }
            }
        }
    }
    }



