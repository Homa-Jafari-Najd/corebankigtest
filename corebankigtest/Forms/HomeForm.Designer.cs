namespace corebankigtest.Forms
{
    partial class HomeForm
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
            AccountManagmentbutton = new Button();
            Logoutbutton = new Button();
            SuspendLayout();
            // 
            // AccountManagmentbutton
            // 
            AccountManagmentbutton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            AccountManagmentbutton.Location = new Point(12, 31);
            AccountManagmentbutton.Name = "AccountManagmentbutton";
            AccountManagmentbutton.Size = new Size(776, 34);
            AccountManagmentbutton.TabIndex = 0;
            AccountManagmentbutton.Text = "AccountManagment";
            AccountManagmentbutton.UseVisualStyleBackColor = true;
            AccountManagmentbutton.Click += AccountManagmentbutton_Click;
            // 
            // Logoutbutton
            // 
            Logoutbutton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Logoutbutton.Location = new Point(12, 391);
            Logoutbutton.Name = "Logoutbutton";
            Logoutbutton.Size = new Size(776, 34);
            Logoutbutton.TabIndex = 0;
            Logoutbutton.Text = "Logout";
            Logoutbutton.UseVisualStyleBackColor = true;
            Logoutbutton.Click += Logoutbutton_Click;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Logoutbutton);
            Controls.Add(AccountManagmentbutton);
            Name = "HomeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HomeForm";
            ResumeLayout(false);
        }

        #endregion

        private Button AccountManagmentbutton;
        private Button Logoutbutton;
    }
}