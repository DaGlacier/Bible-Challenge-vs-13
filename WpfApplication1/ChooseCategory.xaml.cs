using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for ChooseCategory.xaml
    /// </summary>
    public partial class ChooseCategory : Window
        
    {
        string one;
        string two;
        string three;
        string four;
        public ChooseCategory()
        {
            InitializeComponent();
        }

        private void firstClicked(object sender, RoutedEventArgs e)
        {
            var newForm = new MainWindow(one);
            newForm.Show();
            this.Close();
            
        }

        private void categoryloaded(object sender, RoutedEventArgs e)
        {
            Storyboard sb = this.FindResource("box1") as Storyboard;
            sb.Begin();
            SystemSounds.Beep.Play(); 
            Storyboard sb2 = this.FindResource("box2") as Storyboard;
            sb2.Begin();
            SystemSounds.Beep.Play();
            Storyboard sb3 = this.FindResource("box3") as Storyboard;
            sb3.Begin();
            SystemSounds.Beep.Play();
            Storyboard sb4 = this.FindResource("box4") as Storyboard;
            sb4.Begin();
            SystemSounds.Beep.Play();

            string connStr = "SERVER=localhost;DATABASE=biblechallenge;UID=root;PASSWORD=1234;";
            List<string> TableNames = new List<string>();//Stores table names in List<string> form
            MySqlConnection Conn;
            using ( Conn = new MySqlConnection(connStr))
            {
                Conn.Open();
                string cmdStr = "SELECT table_name FROM information_schema.tables where table_schema='biblechallenge';";
                TableNames = MySqlCollectionQuery(Conn, cmdStr);
            }

            Conn.Close();
            
            int listLength = TableNames.Count;
            if (listLength < 5)
            {
                MessageBox.Show("You need to add more than four Categories");
                var newForm = new AddCategoryQuestion();
                newForm.Show();
                this.Close();

            }
            buttonOne.Content = FirstCharToUpper(TableNames[0]);
            one = TableNames[0];
            buttonTwo.Content = FirstCharToUpper(TableNames[1]);
            two =TableNames[1];
            buttonThree.Content = FirstCharToUpper(TableNames[2]);
            three =TableNames[2];
            buttonFour.Content = FirstCharToUpper(TableNames[3]);
            four = TableNames[3];
            
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
        /// <summary>
        /// Capitalizing a string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + input.Substring(1);
        }

        private void twoClicked(object sender, RoutedEventArgs e)
        {
            var newForm = new MainWindow(two );
            newForm.Show();
            this.Close();


        }

        private void fourClicked(object sender, RoutedEventArgs e)
        {

            var newForm = new MainWindow(four);
            newForm.Show();
            this.Close();
        }

        private void threeClicked(object sender, RoutedEventArgs e)
        {
            var newForm = new MainWindow(three);
            newForm.Show();
            this.Close();
        }
    }
}
