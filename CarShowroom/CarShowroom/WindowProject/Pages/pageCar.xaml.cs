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

namespace CarShowroomSystem.Window.Pages
{
    /// <summary>
    /// Логика взаимодействия для page_Car.xaml
    /// </summary>
    public partial class pageCar : Page
    {
       public ObservableCollection<SelCar> SelCars { get; set; }
        public pageCar()
        {
            InitializeComponent();
            WindowLoaded();
        }

        public void WindowLoaded()
        {
            using (var db = new CarShowroomContext())
            {
                var users = (from manufac in db.Manufacturers
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
                                _price = eq.Price + " рублей"
                            });
                //SelCars = new ObservableCollection<SelCar>(users.ToList());
                GridDatabase.ItemsSource = users.ToList();


                
            }
        }

        private void GridDatabase_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                using (var db = new CarShowroomContext())
                {
                    var users = (from manufac in db.Manufacturers
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
                                     _price = eq.Price + " рублей"
                                 });

                    string a = "";
                    foreach (var item in GridDatabase.SelectedItems)
                    {
                        foreach (var items in users)
                        {
                            if (item.Equals(items))
                            {
                                a = items._Vin;
                            }
                        }
                    }
                    MessageBox.Show(a);

                }
            }
            catch (System.Exception)
            {
                ErorrWindow.ShowS("Невозможно открыть страницу автомобиля");
            }
            

        }
    }
}