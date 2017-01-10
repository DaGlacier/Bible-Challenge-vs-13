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
    /// Interaction logic for Navigation.xaml
    /// </summary>
    public partial class Navigation : Window
    {
        public Navigation()
        {
            InitializeComponent();
        }

        private void newGameClicked(object sender, RoutedEventArgs e)
        {
            var newForm = new NewWindow();
            newForm.Show();
            this.Close();
        }

        private void addQuestionsClicked(object sender, RoutedEventArgs e)
        {
            var newForm = new AddWindow();
            newForm.Show();
            this.Close();
        }

        private void highScoreClicked(object sender, RoutedEventArgs e)
        {

        }
    }
}
