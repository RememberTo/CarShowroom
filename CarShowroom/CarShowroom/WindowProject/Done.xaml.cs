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

namespace CarShowroom.WindowProject
{
    /// <summary>
    /// Логика взаимодействия для Done.xaml
    /// </summary>
    public partial class Done : Window
    {
        public Done(string error)
        {
            InitializeComponent();
            lblString.Text += error;
        }
        public static void ShowS(string error)
        {
            Done done = new Done(error);
            done.Show();
        }
        private void button_getPrice_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
