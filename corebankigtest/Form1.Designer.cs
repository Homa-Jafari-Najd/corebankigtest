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
            txtCaptcha = new TextBox();
            btnRefreshCaptcha = new Button();
            pictureBoxCaptcha = new PictureBox();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCaptcha).BeginInit();
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
            UserNameTextBox.TabIndex = 0;
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
            // txtCaptcha
            // 
            txtCaptcha.CharacterCasing = CharacterCasing.Upper;
            txtCaptcha.Location = new Point(461, 371);
            txtCaptcha.Name = "txtCaptcha";
            txtCaptcha.PlaceholderText = "Enter the code shown above";
            txtCaptcha.Size = new Size(230, 31);
            txtCaptcha.TabIndex = 2;
            txtCaptcha.TextChanged += txtCaptcha_TextChanged;
            // 
            // btnRefreshCaptcha
            // 
            btnRefreshCaptcha.Cursor = Cursors.Hand;
            btnRefreshCaptcha.FlatAppearance.BorderSize = 0;
            btnRefreshCaptcha.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRefreshCaptcha.Image = Properties.Resources.icons8_refresh_24;
            btnRefreshCaptcha.Location = new Point(406, 297);
            btnRefreshCaptcha.Name = "btnRefreshCaptcha";
            btnRefreshCaptcha.Size = new Size(47, 34);
            btnRefreshCaptcha.TabIndex = 5;
            btnRefreshCaptcha.TabStop = false;
            btnRefreshCaptcha.UseVisualStyleBackColor = false;
            btnRefreshCaptcha.Click += btnRefreshCaptcha_Click;
            // 
            // pictureBoxCaptcha
            // 
            pictureBoxCaptcha.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxCaptcha.Location = new Point(473, 259);
            pictureBoxCaptcha.Name = "pictureBoxCaptcha";
            pictureBoxCaptcha.Size = new Size(202, 96);
            pictureBoxCaptcha.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxCaptcha.TabIndex = 6;
            pictureBoxCaptcha.TabStop = false;
            pictureBoxCaptcha.Click += pictureBoxCaptcha_Click_1;
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(757, 403);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(300, 150);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 450);
            Controls.Add(btnRefreshCaptcha);
            Controls.Add(groupBox1);
            Controls.Add(txtCaptcha);
            Controls.Add(pictureBoxCaptcha);
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
            ((System.ComponentModel.ISupportInitialize)pictureBoxCaptcha).EndInit();
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
        private TextBox txtCaptcha;
        private Button btnRefreshCaptcha;
        private PictureBox pictureBoxCaptcha;
        private GroupBox groupBox1;
    }
}
