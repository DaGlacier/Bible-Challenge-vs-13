﻿using System;
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
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void ButtonClicked(object sender, MouseEventArgs e)
        {

            var newForm = new NewWindow();
            newForm.Show();
            this.Close();
        }

        private void nextClicked(object sender, RoutedEventArgs e)
        {
            var newForm = new NewWindow();
            newForm.Show();
            this.Close();
        }
    }
}
