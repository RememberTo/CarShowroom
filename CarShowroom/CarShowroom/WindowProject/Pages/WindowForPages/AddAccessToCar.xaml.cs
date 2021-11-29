using CarShowroom.ClassesManagementDatabase;
using CarShowroom.SelectedClass;
using CarShowroomSystem.Window;
using CarShowroomSystem.WindowProject;
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
using System.Windows.Threading;

namespace CarShowroom.WindowProject.Pages.WindowForPages
{
    /// <summary>
    /// Логика взаимодействия для AddAccessToCar.xaml
    /// </summary>
    public partial class AddAccessToCar : Window
    {
        private DispatcherTimer dispatcherTimer;
        private List<int> idAcess;
        private int _idCar = -1;
        private string login;
        Eventslog eventslog = new Eventslog();
        public AddAccessToCar(string logi)
        {
            idAcess = new List<int>();
            InitializeComponent();
            WindowLoaded();
            login = logi;
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
                var Cars = from manufac in db.Manufacturers
                           join model in db.Models on manufac.Id equals model.ManufacturerId
                           join eq in db.Equipment on model.Id equals eq.ModelId
                           join car in db.Cars on eq.Id equals car.EquipmentId
                           where car.ContractId == null
                           select new
                           {
                               _Id = car.Id,
                               _Vin = car.Vin,
                               _manufacturer = manufac.Carbrand,
                               _model = model.NameModel,
                               _equipment = eq.NameEquipment,
                               _date = car.ReleaseDate,
                               _color = car.Color,
                               _price = car.Price,
                           };



                var Acess = from typ in db.TypeAccessories
                            join acces in db.Accessories on typ.Id equals acces.TypeAccessoryId
                            where acces.CarId == null
                            select new
                            {
                                _Id = acces.Id,
                                _type = typ.NameTypeAccessory,
                                _name = acces.NameAccessory,
                                _price = acces.Price,
                                _opis = acces.Description,
                            };

                DataGridCar.ItemsSource = Cars.ToList();
                DataGridAccess.ItemsSource = Acess.ToList();

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

        private void DataGridAccess_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                using (var db = new CarShowroomContext())
                {
                    var Acess = from typ in db.TypeAccessories
                                join acces in db.Accessories on typ.Id equals acces.TypeAccessoryId
                                where acces.CarId == null
                                select new
                                {
                                    _Id = acces.Id,
                                    _type = typ.NameTypeAccessory,
                                    _name = acces.NameAccessory,
                                    _price = acces.Price,
                                    _opis = acces.Description,
                                };

                    foreach (var item in DataGridAccess.SelectedItems)
                    {
                        foreach (var items in Acess)
                        {
                            if (items.Equals(item))
                            {
                                AddingAccessToCar toCar = new AddingAccessToCar
                                {
                                    _Id = items._Id,
                                    _name = items._name,
                                    _opis = items._opis,
                                    _price = items._price,
                                    _type = items._type
                                };
                                idAcess.Add(toCar._Id);
                                listViewAcess.Items.Add(toCar);
                            }

                        }
                    }

                    
                }
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("При добавлении аксессуара");
            }
        }

        private void DataGridCar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                using (var db = new CarShowroomContext())
                {
                    var Cars = from manufac in db.Manufacturers
                               join model in db.Models on manufac.Id equals model.ManufacturerId
                               join eq in db.Equipment on model.Id equals eq.ModelId
                               join car in db.Cars on eq.Id equals car.EquipmentId
                               where car.ContractId == null
                               select new
                               {
                                   _Id = car.Id,
                                   _Vin = car.Vin,
                                   _manufacturer = manufac.Carbrand,
                                   _model = model.NameModel,
                                   _equipment = eq.NameEquipment,
                                   _date = car.ReleaseDate,
                                   _color = car.Color,
                                   _price = car.Price,
                               };

                    foreach (var item in DataGridCar.SelectedItems)
                    {
                        foreach (var items in Cars)
                        {
                            if (items.Equals(item))
                            {
                                TextBlock_Car.Content = items._manufacturer + " " + items._model + " " + items._equipment;
                                _idCar = items._Id;
                            }

                        }
                    }
                }
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("При добавлении автомобиля");
            }
        }

        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_idCar == -1)
                {
                    ErorrWindow.ShowS("Выберите автомобиль двойным кликом в таблице с автомобилями");
                    return;
                }
                if (idAcess.Count == 0)
                {
                    ErorrWindow.ShowS("Выберите аксессуары двойным кликом в таблице с аксессуарами");
                    return;
                }

                Accessory accessory = new Accessory();

                foreach (var item in idAcess)
                {
                    accessory.Edit(_idCar,item);
                }
                WindowLoaded();
                listViewAcess.Items.Clear();
                idAcess.Clear();
                label_suc.Visibility = Visibility.Visible;
                dispatcherTimer.Start();

                eventslog.AddEvents(login, "Изменение", DateTime.Now, "Добавление аксессуара к автомобилю");
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Не удалось изменить данные в БД");
                eventslog.AddEvents(login, "Ошибка", DateTime.Now, "Добавление аксессуара к автомобилю");
            }
        }

        private void button_Delete_Click(object sender, RoutedEventArgs e)
        {
            listViewAcess.Items.Clear();
            idAcess.Clear();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new CarShowroomContext())
                {
                    var Cars = from manufac in db.Manufacturers
                               join model in db.Models on manufac.Id equals model.ManufacturerId
                               join eq in db.Equipment on model.Id equals eq.ModelId
                               join car in db.Cars on eq.Id equals car.EquipmentId
                               where car.ContractId == null
                               select new
                               {
                                   _Id = car.Id,
                                   _Vin = car.Vin,
                                   _manufacturer = manufac.Carbrand,
                                   _model = model.NameModel,
                                   _equipment = eq.NameEquipment,
                                   _date = car.ReleaseDate,
                                   _color = car.Color,
                                   _price = car.Price,
                               };

                    foreach (var item in DataGridCar.SelectedItems)
                    {
                        foreach (var items in Cars)
                        {
                            if (items.Equals(item))
                            {
                                TextBlock_Car.Content = items._manufacturer + " " + items._model + " " + items._equipment;
                                _idCar = items._Id;
                            }

                        }
                    }
                }
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("При добавлении автомобиля");
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new CarShowroomContext())
                {
                    var Acess = from typ in db.TypeAccessories
                                join acces in db.Accessories on typ.Id equals acces.TypeAccessoryId
                                where acces.CarId == null
                                select new
                                {
                                    _Id = acces.Id,
                                    _type = typ.NameTypeAccessory,
                                    _name = acces.NameAccessory,
                                    _price = acces.Price,
                                    _opis = acces.Description,
                                };

                    foreach (var item in DataGridAccess.SelectedItems)
                    {
                        foreach (var items in Acess)
                        {
                            if (items.Equals(item))
                            {
                                AddingAccessToCar toCar = new AddingAccessToCar
                                {
                                    _Id = items._Id,
                                    _name = items._name,
                                    _opis = items._opis,
                                    _price = items._price,
                                    _type = items._type
                                };
                                idAcess.Add(toCar._Id);
                                listViewAcess.Items.Add(toCar);
                            }

                        }
                    }


                }
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("При добавлении аксессуара");
            }
        }
    }
}
