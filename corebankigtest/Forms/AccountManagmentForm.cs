using System.Data;
using Microsoft.Data.SqlClient;
using System.Configuration;


namespace corebankigtest.Forms
{
    public partial class AccountManagmentForm : Form
    {
        private readonly String _cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        //private List<Account> _accounts;
        private int pageNumber = 1;
        private int pageSize = 5;
        private int totalPages = 1;
        private int totalRecords = 0;

        
        public AccountManagmentForm()
        {
            InitializeComponent();
            
        }
        private void UpdatePageLabel()
        {
            lblPage.Text = "Page" + pageNumber;
        }
        //    //LoadAccounts();
        //    //BindGrid(_accounts);
        //}
        //private void LoadAccounts()
        //{
        //    _accounts = BankData.Customers.SelectMany(c => c.Accounts).ToList();
        //}
        //private void BindGrid(List<Account> accountsToshow)
        //{
        //    var data = accountsToshow.Select(a => new
        //    {
        //        a.AccountNumber,
        //        a.OpeningDate,
        //        FirstName = a.Customer.CustomerFirstName,
        //        LastName = a.Customer.CustomerLastName,
        //        NationalCode = a.Customer.CustomerNationalCode,
        //        a.AccountType,
        //        a.Address
        //    }).ToList();
        //    AccountDataGridView.DataSource = null;
        //    AccountDataGridView.Columns.Clear();
        //    AccountDataGridView.AutoGenerateColumns = true;
        //    AccountDataGridView.DataSource = data;
        //}
       

        private void AccountDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        private void LoadAccountsFromDB()
        {
            using (var con = new SqlConnection(_cs))
            {
                con.Open();
                using (var countCmd = new SqlCommand("Select COUNT(*) FROM Account", con))
                {
                    totalRecords = (int)countCmd.ExecuteScalar();
                    con.Close();
                }
                totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
                using (var cmd = new SqlCommand("sp_GETAccountsPaged", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                    cmd.Parameters.AddWithValue("@PageSize", pageSize);

                    var dt = new DataTable();
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);

                    }
                    AccountDataGridView.AutoGenerateColumns = false;
                    AccountDataGridView.Columns.Clear();
                    AccountDataGridView.DataSource = null;
                    AccountDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Account Number",
                        DataPropertyName = "AccountNumber",
                        ReadOnly = true
                    });
                    AccountDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Account Type",
                        DataPropertyName = "AccountName",
                        ReadOnly = true
                    });
                    AccountDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Balance",
                        DataPropertyName = "Balance",
                        ReadOnly = true
                    });
                    AccountDataGridView.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Opening Date",
                        DataPropertyName = "CreateDate",
                        ReadOnly = true
                    });


                    AccountDataGridView.DataSource = dt;
                    AccountDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    AccountDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    AccountDataGridView.MultiSelect = false;
                    AccountDataGridView.AllowUserToAddRows = false;
                    AccountDataGridView.AllowUserToDeleteRows = false;
                }

            }
        }
        private void AccountManagementForm_Load(object sender, EventArgs e)
        {
            pageNumber = 1;
            LoadAccountsFromDB();
            UpdatePageLabel();

        }

        private void AccountDataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if(pageNumber>1)
            {
                pageNumber--;
                LoadAccountsFromDB();
                UpdatePageLabel();
            }
           
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pageNumber++;
            LoadAccountsFromDB();
            UpdatePageLabel();
        }
      
    }
    
   
}