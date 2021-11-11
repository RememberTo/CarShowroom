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
        static pageCar car = new pageCar();
        static pagePayment pay = new pagePayment();
        static pageAccessory aces = new pageAccessory();
        static pageBidCar bid = new pageBidCar();
        static pageContract con = new pageContract();
        public Work(string Fio, string pos)
        {

            InitializeComponent();
            TickTimer();
            if (Fio == null && pos == null)
                label_fiouser.Text = "Фролов Кирилл Дмитриевич" + "\nДолжность: " + "Менеджер";
            else { label_fiouser.Text = Fio + "\nДолжность: " + pos; }
        }
        public Work()
        {
            InitializeComponent();
            //TickTimer();
            label_fiouser.Text = "Фролов Кирилл Дмитриевич" + "\nДолжность: " + "Менеджер";


        }
        public void ControlButton (bool car, bool acces, bool contract, bool bidCar, bool pay)
        {
            ButtonCar.IsEnabled = car;
            ButtoPayment.IsEnabled = pay;
            ButtonAccessory.IsEnabled = acces;
            ButtonContract.IsEnabled = contract;
            ButtonBidCar.IsEnabled = bidCar;
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

        private void ButtonContract_Click(object sender, RoutedEventArgs e)
        {
            WorkTableFrame.Navigate(con);
            ControlButton(true, true, false, true, true);
        }

        private void ButtonBidCar_Click(object sender, RoutedEventArgs e)
        {
            WorkTableFrame.Navigate(bid);
            ControlButton(true, true, true, false, true);
        }

        private void ButtoPayment_Click(object sender, RoutedEventArgs e)
        {
            //WorkTableFrame.Content = new pagePayment();
            ControlButton(true, true, true, true, false);
            WorkTableFrame.Navigate(pay);
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
    }
}
