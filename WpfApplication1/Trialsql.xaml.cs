using System;
using System.Collections.Generic;
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
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Trialsql.xaml
    /// </summary>
    public partial class Trialsql : Window
    {
        public Trialsql()
        {
            InitializeComponent();
        }

        private void buttonClicked(object sender, RoutedEventArgs e)
        {
          string connStr = "SERVER=localhost;DATABASE=sakila;UID=root;PASSWORD=walewaseeflani123;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT customer_id,first_name,last_name,email FROM customer", conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds, "LoadDataBinding");
            dataGridCustomers.DataContext = ds;
            conn.Close();
        }
    }
}
