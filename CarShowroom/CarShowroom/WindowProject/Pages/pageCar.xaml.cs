using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Linq;
using CarShowroom;
using CarShowroom.SelectedClass;
using System.ComponentModel;
using System.Collections.ObjectModel;
using CarShowroomSystem.WindowProject;
using System;
using CarShowroom.WindowProject;
using CarShowroom.WindowProject.Pages.WindowForElement;
using CarShowroom.WindowProject.Pages.WindowForPages;
using CarShowroom.ClassesManagementDatabase;

namespace CarShowroomSystem.Window.Pages
{
    /// <summary>
    /// Логика взаимодействия для page_Car.xaml
    /// </summary>
    public partial class pageCar : Page
    {
        public ObservableCollection<SelCar> SelCars { get; set; }
        Eventslog eventslog = new Eventslog();
        private string login;
        public pageCar(string logi)
        {
            try
            {
                InitializeComponent();
                WindowLoaded();
                login = logi;
            }
            catch (Exception)
            {

                ErorrWindow.ShowS("инициализации");
            }

        }

        public void WindowLoaded()
        {
            using (var db = new CarShowroomContext())
            {
                var users = (from manufac in db.Manufacturers
                             join model in db.Models on manufac.Id equals model.ManufacturerId
                             join eq in db.Equipment on model.Id equals eq.ModelId
                             join car in db.Cars on eq.Id equals car.EquipmentId
                             where car.ContractId == null
                             select new
                             {
                                 _Vin = car.Vin,
                                 _manufacturer = manufac.Carbrand,
                                 _model = model.NameModel,
                                 _equipment = eq.NameEquipment,
                                 _releaseDate = car.ReleaseDate.Day + "." + car.ReleaseDate.Month + "." + car.ReleaseDate.Year,
                                 _fuel = eq.Fuel,
                                 _drive = eq.TypeDrive,
                                 _color = car.Color,
                                 _price = car.Price + " рублей"
                             });

                GridDatabase.ItemsSource = users.ToList();
            }
        }

        private void GetInformarionCar()
        {
            try
            {
                using (var db = new CarShowroomContext())
                {
                    var users = from manufac in db.Manufacturers
                                join model in db.Models on manufac.Id equals model.ManufacturerId
                                join eq in db.Equipment on model.Id equals eq.ModelId
                                join car in db.Cars on eq.Id equals car.EquipmentId
                                select new
                                {
                                    _Vin = car.Vin,
                                    _manufacturer = manufac.Carbrand,
                                    _model = model.NameModel,
                                    _equipment = eq.NameEquipment,
                                    _releaseDate = car.ReleaseDate.Day + "." + car.ReleaseDate.Month + "." + car.ReleaseDate.Year,
                                    _fuel = eq.Fuel,
                                    _drive = eq.TypeDrive,
                                    _color = car.Color,
                                    _price = car.Price + " рублей"
                                };

                    string vin = string.Empty;
                    foreach (var item in GridDatabase.SelectedItems)
                    {
                        foreach (var items in users)
                        {
                            if (item.Equals(items))
                            {
                                vin = items._Vin;
                            }
                        }
                    }
                    CarInformation Wincar = new CarInformation(vin,login);
                    Wincar.Show();

                }
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Невозможно открыть страницу автомобиля\nПопробуйте обновить таблицу");
            }
        }

        private void GridDatabase_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            GetInformarionCar();
        }

        private void button_Search_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                using (var db = new CarShowroomContext())
                {
                    var users = (from manufac in db.Manufacturers
                                 join model in db.Models on manufac.Id equals model.ManufacturerId
                                 join eq in db.Equipment on model.Id equals eq.ModelId
                                 join car in db.Cars on eq.Id equals car.EquipmentId
                                 where car.ContractId == null
                                 select new
                                 {
                                     _Vin = car.Vin,
                                     _manufacturer = manufac.Carbrand,
                                     _model = model.NameModel,
                                     _equipment = eq.NameEquipment,
                                     _releaseDate = car.ReleaseDate.Day + "." + car.ReleaseDate.Month + "." + car.ReleaseDate.Year,
                                     _fuel = eq.Fuel,
                                     _drive = eq.TypeDrive,
                                     _color = car.Color,
                                     _price = car.Price + " рублей"
                                 });

                    GridDatabase.ItemsSource = users.ToList();

                    if (string.IsNullOrEmpty(TextBoxVIN.Text) && string.IsNullOrEmpty(TextBoxManufac.Text)
                           && string.IsNullOrEmpty(TextBoxModel.Text) && string.IsNullOrEmpty(TextBoxEquipment.Text))
                    {
                        GridDatabase.ItemsSource = null;
                        GridDatabase.ItemsSource = users.ToList();
                        TextBoxVIN.Text = string.Empty;
                        TextBoxManufac.Text = string.Empty;
                        TextBoxModel.Text = string.Empty;
                        TextBoxEquipment.Text = string.Empty;
                    }
                    else
                    {
                        var query = users.Where(q => q._Vin == TextBoxVIN.Text || q._manufacturer == TextBoxManufac.Text ||
                              q._model == TextBoxModel.Text || q._equipment == TextBoxEquipment.Text);

                        if (query == null) throw new Exception();
                        GridDatabase.ItemsSource = query.ToList();
                        TextBoxVIN.Text = string.Empty;
                        TextBoxManufac.Text = string.Empty;
                        TextBoxModel.Text = string.Empty;
                        TextBoxEquipment.Text = string.Empty;
                    }
                }
            }
            catch (Exception)
            {
                GridDatabase.ItemsSource = null;
                Done.ShowS("Ничего не найдено");
                TextBoxVIN.Text = string.Empty;
                TextBoxManufac.Text = string.Empty;
                TextBoxModel.Text = string.Empty;
                TextBoxEquipment.Text = string.Empty;
            }
        }

        private void Update()
        {
            using (var db = new CarShowroomContext())
            {
                var users = (from manufac in db.Manufacturers
                             join model in db.Models on manufac.Id equals model.ManufacturerId
                             join eq in db.Equipment on model.Id equals eq.ModelId
                             join car in db.Cars on eq.Id equals car.EquipmentId
                             where car.ContractId == null
                             select new
                             {
                                 _Vin = car.Vin,
                                 _manufacturer = manufac.Carbrand,
                                 _model = model.NameModel,
                                 _equipment = eq.NameEquipment,
                                 _releaseDate = car.ReleaseDate.Day + "." + car.ReleaseDate.Month + "." + car.ReleaseDate.Year,
                                 _fuel = eq.Fuel,
                                 _drive = eq.TypeDrive,
                                 _color = car.Color,
                                 _price = car.Price + " рублей"
                             });

                GridDatabase.ItemsSource = users.ToList();
            }
        }
        private void button_Update_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            CarAdd add = new CarAdd(login);
            add.Show();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new CarShowroomContext())
                {
                    var users = from manufac in db.Manufacturers
                                join model in db.Models on manufac.Id equals model.ManufacturerId
                                join eq in db.Equipment on model.Id equals eq.ModelId
                                join car in db.Cars on eq.Id equals car.EquipmentId
                                select new
                                {
                                    _Vin = car.Vin,
                                    _manufacturer = manufac.Carbrand,
                                    _model = model.NameModel,
                                    _equipment = eq.NameEquipment,
                                    _releaseDate = car.ReleaseDate.Day + "." + car.ReleaseDate.Month + "." + car.ReleaseDate.Year,
                                    _fuel = eq.Fuel,
                                    _drive = eq.TypeDrive,
                                    _color = car.Color,
                                    _price = car.Price + " рублей"
                                };

                    string vin = string.Empty;
                    foreach (var item in GridDatabase.SelectedItems)
                    {
                        foreach (var items in users)
                        {
                            if (item.Equals(items))
                            {
                                vin = items._Vin;
                            }
                        }
                    }
                    var question = MessageBox.Show("Вы уверены что хотите удалить автомобиль?\nВосстановить автомобиль не получиться", "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (question == MessageBoxResult.Yes)
                    {
                        Car car1 = new Car();
                        car1 = car1.Delete(vin);
                        eventslog.AddEvents(login, "Удаление", DateTime.Now, "удаление автомобиля vin: " + car1.Vin + "Информация о автомобиле: Цвет " + car1.Color + " Дата выпуска " + car1.ReleaseDate);
                    }
                    else
                    {
                        return;
                    }
                    
                    
                    Update();
                }
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("");
            }
            
            }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            GetInformarionCar();
        }
    }
}