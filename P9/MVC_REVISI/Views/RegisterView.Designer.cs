namespace HotelDafam.Views
{
    partial class RegisterView
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtUsername, txtPassword, txtConfirmPassword, txtFullName;
        private Button btnRegister;
        private Label lblTitle, lblUsername, lblPassword, lblConfirmPassword, lblFullName;

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
            this.lblTitle.Text = "REGISTER AKUN BARU";
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(50, 20);
            
            // Input Full Name
            this.lblFullName = new Label();
            this.lblFullName.Text = "Nama Lengkap:";
            this.lblFullName.Location = new Point(50, 60);
            
            this.txtFullName = new TextBox();
            this.txtFullName.Location = new Point(50, 80);
            this.txtFullName.Size = new Size(200, 20);
            
            // Input Username
            this.lblUsername = new Label();
            this.lblUsername.Text = "Username:";
            this.lblUsername.Location = new Point(50, 110);
            
            this.txtUsername = new TextBox();
            this.txtUsername.Location = new Point(50, 130);
            this.txtUsername.Size = new Size(200, 20);
            
            // Input Password
            this.lblPassword = new Label();
            this.lblPassword.Text = "Password:";
            this.lblPassword.Location = new Point(50, 160);
            
            this.txtPassword = new TextBox();
            this.txtPassword.Location = new Point(50, 180);
            this.txtPassword.Size = new Size(200, 20);
            this.txtPassword.PasswordChar = '*';
            
            // Input Confirm Password
            this.lblConfirmPassword = new Label();
            this.lblConfirmPassword.Text = "Konfirmasi Password:";
            this.lblConfirmPassword.Location = new Point(50, 210);
            
            this.txtConfirmPassword = new TextBox();
            this.txtConfirmPassword.Location = new Point(50, 230);
            this.txtConfirmPassword.Size = new Size(200, 20);
            this.txtConfirmPassword.PasswordChar = '*';
            
            // Tombol Register
            this.btnRegister = new Button();
            this.btnRegister.Text = "Register";
            this.btnRegister.Location = new Point(50, 270);
            this.btnRegister.Size = new Size(200, 30);
            
            // Form settings
            this.ClientSize = new Size(300, 350);
            this.Text = "Register";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            
            // Add controls
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblFullName);
            this.Controls.Add(txtFullName);
            this.Controls.Add(lblUsername);
            this.Controls.Add(txtUsername);
            this.Controls.Add(lblPassword);
            this.Controls.Add(txtPassword);
            this.Controls.Add(lblConfirmPassword);
            this.Controls.Add(txtConfirmPassword);
            this.Controls.Add(btnRegister);
            
            // Event handlers
            this.btnRegister.Click += new EventHandler(btnRegister_Click);
        }
    }
}