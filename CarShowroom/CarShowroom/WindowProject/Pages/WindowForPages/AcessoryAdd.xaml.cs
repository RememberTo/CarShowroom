using CarShowroom.ClassesManagementDatabase;
using CarShowroomSystem.Window;
using CarShowroomSystem.WindowProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CarShowroom.WindowProject.Pages.WindowForPages
{
    /// <summary>
    /// Логика взаимодействия для AcessoryAdd.xaml
    /// </summary>
    public partial class AcessoryAdd : Window
    {
        private int _idType;
        private DispatcherTimer dispatcherTimer;
        private string login;
        Eventslog eventslog = new Eventslog();
        public AcessoryAdd(string logi)
        {
            InitializeComponent();
            WindowLoaded();

            login = logi;

            TextBox_type.Visibility = Visibility.Hidden;
            DataGridTypeAccess.Visibility = Visibility.Hidden;
            TextBox_Name.Visibility = Visibility.Hidden;
            TextBox_Opis.Visibility = Visibility.Hidden;
            TextBox_Price.Visibility = Visibility.Hidden;
            label_suc.Visibility = Visibility.Hidden;

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            label_suc.Visibility = Visibility.Hidden;
            dispatcherTimer.IsEnabled = false;
        }

        private void WindowLoaded()
        {
            using (var db = new CarShowroomContext())
            {
                var type = from typ in db.TypeAccessories select new { _id = typ.Id, _typ = typ.NameTypeAccessory};
                DataGridTypeAccess.ItemsSource = type.ToList();
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
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

        private void Visible(bool isType)
        {
            if (isType)
            {
                TextBox_type.Visibility = Visibility.Visible;
                DataGridTypeAccess.Visibility = Visibility.Hidden;
                TextBox_Name.Visibility = Visibility.Hidden;
                TextBox_Opis.Visibility = Visibility.Hidden;
                TextBox_Price.Visibility = Visibility.Hidden;
                TextBox_type.IsEnabled = true;
                TextBox_type.Text = string.Empty;
            }
            else
            {
                TextBox_type.Visibility = Visibility.Visible;
                DataGridTypeAccess.Visibility = Visibility.Visible;
                TextBox_Name.Visibility = Visibility.Visible;
                TextBox_Opis.Visibility = Visibility.Visible;
                TextBox_Price.Visibility = Visibility.Visible;
                TextBox_type.IsEnabled = false;
                TextBox_type.Text = string.Empty;
            }
        }

        private void Radio_Type_Checked(object sender, RoutedEventArgs e)
        {
            Visible(true);
        }

        private void Radio_Name_Checked(object sender, RoutedEventArgs e)
        {
            Visible(false);
        }

        private void TextBox_Price_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        private void DataGridTypeAccess_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                using (var db = new CarShowroomContext())
                {
                    var type = from typ in db.TypeAccessories select new { _id = typ.Id, _typ = typ.NameTypeAccessory };

                    foreach (var item in DataGridTypeAccess.SelectedItems)
                    {
                        foreach (var items in type)
                        {
                            if (items.Equals(item))
                            {
                                TextBox_type.Text = items._typ;
                                _idType = items._id;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Не удалось добавить тип аксессуара");
            }
            
        }

        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            if(Radio_Name.IsChecked == true)
            {
                AddAccessory();
                eventslog.AddEvents(login, "Добавление", DateTime.Now, "Добавление аксессуара");
            }
            else if (Radio_Type.IsChecked == true)
            {
                AddType();
                eventslog.AddEvents(login, "Добавление", DateTime.Now, "Добавление типа аксессуара");
            }
            else
            {
                ErorrWindow.ShowS("Выберите что хотите добавить");
            }
        }

        private void AddAccessory()
        {
            try
            {
                if (string.IsNullOrEmpty(TextBox_type.Text) || string.IsNullOrEmpty(TextBox_Name.Text) || string.IsNullOrEmpty(TextBox_Price.Text))
                {
                    ErorrWindow.ShowS("Заполните все поля\nТип аксессуара(Двойной клик на элемент в таблице)\nНазвание аксессуара\nЦена");
                }
                else
                {
                    Accessory type = new Accessory();
                    type.Add(TextBox_Name.Text, Convert.ToInt32(TextBox_Price.Text), _idType, null, TextBox_Opis.Text);

                    TextBox_Name.Text = string.Empty;
                    TextBox_Price.Text = string.Empty;
                    TextBox_Opis.Text = string.Empty;
                    TextBox_type.Text = string.Empty;

                    label_suc.Visibility = Visibility.Visible;
                    dispatcherTimer.Start();
                }
            }
            catch (Exception)
            {
                eventslog.AddEvents(login, "Ошибка", DateTime.Now, "Добавление аксессуара");
                ErorrWindow.ShowS("Не удалось добавить аксессуар");
            }

        }

        private void AddType()
        {
            try
            {
                if (string.IsNullOrEmpty(TextBox_type.Text))
                {
                    ErorrWindow.ShowS("Заполните поле");
                }
                else
                {
                    TypeAccessory type = new TypeAccessory();
                    type.Add(TextBox_type.Text);

                    TextBox_Name.Text = string.Empty;
                    TextBox_Price.Text = string.Empty;
                    TextBox_Opis.Text = string.Empty;
                    TextBox_type.Text = string.Empty;

                    label_suc.Visibility = Visibility.Visible;
                    dispatcherTimer.Start();
                }
            }
            catch (Exception)
            {
                eventslog.AddEvents(login, "Ошибка", DateTime.Now, "Добавление типа аксессуара");
                ErorrWindow.ShowS("Не удалось добавить аксессуар");
            }
           
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new CarShowroomContext())
                {
                    var type = from typ in db.TypeAccessories select new { _id = typ.Id, _typ = typ.NameTypeAccessory };

                    foreach (var item in DataGridTypeAccess.SelectedItems)
                    {
                        foreach (var items in type)
                        {
                            if (items.Equals(item))
                            {
                                TextBox_type.Text = items._typ;
                                _idType = items._id;
                            }
                        }
                    }

                }
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Не удалось добавить тип аксессуара");
            }
        }

        private void TextBox_Amount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
