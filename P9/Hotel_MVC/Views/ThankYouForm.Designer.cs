namespace HotelDafamApp
{
    partial class ThankYouForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelThankYou;
        private System.Windows.Forms.Button buttonClose;

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
            this.labelThankYou = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelThankYou
            // 
            this.labelThankYou.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelThankYou.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelThankYou.Location = new System.Drawing.Point(0, 0);
            this.labelThankYou.Name = "labelThankYou";
            this.labelThankYou.Size = new System.Drawing.Size(484, 150);
            this.labelThankYou.TabIndex = 0;
            this.labelThankYou.Text = "Terima kasih atas kunjungannya.\nHave fun and have a nice day!";
            this.labelThankYou.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonClose.Location = new System.Drawing.Point(192, 160);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 40);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Tutup";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // ThankYouForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 221);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelThankYou);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ThankYouForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Terima Kasih";
            this.ResumeLayout(false);
        }
    }
}
