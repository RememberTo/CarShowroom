using CarShowroom.ClassesManagementDatabase;
using CarShowroom.WindowProject.Pages;
using CarShowroomSystem.Window.Pages;
using CarShowroomSystem.WindowProject.Pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarShowroomSystem.Window
{
    /// <summary>
    /// Логика взаимодействия для Work.xaml
    /// </summary>
    public partial class Work
    {
        pageCar car;
        pageAccessory aces;
        pageBidCar bid;
        pageContract con;
        Account account;
        pageEventslog pageEventslog;
        Eventslog eventsLog = new Eventslog();
        public string log { get; set; }
        public Work(string Fio, string login, string pos)
        {
            try
            {

                InitializeComponent();
                car = new pageCar(login);
                aces = new pageAccessory(login);
                bid = new pageBidCar(login);
                con = new pageContract(login);
                account = new Account(login);
                log = login;
                pageEventslog = new pageEventslog(login);

                ButtonEvent.Visibility = Visibility.Hidden;
                TickTimer();
               if (Fio == null && pos == null)
                    label_fiouser.Text = "Фролов Кирилл Дмитриевич" + "\nДолжность: " + "Менеджер";
               else { label_fiouser.Text = Fio + "\nДолжность: " + pos; }
                
            }
            catch (Exception)
            {
                this.Close();
                Application.Current.Shutdown();
            }
        }
        //public Work()
        //{
        //    try
        //    {
        //        InitializeComponent();
        //        TickTimer();
        //        log = "test";
        //        label_fiouser.Text = "Фролов Кирилл Дмитриевич" + "\nДолжность: " + "Менеджер";
        //    }
        //    catch (Exception)
        //    {
        //        this.Close();
        //        Application.Current.Shutdown();
        //    }  
        //}
        public void ControlButton(bool care, bool acces, bool contract, bool bidCar, bool even)
        {
            ButtonCar.IsEnabled = care;
            ButtonAccessory.IsEnabled = acces;
            ButtonContract.IsEnabled = contract;
            ButtonBidCar.IsEnabled = bidCar;
            ButtonEvent.IsEnabled = even;
        }
        private void TickTimer()
        {
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.IsEnabled = true;
            timer.Tick += (o, e) => { labelTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm"); };
            timer.Start();
        }

        #region buttonControls
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            eventsLog.AddEvents(log, "Выход", DateTime.Now, "Выход из системы");
            Application.Current.Shutdown();
        }

        private void ButtonMinimaized_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ButtonCar_Click(object sender, RoutedEventArgs e)
        {
            WorkTableFrame.Navigate(car);
            ControlButton(false, true, true, true, true);
        }

        private void ButtonAccessory_Click(object sender, RoutedEventArgs e)
        {
            WorkTableFrame.Navigate(aces);
            //WorkTableFrame.Content = new pageAccessory();
            ControlButton(true, false, true, true, true);
        }

        private void ButtonBidCar_Click(object sender, RoutedEventArgs e)
        {
            WorkTableFrame.Navigate(bid);
            ControlButton(true, true, true, false, true);
        }

        private void ButtonContract_Click(object sender, RoutedEventArgs e)
        {
            ControlButton(true, true, false, true, true);
            //WorkTableFrame.Navigate(con);
            WorkTableFrame.Content = con;
        }

        private void ButtonEvent_Click(object sender, RoutedEventArgs e)
        {
            ControlButton(true, true, true, true, false);
            WorkTableFrame.Navigate(pageEventslog);
        }
        #endregion

        private void ButtonClose_MouseEnter(object sender, MouseEventArgs e)
        {
            var brush = new SolidColorBrush(Colors.Red);
            ButtonClose.Foreground = brush;
        }

        private void ButtonClose_MouseLeave(object sender, MouseEventArgs e)
        {
            var brush = new SolidColorBrush(Colors.Black);
            ButtonClose.Foreground = brush;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WorkTableFrame.Navigate(account);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            eventsLog.AddEvents(log, "Выход", DateTime.Now, "Выход из системы");
            Application.Current.Shutdown();
        }
    }
}
