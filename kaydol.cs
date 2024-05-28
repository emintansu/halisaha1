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
using System.Data.Sql;
using System.Data.SqlClient;

namespace halisaha
{
    public partial class kaydol : Form
    {

        public kaydol()
        {
            InitializeComponent();
        }


      

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            giris giris = new giris();
            giris.Show();
            this.Hide();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void kaydol_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string username = ad.Text;
            string userLastName = soyad.Text;
            string userPhone = telefon.Text;
            string userAgeText = yas.Text;
            string userPassword = sifre.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(userLastName) ||
                string.IsNullOrWhiteSpace(userPhone) || string.IsNullOrWhiteSpace(userAgeText) ||
                string.IsNullOrWhiteSpace(userPassword))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(userAgeText, out int userAge))
            {
                MessageBox.Show("Yaş geçerli bir sayı olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!userPhone.All(char.IsDigit) || userPhone.Length != 11)
            {
                MessageBox.Show("Telefon numarası 11 haneli bir sayı olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool isUserAdded = DatabaseHelper.AddUser(username, userLastName, userPhone, userAge, userPassword);
            if (isUserAdded)
            {
                MessageBox.Show("Kullanıcı başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KullaniciGiris kullanici = new KullaniciGiris();
                kullanici.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı kaydedilemedi. Lütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }

