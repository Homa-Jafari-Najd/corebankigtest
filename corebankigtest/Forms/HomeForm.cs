
using CoreBanking.BusinessLogic;
using CoreBanking.DataAccess;
using CoreBanking.Entities;


namespace corebankigtest.Forms
{

    public partial class HomeForm : Form
    {
        private string _user = string.Empty;
        private string _role = string.Empty;
        private readonly AccountService _service;
        private readonly TransactionService _transactionService;

        public HomeForm(string user, string role, AccountService service, TransactionService transactionService)
        {
            InitializeComponent();
            _user = user;
            _role = role;
            _service = service;
            _transactionService = transactionService;

        }


        private void Logoutbutton_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AccountManagmentbutton_Click(object? sender, EventArgs e)
        {
            var form = new AccountManagmentForm(_service, _transactionService);
            form.Show();
        }

        private void HomeForm_Load(object? sender, EventArgs e)
        {

        }
    }
}
