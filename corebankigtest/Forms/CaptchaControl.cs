using corebankigtest.BLL.Utilities;
namespace corebankigtest.Forms
{
    public partial class CaptchaControl : UserControl
    {
        private PictureBox pictureBoxCaptcha;
        private TextBox txtCaptcha;
        private Button btnRefresh;

        private string _currentCaptcha = "";

        public CaptchaControl()
        {
            InitializeComponent();
            this.Load += (s, e) => LoadCaptcha();    
            this.TabStop=true;
        }

        private void InitializeComponent()
        {
            pictureBoxCaptcha = new PictureBox();
            txtCaptcha = new TextBox();
            txtCaptcha.TabIndex = 0;
            txtCaptcha.TabStop=true;
            btnRefresh = new Button();
            btnRefresh.TabStop=false;
            pictureBoxCaptcha.TabStop = false;
            ((System.ComponentModel.ISupportInitialize)pictureBoxCaptcha).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxCaptcha
            // 
            pictureBoxCaptcha.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBoxCaptcha.BackColor = SystemColors.Control;
            pictureBoxCaptcha.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxCaptcha.Location = new Point(168, 28);
            pictureBoxCaptcha.Name = "pictureBoxCaptcha";
            pictureBoxCaptcha.Size = new Size(153, 46);
            pictureBoxCaptcha.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxCaptcha.TabIndex = 0;
            pictureBoxCaptcha.TabStop = false;
            pictureBoxCaptcha.Click += pictureBoxCaptcha_Click;
            // 
            // txtCaptcha
            // 
            txtCaptcha.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtCaptcha.Location = new Point(168, 80);
            txtCaptcha.Name = "txtCaptcha";
            txtCaptcha.Size = new Size(153, 31);
            txtCaptcha.TabIndex = 1;
            txtCaptcha.TextChanged += txtCaptcha_TextChanged;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.Location = new Point(334, 76);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(56, 35);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "↻";
            btnRefresh.Click += btnRefresh_Click;
            // 
            // CaptchaControl
            // 
            Controls.Add(pictureBoxCaptcha);
            Controls.Add(btnRefresh);
            Controls.Add(txtCaptcha);
            Name = "CaptchaControl";
            Size = new Size(415, 238);
            Load += CaptchaControl_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxCaptcha).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        public void LoadCaptcha()
        {
            var result = CaptchaService.GenarateCaptcha();
            _currentCaptcha = result.code;
            pictureBoxCaptcha.Image = result.image;
            txtCaptcha.Clear();
        }

        public bool IsValid()
            => string.Equals(txtCaptcha.Text?.Trim(), _currentCaptcha, StringComparison.OrdinalIgnoreCase);

        public void FocusInput() => txtCaptcha.Focus();

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCaptcha();
        }



        private void txtCaptcha_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBoxCaptcha_Click(object sender, EventArgs e)
        {

        }

        private void CaptchaControl_Load(object sender, EventArgs e)
        {

        }
    }
}