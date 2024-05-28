using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace halisaha
{
    public partial class KullaniciGiris : Form
    {
        
        public KullaniciGiris()
        {
            InitializeComponent();
        }

        private void KullaniciGiris_Load(object sender, EventArgs e)
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
            
                string phone = telefon1.Text;
                string password = sifre1.Text;

                // Telefon numarası ve şifre kontrolü
                if (string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Telefon numarası ve şifre boş geçilemez!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kullanıcı girişi kontrolü
                if (DatabaseHelper.CheckUserLogin(phone, password))
                {
               
                    User.PhoneNumber = phone;
                    MessageBox.Show($"Giriş başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reservation reservation = new reservation();
                    reservation.Show();
                    this.Hide();
                    
                // Burada başka bir forma geçiş yapabilirsiniz veya oturum açan kullanıcının bilgilerini yükleyebilirsiniz.
            }
                else
                {
                    MessageBox.Show("Telefon numarası veya şifre yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
      


    }
}

