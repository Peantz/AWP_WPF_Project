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
            Database.SelectAllMovies();
            Database.SelectAllShows();
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
        
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            CreateMedium create = new CreateMedium();
            create.Show();
        }
    }
}
