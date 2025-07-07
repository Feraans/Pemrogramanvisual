namespace HotelDafam.Views
{
    partial class LoginView
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtUsername, txtPassword;
        private Button btnLogin;
        private LinkLabel lnkRegister;
        private Label lblTitle, lblUsername, lblPassword;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            
            // Label Judul
            this.lblTitle = new Label();
            this.lblTitle.Text = "LOGIN HOTEL DAFAM";
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(100, 30);
            
            // Label dan Input Username
            this.lblUsername = new Label();
            this.lblUsername.Text = "Username:";
            this.lblUsername.Location = new Point(50, 80);
            
            this.txtUsername = new TextBox();
            this.txtUsername.Location = new Point(50, 100);
            this.txtUsername.Size = new Size(200, 20);
            
            // Label dan Input Password
            this.lblPassword = new Label();
            this.lblPassword.Text = "Password:";
            this.lblPassword.Location = new Point(50, 130);
            
            this.txtPassword = new TextBox();
            this.txtPassword.Location = new Point(50, 150);
            this.txtPassword.Size = new Size(200, 20);
            this.txtPassword.PasswordChar = '*';
            
            // Tombol Login
            this.btnLogin = new Button();
            this.btnLogin.Text = "Login";
            this.btnLogin.Location = new Point(50, 190);
            this.btnLogin.Size = new Size(200, 30);
            
            // Link Register
            this.lnkRegister = new LinkLabel();
            this.lnkRegister.Text = "Belum punya akun? Daftar disini";
            this.lnkRegister.Location = new Point(50, 230);
            this.lnkRegister.AutoSize = true;
            
            // Form settings
            this.ClientSize = new Size(300, 300);
            this.Text = "Login";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            
            // Add controls
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(btnLogin);
            this.Controls.Add(lnkRegister);
            
            // Event handlers
            this.btnLogin.Click += new EventHandler(btnLogin_Click);
            this.lnkRegister.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkRegister_LinkClicked);
        }
    }
}