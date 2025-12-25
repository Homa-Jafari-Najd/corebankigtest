namespace corebankigtest
{
    partial class LoginForm
    {
        
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            UserNameLabel = new Label();
            UserNameTextBox = new TextBox();
            PasswordLabel = new Label();
            PasswordTextBox = new TextBox();
            RememberMecheckBox = new CheckBox();
            Loginbutton = new Button();
            RegisterButton = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // UserNameLabel
            // 
            UserNameLabel.AutoSize = true;
            UserNameLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            UserNameLabel.Location = new Point(25, 110);
            UserNameLabel.Name = "UserNameLabel";
            UserNameLabel.Size = new Size(108, 28);
            UserNameLabel.TabIndex = 0;
            UserNameLabel.Text = "User Name";
            // 
            // UserNameTextBox
            // 
            UserNameTextBox.Location = new Point(145, 110);
            UserNameTextBox.Name = "UserNameTextBox";
            UserNameTextBox.Size = new Size(599, 31);
            UserNameTextBox.TabIndex = 1;
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PasswordLabel.Location = new Point(25, 179);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(93, 28);
            PasswordLabel.TabIndex = 0;
            PasswordLabel.Text = "Password";
            PasswordLabel.Click += PasswordLabel_Click;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(139, 179);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(599, 31);
            PasswordTextBox.TabIndex = 1;
            // 
            // RememberMecheckBox
            // 
            RememberMecheckBox.AutoSize = true;
            RememberMecheckBox.Location = new Point(139, 245);
            RememberMecheckBox.Name = "RememberMecheckBox";
            RememberMecheckBox.Size = new Size(162, 29);
            RememberMecheckBox.TabIndex = 2;
            RememberMecheckBox.Text = "Remember Me?";
            RememberMecheckBox.UseVisualStyleBackColor = true;
            // 
            // Loginbutton
            // 
            Loginbutton.Location = new Point(145, 305);
            Loginbutton.Name = "Loginbutton";
            Loginbutton.Size = new Size(112, 34);
            Loginbutton.TabIndex = 3;
            Loginbutton.Text = "Login";
            Loginbutton.UseVisualStyleBackColor = true;
            Loginbutton.Click += Loginbutton_Click;
            // 
            // RegisterButton
            // 
            RegisterButton.Location = new Point(145, 355);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(112, 34);
            RegisterButton.TabIndex = 4;
            RegisterButton.Text = "Register";
            RegisterButton.UseVisualStyleBackColor = true;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.ErrorImage = (Image)resources.GetObject("pictureBox1.ErrorImage");
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(136, 75);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 450);
            Controls.Add(pictureBox1);
            Controls.Add(RegisterButton);
            Controls.Add(Loginbutton);
            Controls.Add(RememberMecheckBox);
            Controls.Add(PasswordTextBox);
            Controls.Add(UserNameTextBox);
            Controls.Add(PasswordLabel);
            Controls.Add(UserNameLabel);
            ForeColor = SystemColors.HotTrack;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login Form";
            Load += LoginForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UserNameLabel;
        private TextBox UserNameTextBox;
        private Label PasswordLabel;
        private TextBox PasswordTextBox;
        private CheckBox RememberMecheckBox;
        private Button Loginbutton;
        private Button RegisterButton;
        private PictureBox pictureBox1;
    }
}
