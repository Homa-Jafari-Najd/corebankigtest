namespace corebankigtest.Forms
{
    partial class RegisterForm
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
            RegisterButton = new Button();
            LastNameTextBox = new TextBox();
            FirstNameTextBox = new TextBox();
            LastNameLabel = new Label();
            FirstNameLabel = new Label();
            UserNameLabel = new Label();
            PasswordLabel = new Label();
            UserNameTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            GenderLabel = new Label();
            MaleGenderRadioButton = new RadioButton();
            FemaleGenderRadioButton = new RadioButton();
            Nationalcodelabel = new Label();
            NationalcodeTextBox = new TextBox();
            Cancelbutton = new Button();
            SuspendLayout();
            // 
            // RegisterButton
            // 
            RegisterButton.Location = new Point(142, 393);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(112, 34);
            RegisterButton.TabIndex = 9;
            RegisterButton.Text = "Register";
            RegisterButton.UseVisualStyleBackColor = true;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // LastNameTextBox
            // 
            LastNameTextBox.Location = new Point(180, 105);
            LastNameTextBox.Name = "LastNameTextBox";
            LastNameTextBox.Size = new Size(599, 31);
            LastNameTextBox.TabIndex = 7;
            // 
            // FirstNameTextBox
            // 
            FirstNameTextBox.Location = new Point(180, 35);
            FirstNameTextBox.Name = "FirstNameTextBox";
            FirstNameTextBox.Size = new Size(599, 31);
            FirstNameTextBox.TabIndex = 8;
            // 
            // LastNameLabel
            // 
            LastNameLabel.AutoSize = true;
            LastNameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LastNameLabel.Location = new Point(41, 105);
            LastNameLabel.Name = "LastNameLabel";
            LastNameLabel.Size = new Size(103, 28);
            LastNameLabel.TabIndex = 5;
            LastNameLabel.Text = "Last Name";
            // 
            // FirstNameLabel
            // 
            FirstNameLabel.AutoSize = true;
            FirstNameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FirstNameLabel.Location = new Point(38, 35);
            FirstNameLabel.Name = "FirstNameLabel";
            FirstNameLabel.Size = new Size(106, 28);
            FirstNameLabel.TabIndex = 6;
            FirstNameLabel.Text = "First Name";
            // 
            // UserNameLabel
            // 
            UserNameLabel.AutoSize = true;
            UserNameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UserNameLabel.Location = new Point(41, 229);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(108, 28);
            UserNameLabel.TabIndex = 6;
            UserNameLabel.Text = "User Name";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PasswordLabel.Location = new Point(51, 283);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(93, 28);
            PasswordLabel.TabIndex = 5;
            PasswordLabel.Text = "Password";
            // 
            // UserNameTextBox
            // 
            UserNameTextBox.Location = new Point(180, 226);
            UserNameTextBox.Name = "UserNameTextBox";
            UserNameTextBox.Size = new Size(599, 31);
            UserNameTextBox.TabIndex = 8;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(180, 283);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(599, 31);
            PasswordTextBox.TabIndex = 7;
            // 
            // GenderLabel
            // 
            GenderLabel.AutoSize = true;
            GenderLabel.Location = new Point(66, 346);
            GenderLabel.Name = "GenderLabel";
            GenderLabel.Size = new Size(78, 25);
            GenderLabel.TabIndex = 10;
            GenderLabel.Text = "Gender :";
            // 
            // MaleGenderRadioButton
            // 
            MaleGenderRadioButton.AutoSize = true;
            MaleGenderRadioButton.Location = new Point(200, 344);
            MaleGenderRadioButton.Name = "MaleGenderRadioButton";
            MaleGenderRadioButton.Size = new Size(75, 29);
            MaleGenderRadioButton.TabIndex = 11;
            MaleGenderRadioButton.Text = "Male";
            MaleGenderRadioButton.UseVisualStyleBackColor = true;
            // 
            // FemaleGenderRadioButton
            // 
            FemaleGenderRadioButton.AutoSize = true;
            FemaleGenderRadioButton.Checked = true;
            FemaleGenderRadioButton.Location = new Point(407, 346);
            FemaleGenderRadioButton.Name = "FemaleGenderRadioButton";
            FemaleGenderRadioButton.Size = new Size(93, 29);
            FemaleGenderRadioButton.TabIndex = 11;
            FemaleGenderRadioButton.TabStop = true;
            FemaleGenderRadioButton.Text = "Female";
            FemaleGenderRadioButton.UseVisualStyleBackColor = true;
            // 
            // Nationalcodelabel
            // 
            Nationalcodelabel.AutoSize = true;
            Nationalcodelabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Nationalcodelabel.Location = new Point(38, 166);
            Nationalcodelabel.Name = "Nationalcodelabel";
            Nationalcodelabel.Size = new Size(138, 28);
            Nationalcodelabel.TabIndex = 5;
            Nationalcodelabel.Text = "National Code";
            // 
            // NationalcodeTextBox
            // 
            NationalcodeTextBox.Location = new Point(180, 166);
            NationalcodeTextBox.Name = "NationalcodeTextBox";
            NationalcodeTextBox.Size = new Size(599, 31);
            NationalcodeTextBox.TabIndex = 7;
            // 
            // Cancelbutton
            // 
            Cancelbutton.Location = new Point(299, 393);
            Cancelbutton.Name = "Cancelbutton";
            Cancelbutton.Size = new Size(112, 34);
            Cancelbutton.TabIndex = 12;
            Cancelbutton.Text = "Cancel";
            Cancelbutton.UseVisualStyleBackColor = true;
            Cancelbutton.Click += Cancelbutton_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Cancelbutton);
            Controls.Add(FemaleGenderRadioButton);
            Controls.Add(MaleGenderRadioButton);
            Controls.Add(GenderLabel);
            Controls.Add(RegisterButton);
            Controls.Add(PasswordTextBox);
            Controls.Add(NationalcodeTextBox);
            Controls.Add(LastNameTextBox);
            Controls.Add(UserNameTextBox);
            Controls.Add(FirstNameTextBox);
            Controls.Add(Nationalcodelabel);
            Controls.Add(PasswordLabel);
            Controls.Add(LastNameLabel);
            Controls.Add(UserNameLabel);
            Controls.Add(FirstNameLabel);
            Name = "RegisterForm";
            Text = "RegisterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button RegisterButton;
        private TextBox PasswordTextBox;
        private Label GenderLabel;
        private RadioButton MaleGenderRadioButton;
        private RadioButton radioButton2;
        private TextBox UserNameTextBox;
        private Label PasswordLabel;
        private Label UserNameLabel;
        private Label Label1;
        private Label Label2;
        private TextBox TextBox1;
        private TextBox GenderTextBox;
        private TextBox FirstNameTextBox;
        private Label LastNameLabel;
        private TextBox LastNameTextBox;
        private Label FirstNameLabel;
        private RadioButton FemaleRadioButton;
        private RadioButton FemaleGenderRadioButton;
        private Label Nationalcodelabel;
        private TextBox NationalcodeTextBox;
        private Button Cancelbutton;
    }
}