using corebankigtest.Entities;
using corebankigtest.Forms;
namespace corebankigtest
{
    public partial class LoginForm : Form
    {
        private List<Employee> _employees = new List<Employee>();
        public LoginForm()
        {
            var employee1 = new Employee();
            // _employees.Add(employee1);
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
            // _employees.Add(employee2);
            _employees.AddRange(employee1, employee2);

            InitializeComponent();

        }
        

            //    foreach (var employee in _employees)
            //    {
            //        if (employee.UserName == username && employee.Password== password)
            //        {
            //            LoginFailed = false;
            //            break;
            //        }
            //    }
            //    if(LoginFailed)
            //    {
            //        MessageBox.Show("Invlid username or password!", "Login Failed");
            //    }
            //    else
            //    {
            //        MessageBox.Show($"Welcome {UserNameTextBox.Text}.","Login successfully");

            //    }
            //}

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var registerform = new RegisterForm();
            //registerform.Show();
            var result = registerform.ShowDialog();
            if (result == DialogResult.OK)
            {
                registerform.RegisterEmployee.Id = _employees.Count + 1;
                _employees.Add(registerform.RegisterEmployee);
            }
            Show();
        }

        private void PasswordtextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void PasswordLabel_Click(object sender, EventArgs e)
        {

        }

        private void Loginbutton_Click(object sender, EventArgs e)
        {
            //var loginform = new LoginForm();
            //if (_employees.Any(LoginValidator))
            //{
            //    MessageBox.Show($"Welcome {UserNameTextBox.Text}.", "Login successfully");
            //}
            //else
            //{
            //    MessageBox.Show("Invalid username or password!", "Login failed");

            //}
            if(_employees.Any(LoginValidator))
            {
                Hide();
                HomeForm homeForm =new(this);
                homeForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Login Failed");
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
            UserNameTextBox.Text=string.Empty;
            PasswordTextBox.Text=string.Empty;
        }
    }
    }

