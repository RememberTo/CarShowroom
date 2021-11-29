using CarShowroom.ClassesManagementDatabase;
using CarShowroomSystem;
using CarShowroomSystem.Window;
using CarShowroomSystem.WindowProject;
using Microsoft.Win32;
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
using System.Windows.Threading;

namespace CarShowroom.WindowProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        private DispatcherTimer dispatcherTimer;
        Employee employee = new Employee();
        private string logi;
        public Account(string login)
        {
            try
            {
                InitializeComponent();
                var a = Authorization.login;
                WindowLoaded(login);
                logi = login;
                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 8);

            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Ошибка инициализации");
            }

        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            Password.Text = "**********";
            dispatcherTimer.IsEnabled = false;
        }
        private void WindowLoaded(string login)
        {
                employee = employee.GetEmployee(login, null);
            Login.Text = login;
                FIO.Text = employee.Fio;
                Depart.Text = employee.Departament;
                Position.Text = employee.Position;
                Phone.Text = employee.PhoneNumber;
                Password.Text = "**********";     
        }

        private void ButtonSourceImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                img.Source = new BitmapImage(fileUri);
                labelImg.Visibility = Visibility.Hidden;
            }
        }

        private void GetPass_Click(object sender, RoutedEventArgs e)
        {
            Password.Text = employee.Password;
            dispatcherTimer.Start();
        }

        private void ButtonCar_Click(object sender, RoutedEventArgs e)
        {
            listViewAccessory.Items.Add(TextBoxOpis.Text);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            int index = listViewAccessory.SelectedIndex;
            listViewAccessory.Items.RemoveAt(index);
        }

        private void InkCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
