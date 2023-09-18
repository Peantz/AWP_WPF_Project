﻿using System.Windows;
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
        }

        private void BtnCollapse_Click(object sender, RoutedEventArgs e)
        {
            if (DockPanelMenu.Visibility == Visibility.Collapsed)
            {
                DockPanelMenu.Visibility = Visibility.Visible;
            }
            else
            {
                DockPanelMenu.Visibility = Visibility.Collapsed;
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
    }
}
