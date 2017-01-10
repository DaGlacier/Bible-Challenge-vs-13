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
    /// Interaction logic for AddCategoryQuestion.xaml
    /// </summary>
    public partial class AddCategoryQuestion : Window
    {
        string Table_Name;
        string main_string;
        public AddCategoryQuestion()
        {
            InitializeComponent();
            
        }

       

        private void questionsaved(object sender, RoutedEventArgs e)
        {
            /*string strCheck = "INSERT INTO exodus (qst_name,qst_ans,qst_bonus) VALUES('Whom am I','Mark','Haina Ile')";
            string connStr2 = "SERVER=localhost;DATABASE=biblechallenge;UID=root;PASSWORD=1234;";
            MySqlConnection conn2 = new MySqlConnection(connStr2);
            MySqlCommand cmd2;

            conn2.Open();

            cmd2 = new MySqlCommand(strCheck, conn2);
            cmd2.ExecuteNonQuery();
            conn2.Close();
            MessageBox.Show("The Category has been Saved!");*/
            main_string = txtCategory.Text + "#" +qstTextBlock.Text+"#" +answerTxtBlock.Text;
            var newForm = new AddBonusQst(main_string);
            newForm.Show();
           
        }

        private void backClicked(object sender, RoutedEventArgs e)
        {

            var newForm = new AddWindow();
            newForm.Show();
            this.Close();
        }
    }
}
