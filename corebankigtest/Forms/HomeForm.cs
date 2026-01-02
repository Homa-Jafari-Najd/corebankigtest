
namespace corebankigtest.Forms
{
    public partial class HomeForm : Form
    {
        private string _user;
        private string _role;
        private LoginForm _loginForm;

        public HomeForm(LoginForm loginForm)
        {
            _loginForm = loginForm;

            InitializeComponent();
        }public HomeForm(string user, string role) {
            _user = user;
            _role = role;
        }

        private void Logoutbutton_Click(object sender, EventArgs e)
        {
            Close();
            _loginForm.ResetTextBox();
            _loginForm.Show();
        }

        private void AccountManagmentbutton_Click(object sender, EventArgs e)
        {
            var form = new AccountManagmentForm();
            form.Show();
        }
    }
}
