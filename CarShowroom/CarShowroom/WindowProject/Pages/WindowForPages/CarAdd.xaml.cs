using CarShowroom.ClassesManagementDatabase;
using CarShowroom.SelectedClass;
using CarShowroomSystem.Window;
using CarShowroomSystem.WindowProject;
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

namespace CarShowroom.WindowProject.Pages.WindowForPages
{
    /// <summary>
    /// Логика взаимодействия для CarAdd.xaml
    /// </summary>
    public partial class CarAdd : Window
    {
        private DispatcherTimer dispatcherTimer;
        private int _idManufacturer = -1;
        private int _idModel = -1;
        private int _idEquipment = -1;

        Eventslog eventslog = new Eventslog();
        private string login;
        enum ControlRadio
        {
            Manufacturer = 1,
            Model = 2,
            Equipment = 3,
            Car = 4,
        }
        public CarAdd(string logi)
        {
            InitializeComponent();
            WindowLoaded();

            login = logi;

            VisibleTextBox(true, true, true, true);
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
            try
            {
                using (var db = new CarShowroomContext())
                {
                    var manufac = from m in db.Manufacturers select new { _id = m.Id, _name = m.Carbrand };

                    var model = from ml in db.Models select new { _id = ml.Id, _name = ml.NameModel };

                    var equip = from eq in db.Equipment
                                select new
                                {
                                    _id = eq.Id,
                                    _name = eq.NameEquipment,
                                    _drive = eq.TypeDrive,
                                    _fuel = eq.Fuel,
                                };
                    DataGridManufacturer.ItemsSource = manufac.ToList();
                    DataGridModel.ItemsSource = model.ToList();
                    DataGridEquip.ItemsSource = equip.ToList();
                }
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("На этапе инициализации");
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.ChangedButton == MouseButton.Left)
                    this.DragMove();
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("");
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

        private void ResetId()
        {
            _idManufacturer = -1;
            _idModel = -1;
            _idEquipment = -1;
        }

        private void Radio_Manufac_Checked(object sender, RoutedEventArgs e)
        {
            label_suc.Content = "Произовдитель добавлен!";
            BlockControl(ControlRadio.Manufacturer);
            ResetId();
        }

        private void Radio_Model_Checked(object sender, RoutedEventArgs e)
        {
            label_suc.Content = "Модель добавлена!";
            BlockControl(ControlRadio.Model);
            ResetId();
            VoidTextBox();
        }

        private void Radio_Equip_Checked(object sender, RoutedEventArgs e)
        {
            label_suc.Content = "Комплектация добавлена!";
            BlockControl(ControlRadio.Equipment);
            ResetId();
            VoidTextBox();
        }

        private void Radio_Car_Checked(object sender, RoutedEventArgs e)
        {
            label_suc.Content = "Автомобиль добавлен!";
            BlockControl(ControlRadio.Car);
            VoidTextBox();
        }

        private void BlockControl(ControlRadio index)
        {
            if (((int)index) == 1)
            {
                VisibleTextBox(false, true, true, true);
                TextBox_manufac.IsEnabled = true;
            }
            if (((int)index) == 2)
            {
                VisibleTextBox(false, false, true, true);
                TextBox_manufac.IsEnabled = false;
                TextBox_model.IsEnabled = true;
            }
            if (((int)index) == 3)
            {
                VisibleTextBox(false, false, false, true);
                TextBox_model.IsEnabled = false;
                TextBox_manufac.IsEnabled = false;
                TextBox_model.IsEnabled = false;
                TextBox_nameEquip.IsEnabled = true;
                TextBox_drive.IsEnabled = true;
                TextBox_fuel.IsEnabled = true;

            }
            if (((int)index) == 4)
            {
                VisibleTextBox(false, false, false, false);
                TextBox_model.IsEnabled = false;
                TextBox_manufac.IsEnabled = false;
                TextBox_nameEquip.IsEnabled = false;
                TextBox_drive.IsEnabled = false;
                TextBox_fuel.IsEnabled = false;
                TextBox_color.IsEnabled = true;
                TextBox_price.IsEnabled = true;
                TextBox_vin.IsEnabled = true;
                DatePicker.IsEnabled = true;
            }
        }

        private void VisibleTextBox(bool manufac, bool model, bool eq, bool car)
        {
            if (manufac)
            {
                TextBox_manufac.Visibility = Visibility.Hidden;
                DataGridManufacturer.Visibility = Visibility.Hidden;
            }
            else
            {
                TextBox_manufac.Visibility = Visibility.Visible;
                DataGridManufacturer.Visibility = Visibility.Visible;
            }
            if (model)
            {
                TextBox_model.Visibility = Visibility.Hidden;
                DataGridModel.Visibility = Visibility.Hidden;
            }
            else
            {
                TextBox_model.Visibility = Visibility.Visible;
                DataGridModel.Visibility = Visibility.Visible;
            }
            if (eq)
            {
                TextBox_nameEquip.Visibility = Visibility.Hidden;
                TextBox_drive.Visibility = Visibility.Hidden;
                TextBox_fuel.Visibility = Visibility.Hidden;
                DataGridEquip.Visibility = Visibility.Hidden;
            }
            else
            {
                TextBox_nameEquip.Visibility = Visibility.Visible;
                TextBox_drive.Visibility = Visibility.Visible;
                TextBox_fuel.Visibility = Visibility.Visible;
                DataGridEquip.Visibility = Visibility.Visible;

            }
            if (car)
            {
                TextBox_vin.Visibility = Visibility.Hidden;
                TextBox_price.Visibility = Visibility.Hidden;
                TextBox_color.Visibility = Visibility.Hidden;
                TextBox_mileage.Visibility = Visibility.Hidden;
                DatePicker.Visibility = Visibility.Hidden;
            }
            else
            {
                TextBox_vin.Visibility = Visibility.Visible;
                TextBox_color.Visibility = Visibility.Visible;
                DatePicker.Visibility = Visibility.Visible;
                TextBox_mileage.Visibility = Visibility.Visible;
                TextBox_price.Visibility = Visibility.Visible;
            }
        }

        private void VoidTextBox()
        {
            TextBox_price.Text = string.Empty;
            TextBox_color.Text = string.Empty;
            TextBox_drive.Text = string.Empty;
            TextBox_fuel.Text = string.Empty;
            TextBox_manufac.Text = string.Empty;
            TextBox_model.Text = string.Empty;
            TextBox_nameEquip.Text = string.Empty;
            TextBox_vin.Text = string.Empty;
            TextBox_mileage.Text = string.Empty;
            DatePicker.Text = string.Empty;
        }

        private void button_Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataGridManufacturer.ItemsSource = null;
                DataGridModel.ItemsSource = null;
                DataGridEquip.ItemsSource = null;
                VoidTextBox();
                WindowLoaded();
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("");
            }

        }

        private void DataGridManufacturer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                using (var db = new CarShowroomContext())
                {
                    var manufac = from m in db.Manufacturers select new { _id = m.Id, _name = m.Carbrand };

                    foreach (var item in DataGridManufacturer.SelectedItems)
                    {
                        foreach (var items in manufac)
                        {
                            if (items.Equals(item))
                            {
                                TextBox_manufac.Text = items._name;
                                _idManufacturer = items._id;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Не удалось добавить производителя");
            }
        }

        private void DataGridModel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                using (var db = new CarShowroomContext())
                {
                    var model = from ml in db.Models select new { _id = ml.Id, _name = ml.NameModel };

                    foreach (var items in DataGridModel.SelectedItems)
                    {
                        foreach (var item in model)
                        {
                            if (items.Equals(item))
                            {
                                TextBox_model.Text = item._name;
                                _idModel = item._id;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Не удалось добавить модель");
            }
        }

        private void DataGridEquip_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                using (var db = new CarShowroomContext())
                {
                    var equip = from eq in db.Equipment
                                select new
                                {
                                    _id = eq.Id,
                                    _name = eq.NameEquipment,
                                    _drive = eq.TypeDrive,
                                    _fuel = eq.Fuel,
                                };

                    foreach (var items in DataGridEquip.SelectedItems)
                    {
                        foreach (var item in equip)
                        {
                            if (items.Equals(item))
                            {
                                TextBox_nameEquip.Text = item._name;
                                TextBox_drive.Text = item._drive;
                                TextBox_fuel.Text = item._fuel;
                                _idEquipment = item._id;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Не удалось добавить комплектацию");
            }
        }

        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Radio_Manufac.IsChecked == true)
                {
                    AddManufac();
                }
                else if (Radio_Model.IsChecked == true)
                {
                    AddModel();
                }
                else if (Radio_Equip.IsChecked == true)
                {
                    AddEquip();
                }
                else if (Radio_Car.IsChecked == true)
                {
                    AddCar();
                }
                else
                {
                    ErorrWindow.ShowS("Выберите элемент который хотите добавить");
                }

            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Не удалось добавить данные в БД");
            }
            finally
            {
                VoidTextBox();
                ResetId();
            }

        }


        private void AddManufac()
        {
            try
            {
                if (string.IsNullOrEmpty(TextBox_manufac.Text))
                {
                    ErorrWindow.ShowS("Поле с названием производителя должно быть заполненым");
                    return;
                }
                Manufacturer manufacturer = new Manufacturer();
                manufacturer = manufacturer.GetSoCarbrand(TextBox_manufac.Text);

                Manufacturer manufacturer1 = new Manufacturer();
                if (manufacturer != null)
                {
                    var question = MessageBox.Show("Такой производитель уже существует! \nДобавить нового?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (question == MessageBoxResult.Yes)
                    {
                        manufacturer1.Add(TextBox_manufac.Text);
                        eventslog.AddEvents(login, "Добавление", DateTime.Now, "Добавление производителя");
                        label_suc.Visibility = Visibility.Visible;
                        dispatcherTimer.Start();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    manufacturer1.Add(TextBox_manufac.Text);
                    eventslog.AddEvents(login, "Добавление", DateTime.Now, "Добавление производителя");
                    label_suc.Visibility = Visibility.Visible;
                    dispatcherTimer.Start();
                }
            }
            catch (Exception)
            {
                eventslog.AddEvents(login, "Ошибка", DateTime.Now, "ошибка добавления производителя");
            }
          
        }

        private void AddModel()
        {
            try
            {
                if (TextBox_manufac.Text == string.Empty)
                {
                    ErorrWindow.ShowS("Отсутствует производитель\nВыберите производителя двойным кликом по таблице с производителями");
                }
                else
                {
                    if (string.IsNullOrEmpty(TextBox_model.Text))
                    {
                        ErorrWindow.ShowS("Поле с названием модели должно быть заполненым");
                        return;
                    }
                    Model model = new Model();
                    model = model.GetSoModel(TextBox_model.Text);

                    Model model1 = new Model();
                    if (model != null)
                    {
                        var question = MessageBox.Show("Такая модель уже существует! \nДобавить новую?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (question == MessageBoxResult.Yes)
                        {
                            model1.Add(TextBox_model.Text, _idManufacturer);
                            eventslog.AddEvents(login, "Добавление", DateTime.Now, "Добавление модели");
                            label_suc.Visibility = Visibility.Visible;
                            dispatcherTimer.Start();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        model1.Add(TextBox_model.Text, _idManufacturer);
                        eventslog.AddEvents(login, "Добавление", DateTime.Now, "Добавление модели");
                        label_suc.Visibility = Visibility.Visible;
                        dispatcherTimer.Start();
                    }
                }
            }
            catch (Exception)
            {
                eventslog.AddEvents(login, "Ошибка", DateTime.Now, "Добавление модели");
            }
           
        }

        private void AddEquip()
        {
            try
            {
                if (TextBox_manufac.Text == string.Empty)
                {
                    ErorrWindow.ShowS("Отсутствует производитель\nВыберите производителя двойным кликом по таблице с производителями");
                }
                if (TextBox_model.Text == string.Empty)
                {
                    ErorrWindow.ShowS("Отсутствует модель\nВыберите модель двойным кликом по таблице с моделями");
                }
                else
                {
                    if (string.IsNullOrEmpty(TextBox_drive.Text) || string.IsNullOrEmpty(TextBox_nameEquip.Text) || string.IsNullOrEmpty(TextBox_price.Text) || string.IsNullOrEmpty(TextBox_fuel.Text))
                    {
                        ErorrWindow.ShowS("Выделенные поля должны быть заполнены");
                        return;
                    }
                    Equipment equip = new Equipment();
                    equip = equip.GetSoEquipment(TextBox_nameEquip.Text, TextBox_fuel.Text, TextBox_drive.Text, Convert.ToInt32(TextBox_price.Text));

                    Equipment equipment = new Equipment();
                    if (equip != null)
                    {
                        var question = MessageBox.Show("Такая комплектация уже существует! \nДобавить новую?", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                        if (question == MessageBoxResult.Yes)
                        {
                            equipment.Add(TextBox_nameEquip.Text, TextBox_drive.Text, TextBox_fuel.Text, _idModel);
                            eventslog.AddEvents(login, "Добавление", DateTime.Now, "Добавление комплектации");
                            label_suc.Visibility = Visibility.Visible;
                            dispatcherTimer.Start();
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        equipment.Add(TextBox_nameEquip.Text, TextBox_drive.Text, TextBox_fuel.Text, _idModel);
                        eventslog.AddEvents(login, "Добавление", DateTime.Now, "Добавление комплектации");
                        label_suc.Visibility = Visibility.Visible;
                        dispatcherTimer.Start();
                    }
                }

            }
            catch (Exception)
            {
                eventslog.AddEvents(login, "Ошибка", DateTime.Now, "Добавление комплектации");
            }
           
        }

        private void AddCar()
        {
            try
            {
                if (TextBox_manufac.Text == string.Empty)
                {
                    ErorrWindow.ShowS("Отсутствует производитель\nВыберите производителя двойным кликом по таблице с производителями");
                }
                if (TextBox_model.Text == string.Empty)
                {
                    ErorrWindow.ShowS("Отсутствует модель\nВыберите модель двойным кликом по таблице с моделями");
                }
                if (TextBox_nameEquip.Text == string.Empty)
                {
                    ErorrWindow.ShowS("Отсутствует комплектация\nВыберите комплектацию двойным кликом по таблице с комплектациями");
                }
                else
                {
                    if (TextBox_vin.Text == string.Empty)
                    {
                        ErorrWindow.ShowS("Поле с vin должн быть обязательно заполнен");
                        return;
                    }
                    if (DatePicker.Text == string.Empty)
                    {
                        ErorrWindow.ShowS("Введите корректную дату");
                        return;
                    }
                    if (TextBox_vin.Text.Length != 17)
                    {
                        ErorrWindow.ShowS("Vin должен содержать 17 символов");
                        return;
                    }
                    Car car = new Car();
                    car = car.Get(TextBox_vin.Text);
                    var date = Convert.ToDateTime(DatePicker.Text);
                    if (car != null)
                    {
                        ErorrWindow.ShowS("Автомобиль с таким vin уже существует");
                        return;
                    }
                    else
                    {
                        var color = (TextBox_color.Text == string.Empty) ? "неопределен" : TextBox_color.Text;
                        Car car1 = new Car();
                        string mileage = (TextBox_mileage.Text == string.Empty || TextBox_mileage.Text == "0") ? null : TextBox_mileage.Text;
                        car1.Add(color, TextBox_vin.Text, _idEquipment, null, date, mileage,Convert.ToInt32(TextBox_price.Text));
                        eventslog.AddEvents(login, "Добавление", DateTime.Now, "Добавление автомобиля");
                        label_suc.Visibility = Visibility.Visible;
                        dispatcherTimer.Start();
                    }
                }
            }
            catch (Exception)
            {
                eventslog.AddEvents(login, "Ошибка", DateTime.Now, "Добавление автомобиля");
            }
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new CarShowroomContext())
                {
                    var manufac = from m in db.Manufacturers select new { _id = m.Id, _name = m.Carbrand };

                    foreach (var item in DataGridManufacturer.SelectedItems)
                    {
                        foreach (var items in manufac)
                        {
                            if (items.Equals(item))
                            {
                                TextBox_manufac.Text = items._name;
                                _idManufacturer = items._id;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Не удалось добавить производителя");
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new CarShowroomContext())
                {
                    var model = from ml in db.Models select new { _id = ml.Id, _name = ml.NameModel };

                    foreach (var items in DataGridModel.SelectedItems)
                    {
                        foreach (var item in model)
                        {
                            if (items.Equals(item))
                            {
                                TextBox_model.Text = item._name;
                                _idModel = item._id;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Не удалось добавить модель");
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new CarShowroomContext())
                {
                    var equip = from eq in db.Equipment
                                select new
                                {
                                    _id = eq.Id,
                                    _name = eq.NameEquipment,
                                    _drive = eq.TypeDrive,
                                    _fuel = eq.Fuel,
                                };

                    foreach (var items in DataGridEquip.SelectedItems)
                    {
                        foreach (var item in equip)
                        {
                            if (items.Equals(item))
                            {
                                TextBox_nameEquip.Text = item._name;
                                TextBox_drive.Text = item._drive;
                                TextBox_fuel.Text = item._fuel;
                                _idEquipment = item._id;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Не удалось добавить комплектацию");
            }
        }

        private void TextBox_price_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBox_mileage_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}

