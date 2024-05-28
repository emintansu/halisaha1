using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace halisaha
{
    public partial class AdminGiris : Form
    {
        public AdminGiris()
        {
            InitializeComponent();
        }

        private void AdminGiris_Load(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            giris giris = new giris();
            giris.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string adminUserName = "admin";
            string adminPassword = "123";

            // Kullanıcının girdiği kullanıcı adı ve şifresi
            string enteredUserName = guna2TextBox1.Text.Trim();
            string enteredPassword = guna2TextBox2.Text.Trim();

            // Kullanıcı adı ve şifre doğrulama
            if (enteredUserName == adminUserName && enteredPassword == adminPassword)
            {
                // Doğruysa AdminPaneli formunu aç
                AdminPaneli adminPaneli = new AdminPaneli();
                adminPaneli.Show();
                this.Hide();
            }
        }
    }
}
