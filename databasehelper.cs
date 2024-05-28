using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq.Expressions;
using System.Windows.Forms;
using halisaha;
using MySql.Data.MySqlClient;


public static class DatabaseHelper
{
    private static string connectionString = "server=localhost;database=halisaha;uid=root;pwd=;";

    public static MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }

    public static bool ExecuteNonQuery(string query, params MySqlParameter[] parameters)
    {
        using (MySqlConnection connection = GetConnection())
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddRange(parameters);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }

    public static MySqlDataReader ExecuteQuery(string query, params MySqlParameter[] parameters)
    {
        MySqlConnection connection = GetConnection();
        MySqlCommand cmd = new MySqlCommand(query, connection);
        cmd.Parameters.AddRange(parameters);

        try
        {
            connection.Open();
            return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            connection.Close();
            throw;
        }
    }

    public static string TestConnection()
    {
        using (MySqlConnection connection = GetConnection())
        {
            try
            {
                connection.Open();
                return "Bağlantı başarılı!";
            }
            catch (Exception ex)
            {
                return $"Bağlantı başarısız: {ex.Message}";
            }
        }
    }
    public static bool AddUser(string userName, string userLastName, string userPhone, int userAge, string userPassword)
    {
        using (MySqlConnection connection = GetConnection())
        {
            string query = "INSERT INTO user (username, user_lastname, user_phone, user_age, user_password) VALUES (@username, @user_lastname, @user_phone, @user_age, @user_password)";
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@username", userName);
                cmd.Parameters.AddWithValue("@user_lastname", userLastName);
                cmd.Parameters.AddWithValue("@user_phone", userPhone);
                cmd.Parameters.AddWithValue("@user_age", userAge);
                cmd.Parameters.AddWithValue("@user_password", userPassword);

                try
                {
                    connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

        }
    }
    public static bool CheckUserLogin(string phone, string password)
    {
        using (MySqlConnection connection = GetConnection())
        {
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM user WHERE user_phone = @user_phone AND user_password = @user_password";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@user_phone", phone);
                    cmd.Parameters.AddWithValue("@user_password", password);

                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    return result > 0;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Veritabanı hatası: {ex.Message}\n" +
                                $"Hata kodu: {ex.Number}\n" +
                                $"SQL Durumu: {ex.SqlState}\n" +
                                $"Veritabanı: {connection.Database}\n" +
                                $"Sunucu: {connection.DataSource}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmedik hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
    public static bool Checkreservationisempty(string date, string hour)
    {
        using (MySqlConnection connection = GetConnection())
        {
            try
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM reservation WHERE res_date = @res_date AND res_hour = @res_hour";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@res_date", date);
                    cmd.Parameters.AddWithValue("@res_hour", hour);
                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    return result ==0;
                }
            }
            catch
            {

                return false;
            }


        }
    }
    public static bool InsertReservation(int userId, string userName, string hour, string date)
    {
        using (MySqlConnection connection = GetConnection())
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO reservation (user_id, user_name, res_date, res_hour) VALUES (@user_id, @user_name, @res_date, @res_hour)";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@user_id", userId);
                    cmd.Parameters.AddWithValue("@user_name", userName);
                    cmd.Parameters.AddWithValue("@res_date", date);
                    cmd.Parameters.AddWithValue("@res_hour", hour);

                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
                return false;
            }
        }
    

}
public static Tuple<int, string> GetUserNameAndIdByPhoneNumber(string phoneNumber)
    {
       
        using (MySqlConnection connection = GetConnection())
        {
            try
            {
                connection.Open();
                string query = "SELECT user_id, username FROM user WHERE user_phone = @phone";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@phone", phoneNumber);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int userId = reader.GetInt32("user_id");
                            string userName = reader.GetString("username");
                            
                            return new Tuple<int, string>(userId, userName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }
        return null; // kullanıcı bulunamazsa null döner
    }
    public static bool DeleteReservation(int reservationID)
    {
        using (MySqlConnection connection = GetConnection())
        {
            string query = "DELETE FROM reservation WHERE res_id = @res_id";
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@res_id", reservationID);

                try
                {
                    connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
    }

    public static bool DeleteReservation1(int reservationId)
    {
        using (MySqlConnection connection = GetConnection())
        {
            string query = "DELETE FROM reservation WHERE reservation_id = @reservation_id";
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@reservation_id", reservationId);

                try
                {
                    connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                    return false;
                }
            }
        }
    }


public static bool DeleteUser(string userPhone)
    {
        using (MySqlConnection connection = GetConnection())
        {
            string query = "DELETE FROM user WHERE user_phone = @user_phone";
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@user_phone", userPhone);

                try
                {
                    connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
    }

    public static DataTable GetReservations()
    {
        DataTable dataTable = new DataTable();
        using (MySqlConnection connection = GetConnection())
            connection.Open();
        try
        {
            string query = "SELECT * FROM reservation"; // Rezervasyonlar tablosunun adını ve sütunlarını uygun şekilde değiştirin
            using (MySqlDataReader reader = ExecuteQuery(query))
            {
                if (reader.HasRows)
                {
                    dataTable.Load(reader);

                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            MessageBox.Show(ex.Message);

        }

        return dataTable;
    }
    public static DataTable GetReservations1(string phoneNumber)
    {
        Tuple<int, string> userData = DatabaseHelper.GetUserNameAndIdByPhoneNumber(phoneNumber);
        int userId = userData.Item1;
        DataTable dataTable = new DataTable();
        using (MySqlConnection connection = GetConnection())
        {
            try
            {
                connection.Open();
                string query = "SELECT * FROM reservation WHERE user_id = @user_id";

                using (var cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@user_id", userId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dataTable.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        return dataTable;

       
    }

    public static DataTable GetUsers()
    {
        DataTable dataTable = new DataTable();

        try
        {
            string query = "SELECT * FROM user";
            using (MySqlDataReader reader = ExecuteQuery(query))
            {
                if (reader.HasRows)
                {
                    // Verileri DataTable'a doldur
                    dataTable.Load(reader);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return dataTable;
    }
    public static bool UpdateReservation(int reservationID, string hour, string date)
    {
        using (MySqlConnection connection = GetConnection())
        {
            string query = "UPDATE reservation SET res_hour = @hour, res_date = @date WHERE res_id = @reservationID";
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@hour", hour);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@reservationID", reservationID);

                try
                {
                    connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    MessageBox.Show("buraya girdi");
                    return result > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                  
                    return false;
                }
            }
        }
    }


    /* public static Tuple<string, string,string> reservation_table(string phoneNumber)
     {
         using (MySqlConnection connection = GetConnection())
         {
             try
             {
                 connection.Open();
                 string query = "SELECT * FROM reservation WHERE user_phone = @phone";
                 using (var cmd = new MySqlCommand(query, connection))
                 {

                     cmd.Parameters.AddWithValue("@phone", phoneNumber);
                     using (var reader = cmd.ExecuteReader())
                     {
                         if (reader.Read())
                         {


                         }
                     }
                 }
             }
             catch
             {

             }

         }

     }
    */

}

