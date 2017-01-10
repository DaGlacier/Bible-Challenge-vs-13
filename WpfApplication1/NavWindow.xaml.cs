using MySql.Data.MySqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string table_name;
        public MainWindow(string table_name)
        {
            InitializeComponent();
            this.table_name = table_name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tekbok.Text = "Ati inawork msee";
        }

        private void questionLoaded(object sender, RoutedEventArgs e)
        {
            string connStr = "SERVER=localhost;DATABASE=biblechallenge;UID=root;PASSWORD=walewaseeflani123;";
            List<string> TableNames = new List<string>();//Stores table names in List<string> form
            MySqlConnection Conn;
            using (Conn = new MySqlConnection(connStr))
            {
                Conn.Open();
                string cmdStr = "SELECT qst_name FROM "+table_name+";";
                TableNames = MySqlCollectionQuery(Conn, cmdStr);
            }
            txtblockQuestion.Text = TableNames[0];
            Conn.Close();

        }
        public List<string> MySqlCollectionQuery(MySqlConnection connection, string cmd)
        {
            List<string> QueryResult = new List<string>();
            MySqlCommand cmdName = new MySqlCommand(cmd, connection);
            MySqlDataReader reader = cmdName.ExecuteReader();
            while (reader.Read())
            {
                QueryResult.Add(reader.GetString(0));
            }
            reader.Close();
            return QueryResult;
        }

        private void answerClicked(object sender, RoutedEventArgs e)
        {
            string connStr = "SERVER=localhost;DATABASE=biblechallenge;UID=root;PASSWORD=walewaseeflani123;";
            List<string> TableNames = new List<string>();//Stores table names in List<string> form
            MySqlConnection Conn;
            using (Conn = new MySqlConnection(connStr))
            {
                Conn.Open();
                string cmdStr = "SELECT qst_name FROM " + table_name + ";";
                TableNames = MySqlCollectionQuery(Conn, cmdStr);
            }
            txtblockAnswer.Text = TableNames[1];
            txtblockAnswer.Visibility = Visibility.Visible;
            Conn.Close();
        }

        private void btnBlueCorrect(object sender, RoutedEventArgs e)
        {
            var newForm = new BonusQuestion();
            newForm.Show();
            this.Close();
        }

        

        private void btnRedCorrect(object sender, RoutedEventArgs e)
        {


        }
    }
}
