using CoreBanking.BusinessLogic;

using Microsoft.Identity.Client;

namespace corebankigtest.Forms
{
    public partial class TransactionManagementForm : Form
    {
        private readonly int _accountId;
        private readonly AccountService _accountService;

        private readonly TransactionService _transactionService;
        public TransactionManagementForm(int accountId, AccountService accountService, TransactionService transactionService)
        {
            InitializeComponent();
            _accountId = accountId;
            _accountService = accountService;
            _transactionService = transactionService;

        }
        private void LoadTransactions()
        {
            var list = _transactionService.GetTransactions(_accountId);
            dgvTransactions.DataSource = list;
        }

        private void btnShowTransaction_Click(object sender, EventArgs e)
        {
            LoadTransactions();

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            using (var frm = new TransactionForm(_accountId, _transactionService, _accountService))
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
                _transactionService.DeleteTransaction(transactionId);

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

        private void TransactionManagementForm_Load(object sender, EventArgs e)
        {

        }
    }
}