using corebankigtest.BLL;
using Microsoft.Identity.Client;

namespace corebankigtest.Forms
{
    public partial class TransactionManagementForm : Form
    {
        private readonly int _accountId;
        private readonly TransactionService service = new TransactionService();
        public TransactionManagementForm(int accountId)
        {
            InitializeComponent();
            _accountId = accountId;
        }
        private void LoadTransactions()
        {
            var list = service.GetTransactions(_accountId);
            dgvTransactions.DataSource = list;
        }
        
        private void btnShowTransaction_Click(object sender, EventArgs e)
        {
            LoadTransactions();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            using (var frm = new TransactionForm(_accountId))
            {
                var result = frm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadTransactions();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.CurrentRow == null)
            {
                MessageBox.Show("Please Select a row ");
                return;
            }

            int transactionId = Convert.ToInt32(dgvTransactions.CurrentRow.Cells["TransactionId"].Value);

            var confirm = MessageBox.Show(" Are you sure you want to delete this transaction?‌    ", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                service.DeleteTransaction(transactionId);

                LoadTransactions();              
                this.DialogResult = DialogResult.OK; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}