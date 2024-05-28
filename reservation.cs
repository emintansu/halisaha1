using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore.Internal;
using MySql.Data.MySqlClient;
namespace halisaha
{
    public partial class reservation : Form
    {
        public reservation()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            KullaniciGiris kullaniciGiris = new KullaniciGiris();
            kullaniciGiris.Show();
            this.Hide();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string hour = ComboBox1.SelectedItem.ToString();
            string date = tarih.Value.ToString("MM/dd/yyyy");

            if (DatabaseHelper.Checkreservationisempty(date, hour))
            {
                string phoneNumber = User.PhoneNumber;
                Tuple<int, string> userData = DatabaseHelper.GetUserNameAndIdByPhoneNumber(phoneNumber);
                int userId = userData.Item1;
                string userName = userData.Item2;



                DatabaseHelper.InsertReservation(userId, userName, hour, date);
                MessageBox.Show("Rezervasyonunuz gerceklesti }");
                RefreshReservations();
            }
            else
            {
                MessageBox.Show("Girdiginiz tarih dolu ");
            }

        }

        private void guna2ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void tar_ValueChanged(object sender, EventArgs e)
        {

        }

        private void reservation_Load(object sender, EventArgs e)
        {
            string phoneNumber = User.PhoneNumber;
            DataTable user_reservations = DatabaseHelper.GetReservations1(phoneNumber);
            datagriduser.DataSource = user_reservations;
        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void sil_Click(object sender, EventArgs e)
        {

        }

        private void sil_Click_1(object sender, EventArgs e)
        {
            if (datagriduser.SelectedRows.Count > 0)
            {
                int reservationId = Convert.ToInt32(datagriduser.SelectedRows[0].Cells["res_id"].Value);

                bool success = DatabaseHelper.DeleteReservation(reservationId);

                if (success)
                {
                    MessageBox.Show("Rezervasyon başarıyla silindi.");
                    RefreshReservations();
                }
                else
                {
                    MessageBox.Show("Rezervasyon silinirken bir hata oluştu.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir rezervasyon seçin.");
            }
        }
        private void RefreshReservations()
        {
            string phoneNumber = User.PhoneNumber;
            DataTable reservationsTable = DatabaseHelper.GetReservations1(phoneNumber);

            if (reservationsTable == null || reservationsTable.Rows.Count == 0)
            {
                MessageBox.Show("Rezervasyonunuz bulunmamaktadır.");
                datagriduser.DataSource = null;
            }
            else
            {
                datagriduser.DataSource = reservationsTable;
            }
        }

        private void guncelle_Click(object sender, EventArgs e)
        {
            string saat = ComboBox1.Text.ToString();
            string date = tarih.Value.ToString("MM/dd/yyyy");
            if (DatabaseHelper.Checkreservationisempty(date, saat)) { 
            
            if (datagriduser.SelectedRows.Count > 0)
            {
                // Seçilen satırın rezervasyon ID'sini al
                int reservationID = Convert.ToInt32(datagriduser.SelectedRows[0].Cells["res_id"].Value);

                // Rezervasyonu güncelle
                if (DatabaseHelper.UpdateReservation(reservationID, saat, date))
                {
                    MessageBox.Show($"Rezervasyon güncellendi: Tarih: {date}, Saat: {saat}");
                    // DataGridView'i yenile
                    string phoneNumber = User.PhoneNumber;
                    DataTable user_reservations = DatabaseHelper.GetReservations1(phoneNumber);
                    datagriduser.DataSource = user_reservations;
                    RefreshReservations();
                }
                else
                {
                    MessageBox.Show("Rezervasyon güncellenirken bir hata oluştu.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek için bir rezervasyon seçin.");
            }
        }
            else
            {
                MessageBox.Show("girdiginiz tarih dolu");
            }
        }
    }
    
}

