namespace corebankigtest.Forms
{
    partial class TransactionForm
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
            lblAccount = new Label();
            fontDialog1 = new FontDialog();
            lblType = new Label();
            cmbAccount = new ComboBox();
            txtAmount = new TextBox();
            fontDialog2 = new FontDialog();
            label1 = new Label();
            cmbTransactionType = new ComboBox();
            btnSubmit = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblAccount
            // 
            lblAccount.AutoSize = true;
            lblAccount.Location = new Point(47, 45);
            lblAccount.Name = "lblAccount";
            lblAccount.Size = new Size(81, 25);
            lblAccount.TabIndex = 0;
            lblAccount.Text = "Account:";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new Point(48, 119);
            lblType.Name = "lblType";
            lblType.Size = new Size(81, 25);
            lblType.TabIndex = 0;
            lblType.Text = "Amount:";
            // 
            // cmbAccount
            // 
            cmbAccount.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAccount.FormattingEnabled = true;
            cmbAccount.Location = new Point(220, 45);
            cmbAccount.MaximumSize = new Size(250, 0);
            cmbAccount.Name = "cmbAccount";
            cmbAccount.Size = new Size(248, 33);
            cmbAccount.TabIndex = 1;
            cmbAccount.SelectedIndexChanged += cmbAccount_SelectedIndexChanged;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(220, 120);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(250, 31);
            txtAmount.TabIndex = 2;
            txtAmount.TextAlign = HorizontalAlignment.Right;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 197);
            label1.Name = "label1";
            label1.Size = new Size(146, 25);
            label1.TabIndex = 3;
            label1.Text = "Transaction Type:";
            label1.Click += label1_Click;
            // 
            // cmbTransactionType
            // 
            cmbTransactionType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTransactionType.FormattingEnabled = true;
            cmbTransactionType.Items.AddRange(new object[] { "Deposit", "Withdraw" });
            cmbTransactionType.Location = new Point(220, 194);
            cmbTransactionType.Name = "cmbTransactionType";
            cmbTransactionType.Size = new Size(250, 33);
            cmbTransactionType.TabIndex = 4;
            cmbTransactionType.SelectedIndexChanged += cmbTransactionType_SelectedIndexChanged;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(47, 374);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(100, 34);
            btnSubmit.TabIndex = 5;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(636, 382);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(100, 34);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // TransactionForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSubmit);
            Controls.Add(cmbTransactionType);
            Controls.Add(label1);
            Controls.Add(txtAmount);
            Controls.Add(cmbAccount);
            Controls.Add(lblType);
            Controls.Add(lblAccount);
            Name = "TransactionForm";
            Text = "TransactionForm";
            Load += TransactionForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private FontDialog fontDialog1;
        private Label label4;
        private ComboBox cmbAccount;
        private TextBox txtAmount;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblAmount;
        private FontDialog fontDialog2;
        private ComboBox cmbTransactionType;
        private Button btnSubmit;
        private Button btnCancel;
    }
}