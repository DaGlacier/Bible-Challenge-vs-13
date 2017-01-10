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
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for BonusQuestion.xaml
    /// </summary>
    public partial class BonusQuestion : Window
    {
        public BonusQuestion()
        {
            InitializeComponent();
        }

        private void answerClicked(object sender, RoutedEventArgs e)
        {
            string connStr = "SERVER=localhost;DATABASE=biblechallenge;UID=root;PASSWORD=walewaseeflani123;";
            List<string> TableNames = new List<string>();//Stores table names in List<string> form
            MySqlConnection Conn;
            using (Conn = new MySqlConnection(connStr))
            {
                Conn.Open();
                string cmdStr = "SELECT qst_ans FROM exodus;";
                TableNames = MySqlCollectionQuery(Conn, cmdStr);
            }
            txtblockAnswer.Text = TableNames[1];
            txtblockAnswer.Visibility = Visibility.Visible;
            Conn.Close();
        }

        private void btnBlueCorrect(object sender, RoutedEventArgs e)
        {

        }

        private void bonusLoaded(object sender, RoutedEventArgs e)
        {

            string connStr = "SERVER=localhost;DATABASE=biblechallenge;UID=root;PASSWORD=walewaseeflani123;";
            List<string> TableNames = new List<string>();//Stores table names in List<string> form
            MySqlConnection Conn;
            using (Conn = new MySqlConnection(connStr))
            {
                Conn.Open();
                string cmdStr = "SELECT qst_bonus FROM exodus;";
                TableNames = MySqlCollectionQuery(Conn, cmdStr);
            }
            txtblockQuestion.Text = TableNames[1];
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
    }
}
