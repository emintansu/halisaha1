namespace halisaha
{
    partial class giris
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
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.AdminGiris = new Guna.UI2.WinForms.Guna2Button();
            this.KullaniciGiris = new Guna.UI2.WinForms.Guna2Button();
            this.Kaydol = new Guna.UI2.WinForms.Guna2Button();
            this.testconnection = new Guna.UI2.WinForms.Guna2Button();
            this.mySqlConnection1 = new MySqlConnector.MySqlConnection();
            this.SuspendLayout();
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(308, 44);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(281, 39);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "Halisaha Kiralama";
            // 
            // AdminGiris
            // 
            this.AdminGiris.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.AdminGiris.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.AdminGiris.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.AdminGiris.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.AdminGiris.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AdminGiris.ForeColor = System.Drawing.Color.White;
            this.AdminGiris.Location = new System.Drawing.Point(138, 209);
            this.AdminGiris.Name = "AdminGiris";
            this.AdminGiris.Size = new System.Drawing.Size(128, 83);
            this.AdminGiris.TabIndex = 1;
            this.AdminGiris.Text = "Admin Giris";
            this.AdminGiris.Click += new System.EventHandler(this.AdminGiris_Click);
            // 
            // KullaniciGiris
            // 
            this.KullaniciGiris.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.KullaniciGiris.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.KullaniciGiris.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.KullaniciGiris.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.KullaniciGiris.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.KullaniciGiris.ForeColor = System.Drawing.Color.Snow;
            this.KullaniciGiris.Location = new System.Drawing.Point(402, 209);
            this.KullaniciGiris.Name = "KullaniciGiris";
            this.KullaniciGiris.Size = new System.Drawing.Size(128, 83);
            this.KullaniciGiris.TabIndex = 2;
            this.KullaniciGiris.Text = "Kullanici Giris";
            this.KullaniciGiris.Click += new System.EventHandler(this.KullaniciGiris_Click);
            // 
            // Kaydol
            // 
            this.Kaydol.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Kaydol.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Kaydol.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Kaydol.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Kaydol.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Kaydol.ForeColor = System.Drawing.Color.White;
            this.Kaydol.Location = new System.Drawing.Point(646, 209);
            this.Kaydol.Name = "Kaydol";
            this.Kaydol.Size = new System.Drawing.Size(128, 83);
            this.Kaydol.TabIndex = 3;
            this.Kaydol.Text = "Kaydol";
            this.Kaydol.Click += new System.EventHandler(this.Kaydol_Click);
            // 
            // testconnection
            // 
            this.testconnection.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.testconnection.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.testconnection.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.testconnection.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.testconnection.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.testconnection.ForeColor = System.Drawing.Color.White;
            this.testconnection.Location = new System.Drawing.Point(579, 154);
            this.testconnection.Name = "testconnection";
            this.testconnection.Size = new System.Drawing.Size(67, 27);
            this.testconnection.TabIndex = 4;
            this.testconnection.Text = "test";
            this.testconnection.Click += new System.EventHandler(this.testconnection_Click);
            // 
            // mySqlConnection1
            // 
            this.mySqlConnection1.ProvideClientCertificatesCallback = null;
            this.mySqlConnection1.ProvidePasswordCallback = null;
            this.mySqlConnection1.RemoteCertificateValidationCallback = null;
            // 
            // giris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(917, 536);
            this.Controls.Add(this.testconnection);
            this.Controls.Add(this.Kaydol);
            this.Controls.Add(this.KullaniciGiris);
            this.Controls.Add(this.AdminGiris);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Name = "giris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2Button AdminGiris;
        private Guna.UI2.WinForms.Guna2Button KullaniciGiris;
        private Guna.UI2.WinForms.Guna2Button Kaydol;
        private Guna.UI2.WinForms.Guna2Button testconnection;
        private MySqlConnector.MySqlConnection mySqlConnection1;
    }
}

