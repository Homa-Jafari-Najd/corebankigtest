using CoreBanking.BusinessLogic;
using corebankigtest.Forms;


namespace corebankigtest
{
    public partial class LoginForm : Form
    {
        private readonly AccountService _accountService;
        private readonly TransactionService _transactionService;
        private string currentCaptcha;
        public LoginForm(AccountService service, TransactionService transactionService)
        {
            InitializeComponent();
            _accountService = service;
            _transactionService = transactionService;
            this.AcceptButton = Loginbutton;


        }
        private void captchaControl1_Load(object sender, EventArgs e)
        {

        }
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var registerform = new RegisterForm();
            var result = registerform.ShowDialog();

        }
        private void Loginbutton_Click(object sender, EventArgs e)
        {
            string username = UserNameTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();

            if (username == "" || password == "")
            {
                MessageBox.Show("Enter Username and Password");
                return;
            }

            if (!captchaControl1.IsValid())
            {
                MessageBox.Show("Captcha is incorrect");
                captchaControl1.LoadCaptcha();
                ResetPassword();
                return;
            }

            var user = _accountService.Login(username, password);

            if (user == null)
            {
                MessageBox.Show("Invalid username or password");
                captchaControl1.LoadCaptcha();
                ResetPassword();
                return;
            }

            MessageBox.Show("Login Successful!");
            this.Hide();
            var frm = new AccountManagmentForm(_accountService, _transactionService);
            frm.ShowDialog();
            this.Close();
        }

        public void ResetTextBox()
        {
            UserNameTextBox.Text = string.Empty;
            PasswordTextBox.Text = string.Empty;
        }
        public void ResetPassword()
        {
            PasswordTextBox.Text = string.Empty;
            PasswordTextBox.Focus();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void captchaControl2_Load_1(object sender, EventArgs e)
        {

        }

        private void captchaControl2_Load_2(object sender, EventArgs e)
        {

        }
    }


}


