using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWP_WPF_Project
{
    internal class Database
    {
        private static MainWindow mainWindow = new MainWindow();

        private static SqlConnection MySqlConnection()
        {
            var connection = ConfigurationManager.ConnectionStrings["MediaConnectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            return sqlConnection;
        }

        private static SqlCommand MySqlCommand(string command)
        {
            SqlCommand sqlCommand = new SqlCommand(command, MySqlConnection());
            sqlCommand.CommandType = CommandType.Text;
            return sqlCommand;
        }

        public static void SelectAllMovies()
        {
            using (SqlConnection con = MySqlConnection())
            {
                string query = "SELECT * FROM MEDIUM WHERE MOVIE = 1";
                SqlCommand command = MySqlCommand(query);
                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataTable dt = new DataTable("Medium");
                sda.Fill(dt);
                mainWindow.MovieTable.ItemsSource = dt.DefaultView;
            }
        }

        public static void SelectAllShows()
        {
            using (SqlConnection con = MySqlConnection())
            {
                string query = "SELECT * FROM MEDIUM WHERE SHOW = 1";
                SqlCommand command = MySqlCommand(query);
                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataTable dt = new DataTable("Medium");
                sda.Fill(dt);
                mainWindow.ShowTable.ItemsSource = dt.DefaultView;
            }
        }
    }


}
