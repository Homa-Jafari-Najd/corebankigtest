using System.Data;
using corebankigtest.Entities;
using corebankigtest.Forms;
using Microsoft.Data.SqlClient;
using corebankingtest.Utilities;
using System.Linq.Expressions;
using corebankigtest.BLL;

namespace corebankigtest
{
    public partial class LoginForm : Form
    {
        private readonly AccountService _service;
        private string currentCaptcha;
        public LoginForm(AccountService service)
        {
            InitializeComponent();
            _service = service;
            this.AcceptButton = Loginbutton;

        }
        private void captchaControl1_Load(object sender, EventArgs e)
        {

        }
        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var registerform = new RegisterForm();
            var result = registerform.ShowDialog();

            Show();
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
                return;
            }

            var user = _service.Login(username, password);

            if (user == null)
            {
                MessageBox.Show("Invalid username or password");
                captchaControl1.LoadCaptcha();
                return;
            }

            MessageBox.Show("Login Successful!");
            this.Hide();
            var frm = new AccountManagmentForm(_service);
            frm.ShowDialog();
            this.Close();
        }

        private bool LoginValidator(Employee employee)
        {
            string username = UserNameTextBox.Text;
            string password = PasswordTextBox.Text;

            return employee.UserName == username && employee.Password == password;
        }
        public void ResetTextBox()
        {
            UserNameTextBox.Text = string.Empty;
            PasswordTextBox.Text = string.Empty;
        }

    }


}


