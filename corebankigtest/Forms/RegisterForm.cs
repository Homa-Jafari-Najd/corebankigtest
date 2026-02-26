
using System.ComponentModel;
using CoreBanking.Entities;

namespace corebankigtest.Forms
{
    public partial class RegisterForm : Form
    {

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Employee? RegisterEmployee { get; set; }
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            RegisterEmployee = new Employee()
            {
                FirstName = FirstNameTextBox.Text,
                LastName = LastNameTextBox.Text,
                NationalCode = NationalcodeTextBox.Text,
                UserName = UserNameTextBox.Text,
                Gender = FemaleGenderRadioButton.Checked,

            };
            DialogResult = DialogResult.OK;
        }

        private void Cancelbutton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
