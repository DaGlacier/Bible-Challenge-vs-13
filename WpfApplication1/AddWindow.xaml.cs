using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        private void adddQuestionLoaded(object sender, RoutedEventArgs e)
        {

            /*
            try
            {
                conn.Open();
                so = "CREATE DATABASE IF NOT EXISTS `bibleChallenge`";
                cmd = new MySqlCommand(so, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
           */


            //   dataGridCustomers.DataContext = ds;

        }
        private static bool CheckDatabaseExists(MySqlConnection tmpConn, string databaseName)
        {
            string sqlCreateDBQuery;
            bool result = false;
            try
            {
                tmpConn = new MySqlConnection("server=(local)\\SQLEXPRESS;Trusted_Connection=yes");
                sqlCreateDBQuery = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", databaseName);
                using (tmpConn)
                {
                    using (MySqlCommand sqlCmd = new MySqlCommand(sqlCreateDBQuery, tmpConn))
                    {
                        tmpConn.Open();
                        object resultObj = sqlCmd.ExecuteScalar();
                        int databaseID = 0;
                        if (resultObj != null)
                        {
                            int.TryParse(resultObj.ToString(), out databaseID);
                        }
                        tmpConn.Close();
                        result = (databaseID > 0);
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
        private void createDataBase()
        {
            string so;
            string connStr = "SERVER=localhost;UID=root;PASSWORD=1234;";
            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlCommand cmd;
            try
            {
                conn.Open();
                so = "CREATE DATABASE IF NOT EXISTS `bibleChallenge`";
                cmd = new MySqlCommand(so, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void buttonAdd(object sender, RoutedEventArgs e)
        {
            var newForm = new AddCategoryQuestion();
            newForm.Show();
            this.Close();
        }
        private void backClicked(object sender, RoutedEventArgs e)
        {

            var newForm = new Navigation();
            newForm.Show();
            this.Close();
        }
    }
}