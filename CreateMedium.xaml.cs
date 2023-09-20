using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AWP_WPF_Project
{
    /// <summary>
    /// Interaktionslogik für CreateMedium.xaml
    /// </summary>
    public partial class CreateMedium : Window
    {
        public CreateMedium()
        {
            InitializeComponent();
        }

        private void ButtonSafe_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Insert()
        {
            using (SqlConnection con = database.MySqlConnection())
            {
                string query = "SELECT * FROM MEDIUM WHERE MOVIE = 1";
                SqlCommand command = database.MySqlCommand(query);
                SqlDataAdapter sda = new SqlDataAdapter(command);
                DataTable dt = new DataTable("Medium");
                sda.Fill(dt);
                MovieTable.ItemsSource = dt.DefaultView;
            }
        }
    }
}
