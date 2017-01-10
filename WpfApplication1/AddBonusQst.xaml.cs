using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddBonusQst.xaml
    /// </summary>
    public partial class AddBonusQst : Window
    {
         string main_string;
         string category_name;
         string main_question;
         string main_answer;
         string bonus_question;
         string bonus_answer;
        public AddBonusQst(string value)
        {
            InitializeComponent();
            this.main_string = value;
            
            string[] lines = Regex.Split(main_string, "#");
            category_name = lines[0];
            main_question = lines[1];
            main_answer = lines[2];
            categorytxt.Text = category_name;
            

        }

        private void backClicked(object sender, RoutedEventArgs e)
        {

            back();
        }
        
            private void back()
            {
             var newForm = new AddCategoryQuestion();
            newForm.Show();
            this.Close();
            }

        private void saveClicked(object sender, RoutedEventArgs e)
        {
           
                bonus_question = qstTextBlock.Text;
                bonus_answer = answerTxtBlock.Text;
                saveTableClicked();
                back();
                
           
        }
        private void saveTableClicked()
        {
            
            
            string strCheck = "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = 'biblechallenge' AND table_name = '" + category_name + "';";
            string connStr = "SERVER=localhost;UID=root;PASSWORD=1234;";

            MySqlConnection conn;
            using (conn = new MySqlConnection(connStr))
            {

                MySqlCommand cmd = new MySqlCommand(strCheck, conn);

                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {

                    int count = reader.GetInt32(0);

                    if (count == 0)
                    {
                        string cmdTable = "CREATE TABLE " + category_name + " (qst_id     INT(8) NOT NULL AUTO_INCREMENT, qst_name   VARCHAR(1000) NOT NULL, qst_ans   VARCHAR(255) NOT NULL, qst_bonus  VARCHAR(1000),bonus_ans   VARCHAR(255) NOT NULL NOT NULL, UNIQUE INDEX qst_name_unique (qst_name), PRIMARY KEY (qst_id)) Engine=INNODB;";

                        string connStr2 = "SERVER=localhost;DATABASE=biblechallenge;UID=root;PASSWORD=1234;";
                        MySqlConnection conn2 = new MySqlConnection(connStr2);
                        MySqlCommand cmd2;

                        conn2.Open();

                        cmd2 = new MySqlCommand(cmdTable, conn2);
                        cmd2.ExecuteNonQuery();
                        conn2.Close();
                        
                        insertTableValues();


                    }
                    else if (count == 1)
                    {
                        MessageBox.Show("The Category Already Exists!");
                        var newForm = new AddCategoryQuestion();
                        newForm.Show();
                    }


                }
            }
            conn.Close();
        }
        private void insertTableValues()
        {
            string strCheck = "INSERT INTO " + category_name + " (qst_name,qst_ans,qst_bonus,bonus_ans) VALUES('" + main_question + "','" + main_answer + "','" + bonus_question + "','" + bonus_answer + "')";
            string connStr2 = "SERVER=localhost;DATABASE=biblechallenge;UID=root;PASSWORD=1234;";
            MySqlConnection conn2 = new MySqlConnection(connStr2);
            MySqlCommand cmd2;

            conn2.Open();

            cmd2 = new MySqlCommand(strCheck, conn2);
            cmd2.ExecuteNonQuery();
            conn2.Close();
            MessageBox.Show("All is well.Saved!!");
        }
    }
}
