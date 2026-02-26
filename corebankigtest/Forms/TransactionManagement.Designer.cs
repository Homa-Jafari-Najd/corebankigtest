namespace corebankigtest.Forms
{
    partial class TransactionManagementForm : Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnShowTransaction = new Button();
            btnInsert = new Button();
            btnDelete = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            dgvTransactions = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            SuspendLayout();
            // 
            // btnShowTransaction
            // 
            btnShowTransaction.Location = new Point(12, 62);
            btnShowTransaction.Name = "btnShowTransaction";
            btnShowTransaction.Size = new Size(149, 40);
            btnShowTransaction.TabIndex = 0;
            btnShowTransaction.Text = "Show Transactions";
            btnShowTransaction.UseVisualStyleBackColor = true;
            btnShowTransaction.Click += btnShowTransaction_Click;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(12, 126);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(149, 34);
            btnInsert.TabIndex = 1;
            btnInsert.Text = "Insert Transaction";
            btnInsert.UseVisualStyleBackColor = true;
            btnInsert.Click += btnInsert_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(12, 190);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(149, 34);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Delete Transaction";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // dgvTransactions
            // 
            dgvTransactions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.Location = new Point(176, 12);
            dgvTransactions.MultiSelect = false;
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.RowHeadersVisible = false;
            dgvTransactions.RowHeadersWidth = 62;
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactions.Size = new Size(612, 426);
            dgvTransactions.TabIndex = 4;
            dgvTransactions.CellContentClick += dgvTransactions_CellContentClick;
            // 
            // TransactionManagementForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvTransactions);
            Controls.Add(btnDelete);
            Controls.Add(btnInsert);
            Controls.Add(btnShowTransaction);
            Name = "TransactionManagementForm";
            Text = "Transaction Management";
            Load += TransactionManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnShowTransaction;
        private ContextMenuStrip contextMenuStrip1;
        private DataGridView dgvTransactions;
    }
}