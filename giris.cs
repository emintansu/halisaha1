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
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void Kaydol_Click(object sender, EventArgs e)
        {
            kaydol kaydol =new kaydol();
            kaydol.Show();
            this.Hide();

        }

        private void AdminGiris_Click(object sender, EventArgs e)
        {
            AdminGiris adminGiris = new AdminGiris();
            adminGiris.Show();
            this.Hide();
        }

        private void KullaniciGiris_Click(object sender, EventArgs e)
        {
            KullaniciGiris kullaniciGiris = new KullaniciGiris();
            kullaniciGiris.Show();
            this.Hide();
        }

        private void testconnection_Click(object sender, EventArgs e)
        {
            string connectionMessage = DatabaseHelper.TestConnection();
            MessageBox.Show(connectionMessage);
        }
    }
}
