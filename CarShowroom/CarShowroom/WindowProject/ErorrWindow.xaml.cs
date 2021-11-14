using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarShowroomSystem.WindowProject
{
    /// <summary>
    /// Логика взаимодействия для ErorrWindow.xaml
    /// </summary>
    public partial class ErorrWindow
    {
        public ErorrWindow(string error)
        {
            InitializeComponent();
            lblString.Text += error;
        }
        public static void ShowS(string error)
        {
            ErorrWindow erorrWindow = new ErorrWindow(error);
            erorrWindow.Show();
        }
        private void button_getPrice_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
