using System.Data;
using corebankigtest.Entities;
using corebankigtest.Forms;
using Microsoft.Data.SqlClient;
using corebankingtest.Utilities;
using System.Linq.Expressions;

namespace corebankigtest
{
    public partial class LoginForm : Form
    {
        string cs = "server=.;Database=OrderManagementDB;Trusted_Connection=True;TrustServerCertificate=True;";
        private List<Employee> _employees = new List<Employee>();
        private string currentCaptcha;
        public LoginForm()
        {
            var employee1 = new Employee();
            employee1.Id = 1;
            employee1.FirstName = "Homa";
            employee1.LastName = "Jafari";
            employee1.NationalCode = "0012345678";
            employee1.Gender = true;
            employee1.UserName = "h.jafari";
            employee1.Password = "123456";

            var employee2 = new Employee
            {
                Id = 2,
                FirstName = "Armin",
                LastName = "yaghoubi",
                NationalCode = "00123456789",
                Gender = false,
                UserName = "A.Yaghoubi",
                Password = "123456,"

            };
            _employees.AddRange(employee1, employee2);

            InitializeComponent();
            this.AcceptButton = Loginbutton;

        }


        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var registerform = new RegisterForm();
            var result = registerform.ShowDialog();
            if (result == DialogResult.OK)
            {
                registerform.RegisterEmployee.Id = _employees.Count + 1;
                _employees.Add(registerform.RegisterEmployee);
            }
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

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string sql = @"SELECT ID,Username,Role from users 
                     where Username=@u
                    AND [Password]=@p
                    AND IsActive=1";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@U", username);
                    cmd.Parameters.AddWithValue("@p", password);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string user = reader.GetString(1);
                            string role = reader.GetString(2);
                            MessageBox.Show($"Welcome {user} (Role:{role})");
                            //HomeForm home = new HomeForm(user, role);
                            //home.Show();

                            //this.Hide();
                            AccountManagmentForm accountForm = new AccountManagmentForm();
                            accountForm.FormClosed += (s, args) => this.Close();

                            accountForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password");
                        }

                    }

                }
            }
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

        private void captchaControl1_Load(object sender, EventArgs e)
        {

        }

        private void captchaControl1_Load_1(object sender, EventArgs e)
        {

        }

      
    }
}


