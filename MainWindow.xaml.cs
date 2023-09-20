using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Documents;
using System.Collections.Generic;
using System;
using System.Windows.Controls;
using System.Windows.Data;
using System.ComponentModel;

namespace AWP_WPF_Project
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SelectAllMovies();
            SelectAllShows();
        }

        private void BtnCollapse_Click(object sender, RoutedEventArgs e)
        {
            if (BorderMenu.Visibility == Visibility.Collapsed)
            {
                BorderMenu.Visibility = Visibility.Visible;
            }
            else
            {
                BorderMenu.Visibility = Visibility.Collapsed;
            }
        }
        private SqlConnection MySqlConnection()
        {
            var connection = ConfigurationManager.ConnectionStrings["MediaConnectionString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            return sqlConnection;
        }
        private SqlCommand MySqlCommand(string command)
        {
            SqlCommand sqlCommand = new SqlCommand(command, MySqlConnection());
            sqlCommand.CommandType = CommandType.Text;
            return sqlCommand;
        }
        public void SelectAllMovies()
        {
            using (SqlConnection con = MySqlConnection())
            {
                string query = "SELECT * FROM MEDIUM WHERE MOVIE = 1";
                SqlCommand command = MySqlCommand(query);
                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataTable dt = new DataTable("Medium");
                sda.Fill(dt);
                MovieTable.ItemsSource = dt.DefaultView;
            }
        }
        public void SelectAllShows()
        {
            using (SqlConnection con = MySqlConnection())
            {
                string query = "SELECT * FROM MEDIUM WHERE SHOW = 1";
                SqlCommand command = MySqlCommand(query);
                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataTable dt = new DataTable("Medium");
                sda.Fill(dt);
                ShowTable.ItemsSource = dt.DefaultView;
            }
        }
    }
}
