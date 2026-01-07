namespace corebankigtest.Forms
{
    partial class AccountManagmentForm
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
            label1 = new Label();
            NationalCodeTextBox = new MaskedTextBox();
            SearchButton = new Button();
            AccountDataGridView = new DataGridView();
            AccountNumber = new DataGridViewTextBoxColumn();
            OpeningDate = new DataGridViewTextBoxColumn();
            FirstName = new DataGridViewTextBoxColumn();
            LastName = new DataGridViewTextBoxColumn();
            NationalCode = new DataGridViewTextBoxColumn();
            AccountType = new DataGridViewTextBoxColumn();
            btnPrev = new Button();
            btnNext = new Button();
            lblPage = new Label();
            ((System.ComponentModel.ISupportInitialize)AccountDataGridView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(36, 23);
            label1.Name = "label1";
            label1.Size = new Size(138, 28);
            label1.TabIndex = 0;
            label1.Text = "National Code";
            // 
            // NationalCodeTextBox
            // 
            NationalCodeTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NationalCodeTextBox.Location = new Point(192, 23);
            NationalCodeTextBox.Mask = "000-0000000";
            NationalCodeTextBox.Name = "NationalCodeTextBox";
            NationalCodeTextBox.Size = new Size(871, 31);
            NationalCodeTextBox.TabIndex = 1;
            // 
            // SearchButton
            // 
            SearchButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SearchButton.Location = new Point(1069, 21);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(112, 34);
            SearchButton.TabIndex = 2;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // AccountDataGridView
            // 
            AccountDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AccountDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AccountDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AccountDataGridView.Columns.AddRange(new DataGridViewColumn[] { AccountNumber, OpeningDate, FirstName, LastName, NationalCode, AccountType });
            AccountDataGridView.Location = new Point(106, 125);
            AccountDataGridView.Name = "AccountDataGridView";
            AccountDataGridView.RowHeadersWidth = 62;
            AccountDataGridView.Size = new Size(985, 429);
            AccountDataGridView.TabIndex = 3;
            AccountDataGridView.CellContentClick += AccountDataGridView_CellContentClick;
            // 
            // AccountNumber
            // 
            AccountNumber.DataPropertyName = "Account Number";
            AccountNumber.HeaderText = "Account Number";
            AccountNumber.MinimumWidth = 8;
            AccountNumber.Name = "AccountNumber";
            // 
            // OpeningDate
            // 
            OpeningDate.HeaderText = "Opening Date";
            OpeningDate.MinimumWidth = 8;
            OpeningDate.Name = "OpeningDate";
            // 
            // FirstName
            // 
            FirstName.HeaderText = "First Name";
            FirstName.MinimumWidth = 8;
            FirstName.Name = "FirstName";
            // 
            // LastName
            // 
            LastName.HeaderText = "Last Name";
            LastName.MinimumWidth = 8;
            LastName.Name = "LastName";
            // 
            // NationalCode
            // 
            NationalCode.HeaderText = "National Code";
            NationalCode.MinimumWidth = 8;
            NationalCode.Name = "NationalCode";
            // 
            // AccountType
            // 
            AccountType.HeaderText = "Account Type";
            AccountType.MinimumWidth = 8;
            AccountType.Name = "AccountType";
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(12, 572);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(112, 34);
            btnPrev.TabIndex = 4;
            btnPrev.Text = "Previous";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(1081, 572);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(112, 34);
            btnNext.TabIndex = 5;
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // lblPage
            // 
            lblPage.AutoSize = true;
            lblPage.Location = new Point(547, 577);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(65, 25);
            lblPage.TabIndex = 6;
            lblPage.Text = "Page 1";
            // 
            // AccountManagmentForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1205, 618);
            Controls.Add(lblPage);
            Controls.Add(btnNext);
            Controls.Add(btnPrev);
            Controls.Add(AccountDataGridView);
            Controls.Add(SearchButton);
            Controls.Add(NationalCodeTextBox);
            Controls.Add(label1);
            Name = "AccountManagmentForm";
            Text = "AccountManagmentForm";
            Load += this.AccountManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)AccountDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private MaskedTextBox NationalCodeTextBox;
        private Button SearchButton;
        private DataGridView AccountDataGridView;
        private DataGridViewTextBoxColumn AccountNumber;
        private DataGridViewTextBoxColumn OpeningDate;
        private DataGridViewTextBoxColumn FirstName;
        private DataGridViewTextBoxColumn LastName;
        private DataGridViewTextBoxColumn NationalCode;
        private DataGridViewTextBoxColumn AccountType;
        private Button btnPrev;
        private Button btnNext;
        private Label lblPage;
    }
}