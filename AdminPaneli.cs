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
    public partial class AdminPaneli : Form
    {
        public AdminPaneli()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void AdminPaneli_Load(object sender, EventArgs e)
        {
            // Kullanıcıları al ve DataGridView1'e yükle
            DataTable usersTable = DatabaseHelper.GetUsers();
            dataGridView1.DataSource = usersTable;

            // Rezervasyonları al ve DataGridView2'ye yükle
            DataTable reservationsTable = DatabaseHelper.GetReservations();
            dataGridView2.DataSource = reservationsTable;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            giris giris = new giris();
            giris.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                // Seçilen satırın rezervasyon ID'sini al
                int selectedReservationID = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["res_id"].Value);

                // Rezervasyon sütununu veritabanından sil
                bool success = DatabaseHelper.DeleteReservation(selectedReservationID);

                if (success)
                {
                    MessageBox.Show("Rezervasyon başarıyla silindi.");
                    // DataGridView'i güncelle
                    dataGridView2.DataSource = DatabaseHelper.GetReservations();
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırın telefon numarasını al
                string selectedUserPhone = dataGridView1.SelectedRows[0].Cells["user_phone"].Value.ToString();

                // Kullanıcıyı veritabanından sil
                bool success = DatabaseHelper.DeleteUser(selectedUserPhone);

                if (success)
                {
                    MessageBox.Show("Kullanıcı başarıyla silindi.");
                    // DataGridView'i güncelle
                    dataGridView1.DataSource = DatabaseHelper.GetUsers();
                }
                else
                {
                    MessageBox.Show("Kullanıcı silinirken bir hata oluştu.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek için bir kullanıcı seçin.");
            }
        }
        private void RefreshDataGridView(DataGridView dataGridView, DataTable originalDataTable)
        {
            // DataGridView'i orijinal veri tablosuyla güncelle
            dataGridView.DataSource = originalDataTable;
        }
        private void SearchDataGridView(DataGridView dataGridView, string searchText, params string[] columns)
        {
            DataTable dt = dataGridView.DataSource as DataTable;
            if (dt != null)
            {
               
                // Filtreleme işlemi
                var filteredRows = dt.AsEnumerable().Where(row => columns.Any(col => row.Field<string>(col)?.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0));
                if (filteredRows.Any())
                {
                    DataTable filteredTable = filteredRows.CopyToDataTable();
                    dataGridView.DataSource = null; // DataGridView'in veri kaynağını temizle
                    dataGridView.DataSource = filteredTable; // Yeni filtrelenmiş verileri göster
                }
                else
                {
                    MessageBox.Show("Arama kriterlerine uygun kayıt bulunamadı.");
                    dataGridView.DataSource = dt; // Filtreleme sonrası sonuç bulunamazsa, orijinal tabloyu geri yükleyin
                }
            }
        }
        private void AdminPaneli_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Programı kapat
                Application.Exit();
            }
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DatabaseHelper.GetUsers();


            string searchText = textBox1.Text.Trim();
            SearchDataGridView(dataGridView1, searchText, "username", "user_phone", "user_password");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = DatabaseHelper.GetReservations();
            string searchText = textBox2.Text.Trim();
            SearchDataGridView(dataGridView2, searchText, "user_name", "res_date");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void yenile1_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource = DatabaseHelper.GetUsers();
        }

        private void yenile2_Click(object sender, EventArgs e)
        {
           
            dataGridView2.DataSource = DatabaseHelper.GetReservations();

        }
    }
}
