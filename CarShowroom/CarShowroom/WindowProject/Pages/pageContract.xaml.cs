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
using System.Linq;
using CarShowroom;
using CarShowroom.SelectedClass;
using System.Text.RegularExpressions;
using System.Threading;
using CarShowroom.WindowProject;

namespace CarShowroomSystem.WindowProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для pagePayment.xaml
    /// </summary>
    public partial class pageContract : Page
    {
        private List<ProductCar> cars;
        public pageContract()
        {
            InitializeComponent();
            WindowLoaded();
            cars = new List<ProductCar>();
        }
        public void WindowLoaded()
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
                                _color = car.Color,
                                _price = eq.Price,
                            };
                //SelCars = new ObservableCollection<SelCar>(users.ToList());
                DataGridSelCar.ItemsSource = users.ToList();



            }
        }

        private void comboBoxPay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxPay.SelectedIndex == 0) //Полный расчет
            {
                comboBoxMonth.IsEnabled = false;
                TextBoxStavka.IsEnabled = false;
                button_Credit.IsEnabled = false;
                TextBoxStavka.Text = "";
            }
            if (comboBoxPay.SelectedIndex == 1) //Частичный расчет и кредит
            {
                comboBoxMonth.IsEnabled = true;
                TextBoxStavka.IsEnabled = true;
                button_Credit.IsEnabled = true;

            }
            if (comboBoxPay.SelectedIndex == 2) //Кредит
            {

            }
        }

        private void button_getPrice_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int Summ = 0;
                foreach (var item in cars)
                {
                    Summ += item.Price;
                }
                TextBlockPrice.Text = Summ.ToString();
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Невозможно расчитать стоимость");
            }
        }

        private void button_AddAccessory_Click(object sender, RoutedEventArgs e)
        {
            DataGridSelCar.ItemsSource = null;
            // List<Product> prod = new List<Product> 
            // { 
            //     new Product { Item = "BMW X5 turbo", Price = 1000000 },
            //     new Product { Item = "BMW X6 turbo", Price = 1002312000 },
            //     new Product { Item = "BMW X3 turbo", Price = 100241200 },
            //     new Product { Item = "BMW X5 turbo", Price = 1000000 },
            //     new Product { Item = "BMW X6 turbo", Price = 1002312000 },
            //     new Product { Item = "BMW X3 turbo", Price = 100241200 },
            //     new Product { Item = "BMW X5 turbo", Price = 1000000 },
            //     new Product { Item = "BMW X6 turbo", Price = 1002312000 },
            //     new Product { Item = "BMW X3 turbo", Price = 100241200 },
            //     new Product { Item = "BMW dasdasurbo", Price = 1000000 },
            //     new Product { Item = "BMW X6 turbo", Price = 1002312000 },
            //     new Product { Item = "BMWdasdurbo", Price = 100241200 },
            //     new Product { Item = "BMW X5 turbo", Price = 1000000 },
            //     new Product { Item = "BMW X6 turbo", Price = 1002312000 },
            //     new Product { Item = "BMW X3 turbo", Price = 100241200 },
            //     new Product { Item = "BMsda turbo", Price = 1000000 },
            //     new Product { Item = "BMW X6 turbo", Price = 1002312000 },
            //     new Product { Item = "BMW X3 turbo", Price = 100241200 },
            //     new Product { Item = "BMWsadturbo", Price = 1002312000 },
            //     new Product { Item = "BMsadsaurbo", Price = 100241200 },
            //     new Product { Item = "BMW X5 turbo", Price = 1000000 },
            //     new Product { Item = "BMsarbo", Price = 1002312000 },
            //     new Product { Item = "BMW X3 turbo", Price = 100241200 }
            // };
            // //Product product = new Product {Item = users. };
            //// prod.Add();
            // listViewProduct.ItemsSource = prod;
        }

        private void TextBoxStavka_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBoxInitialPay_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void DataGridSelCar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ProductCar productCar = new ProductCar();


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
                                    _color = car.Color,
                                    _price = eq.Price
                                };

                    foreach (var item in DataGridSelCar.SelectedItems)
                    {
                        foreach (var items in users)
                        {
                            if (item.Equals(items))
                            {
                                productCar.ManufacModelEquip = items._manufacturer + " " + items._model + " " + items._equipment;
                                productCar.Price = items._price;
                                productCar.Vin = items._Vin;
                            }
                        }
                    }
                    foreach (var item in listViewProduct.Items)
                    {
                        if (productCar.Equals(item))
                        {
                            throw new ArgumentException();
                        }
                    }

                    listViewProduct.Items.Add(productCar);
                    cars.Add(productCar);
                }
            }
            catch (ArgumentException)
            {
                ErorrWindow.ShowS("Невозможно добавить этот автомобиль");
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Невозможно открыть страницу автомобиля");
            }


        }

        private void button_Remove_Click(object sender, RoutedEventArgs e)
        {
            listViewProduct.Items.Clear();
            cars.Clear();
        }

        private void button_Search_Click(object sender, RoutedEventArgs e)
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
                                    _color = car.Color,
                                    _price = eq.Price,
                                };
                    if (string.IsNullOrEmpty(TextBoxVIN.Text) && string.IsNullOrEmpty(TextBoxManufac.Text)
                       && string.IsNullOrEmpty(TextBoxModel.Text) && string.IsNullOrEmpty(TextBoxEquipment.Text)
                       && string.IsNullOrEmpty(TextBoxColor.Text))
                    {
                        DataGridSelCar.ItemsSource = null;
                        DataGridSelCar.ItemsSource = users.ToList();
                    }
                    else
                    {
                        var query = users.Where(q => q._Vin == TextBoxVIN.Text || q._manufacturer == TextBoxManufac.Text ||
                                    q._model == TextBoxModel.Text || q._equipment == TextBoxEquipment.Text
                                    || q._color == TextBoxColor.Text);

                        if (query == null) throw new Exception();

                        DataGridSelCar.ItemsSource = null;

                        DataGridSelCar.ItemsSource = query.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                DataGridSelCar.ItemsSource = null;
                Done.ShowS("Ничего не найдено");
            }

        }

        private void button_Contract_Click(object sender, RoutedEventArgs e)
        {
            //првоерить метод кредита если выбран полный рассчет то initalpay должен соответствовать TextBlockPrice
        }

        private void button_Credit_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if(TextBlockPrice.Text == "")
                {
                    ErorrWindow.ShowS("Расчитайте стоимость");
                    return;
                }
                int CountDay = (comboBoxMonth.SelectedIndex + 1) * 6;
                double stavka = Convert.ToDouble(TextBoxStavka.Text) / 100 / 12;

                double initialpay;
                if(TextBoxInitialPay.Text == "")
                {
                    initialpay = 0;
                }
                else
                {
                    initialpay = Convert.ToDouble(TextBoxInitialPay.Text);
                }
                double SummForCredit = Convert.ToDouble(TextBlockPrice.Text) - initialpay;

                double value = 1 + stavka;
                double monthpay = SummForCredit * (stavka + (stavka / (Math.Pow(value, CountDay) - 1)));

                TextBoxMonthPay.Text = Convert.ToString(Math.Round(monthpay,0));
            }
            catch (Exception)
            {

                ErorrWindow.ShowS("Не удалось посчитать ежемесячный платеж");
            }


        }
    }
}
