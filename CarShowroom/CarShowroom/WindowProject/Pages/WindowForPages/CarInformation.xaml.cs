using CarShowroom.ClassesManagementDatabase;
using CarShowroom.SelectedClass;
using CarShowroomSystem.Window;
using CarShowroomSystem.WindowProject;
using Microsoft.Win32;
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
using System.Windows.Threading;

namespace CarShowroom.WindowProject.Pages.WindowForElement
{
    /// <summary>
    /// Логика взаимодействия для CarInformation.xaml
    /// </summary>
    public partial class CarInformation : Window
    {
        private string _Vin;
        FullCar car;
        Car auto;
        private DispatcherTimer dispatcherTimer;

        Eventslog eventslog = new Eventslog();
        private string login;
        public CarInformation(string Vin, string logi)
        {
            InitializeComponent();
            car = new FullCar();
            auto = new Car();
            _Vin = Vin;
            WindowLoaded();

            login = logi;

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
            label_suc.Visibility = Visibility.Hidden;
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            label_suc.Visibility = Visibility.Hidden;
            dispatcherTimer.IsEnabled = false;
        }
        private void WindowLoaded()
        {
            try
            {
                using (var db = new CarShowroomContext())
                {
                    var users = from manufac in db.Manufacturers
                                join model in db.Models on manufac.Id equals model.ManufacturerId
                                join eq in db.Equipment on model.Id equals eq.ModelId
                                join car in db.Cars on eq.Id equals car.EquipmentId
                                where car.Vin == _Vin
                                select new
                                {
                                    _Vin = car.Vin,
                                    _manufacturer = manufac.Carbrand,
                                    _model = model.NameModel,
                                    _idEq = car.EquipmentId,
                                    _equipment = eq.NameEquipment,
                                    _releaseDate = Convert.ToDateTime(car.ReleaseDate.Day + "." + car.ReleaseDate.Month + "." + car.ReleaseDate.Year),
                                    _fuel = eq.Fuel,
                                    _drive = eq.TypeDrive,
                                    _color = car.Color,
                                    _price = car.Price,
                                    _mileage = car.Mileage,
                                };

                    foreach (var item in users)
                    {
                        car.Vin = item._Vin;
                        car.Price = Convert.ToString(item._price);
                        car.ManufacModelEquip = item._manufacturer + " " + item._model + " " + item._equipment;
                        car.Fuel = item._fuel;
                        car.Date = item._releaseDate;
                        car.Drive = item._drive;
                        car.Color = item._color;
                        car.Mileage = item._mileage;
                        car.Vin = item._Vin;

                        auto.EquipmentId = item._idEq;
                        auto.Vin = item._Vin;
                        auto.ReleaseDate = item._releaseDate;
                        auto.Color = item._color;
                        auto.Mileage = item._mileage;
                        auto.Price = item._price;
                    }
                    TextBlock_Color.Text += car.Color;
                    TextBlock_Name.Content = car.ManufacModelEquip;
                    TextBlock_Date.SelectedDate = car.Date;
                    TextBlock_Drive.Text += car.Drive;
                    TextBlock_Fuel.Text += car.Fuel;
                    TextBlock_Price.Text += car.Price;
                    TextBlock_Vin.Text += car.Vin;
                    TextBlock_Mileage.Text += (car.Mileage == string.Empty) ? "0" : car.Mileage;

                    GetAccessories();

                }
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Не удалось загрузить страницу \nПопробуйте обновить таблицу");
            }
        }

        private void GetAccessories()
        {
            using (var db = new CarShowroomContext())
            {
                Car caren = new Car();
                caren = caren.Get(_Vin);
                var query = from typ in db.TypeAccessories
                            join ac in db.Accessories on typ.Id equals ac.TypeAccessoryId
                            where ac.CarId == caren.Id
                            select new
                            {
                                _id = ac.Id,
                                _type = typ.NameTypeAccessory,
                                _name = ac.NameAccessory,
                                _price = ac.Price,
                            };
                listViewAcess.ItemsSource = query.ToList();

            }
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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new CarShowroomContext())
                {
                    Car caren = new Car();
                    caren = caren.Get(_Vin);
                    var query = from typ in db.TypeAccessories
                                join ac in db.Accessories on typ.Id equals ac.TypeAccessoryId
                                where ac.CarId == caren.Id
                                select new
                                {
                                    _id = ac.Id,
                                    _type = typ.NameTypeAccessory,
                                    _name = ac.NameAccessory,
                                    _price = ac.Price,
                                };
                    int id = -1;
                    foreach (var item in listViewAcess.SelectedItems)
                    {
                        foreach (var items in query)
                        {
                            if (items.Equals(item))
                            {
                                id = items._id;
                                listViewAcess.Items.Remove(item);
                            }
                        }
                    }
                    if (id != -1)
                    {
                        Accessory accessory = new Accessory();
                        var a = accessory.DeleteInCar(id);
                    }
                }
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Не получилось удалить акссесуар у автомобиля");
            }
           
        }

        private void button_Edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                switch((string)button_Edit.Content)
                {
                    case "Изменить":
                        button_Edit.Content = "Принять Изменения";
                        TextBlock_Color.IsEnabled = true;
                        TextBlock_Drive.IsEnabled = true;
                        TextBlock_Fuel.IsEnabled = true;
                        TextBlock_Price.IsEnabled = true;
                        TextBlock_Mileage.IsEnabled = true;
                        TextBlock_Date.IsEnabled = true;
                        TextBlock_Vin.IsEnabled = true;
                        eventslog.AddEvents(login, "Информация", DateTime.Now, "Попытка изменить данные автомобиля");
                        break;

                    case "Принять Изменения":
                        button_Edit.Content = "Изменить";
                        TextBlock_Color.IsEnabled = false;
                        TextBlock_Drive.IsEnabled = false;
                        TextBlock_Fuel.IsEnabled = false;
                        TextBlock_Price.IsEnabled = false;
                        TextBlock_Mileage.IsEnabled = false;
                        TextBlock_Date.IsEnabled = false;
                        TextBlock_Vin.IsEnabled = false;
                        if (string.IsNullOrEmpty(TextBlock_Color.Text) ||
                          string.IsNullOrEmpty(TextBlock_Date.Text) ||
                          string.IsNullOrEmpty(TextBlock_Drive.Text) ||
                          string.IsNullOrEmpty(TextBlock_Fuel.Text) ||
                          string.IsNullOrEmpty(TextBlock_Price.Text) ||
                          string.IsNullOrEmpty(TextBlock_Mileage.Text) ||
                          string.IsNullOrEmpty(TextBlock_Date.Text) ||
                          string.IsNullOrEmpty(TextBlock_Vin.Text)
                          )
                        {
                            ErorrWindow.ShowS("все поля должны быть заполнены");
                            DefaultDot();
                            break;
                        }
                        Car chechCar = new Car();
                        chechCar = chechCar.Get(TextBlock_Vin.Text);
                        if (chechCar != null)
                        {
                            ErorrWindow.ShowS("Автомобиль с таким Vin уже существует");
                            DefaultDot();
                            break;
                        }
                        Car cart = new Car();
                        if (car.Drive != TextBlock_Drive.Text || car.Fuel != TextBlock_Fuel.Text)
                        {
                            var question = MessageBox.Show("Вы изменили комплектацию! \nПринять изменения?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                            if (question == MessageBoxResult.Yes)
                            {
                                Equipment equipment = new Equipment();
                                eventslog.AddEvents(login, "Изменение", DateTime.Now, "Изменение комплектации "+Convert.ToString(car.ManufacModelEquip) + " VIN автомобиля: " + car.Vin );
                                equipment.FullEdit(auto.EquipmentId, TextBlock_Drive.Text, TextBlock_Fuel.Text);
                                
                                cart.FullEdit(car.Vin, TextBlock_Color.Text,TextBlock_Mileage.Text,Convert.ToDateTime(TextBlock_Date.Text), Convert.ToInt32(TextBlock_Price.Text), TextBlock_Vin.Text);
                                label_suc.Visibility = Visibility.Visible;
                                dispatcherTimer.Start();
                            }
                            else
                            {
                                DefaultDot();
                                return;
                            }
                        }
                        else
                        {
                            cart.FullEdit(car.Vin, TextBlock_Color.Text, TextBlock_Mileage.Text, Convert.ToDateTime(TextBlock_Date.Text),Convert.ToInt32(TextBlock_Price.Text), TextBlock_Vin.Text);
                            eventslog.AddEvents(login, "Изменение", DateTime.Now, "Изменение автомобиля" + Convert.ToString(car.ManufacModelEquip) + " VIN автомобиля: " + car.Vin);
                            label_suc.Visibility = Visibility.Visible;
                            dispatcherTimer.Start();
                        }
                        break;
                }
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Невозможно применить изменения");
                DefaultDot();
                eventslog.AddEvents(login, "Ошибка", DateTime.Now, "не удалось изменить данные автомобиля");
            }
            
        }
        private void DefaultDot()
        {
            TextBlock_Color.Text =  car.Color;
            TextBlock_Date.SelectedDate = car.Date;
            TextBlock_Drive.Text = car.Drive;
            TextBlock_Fuel.Text = car.Fuel;
            TextBlock_Price.Text = car.Price;
            TextBlock_Vin.Text = car.Vin;
            TextBlock_Mileage.Text = (car.Mileage == string.Empty) ? "0" : car.Mileage;
        }
        private void TextBlock_Price_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBlock_Mileage_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
