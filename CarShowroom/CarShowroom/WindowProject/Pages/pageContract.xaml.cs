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
using CarShowroomSystem.Window;
using AddWord;
using CarShowroom.WindowProject.Pages.WindowForElement;
using CarShowroom.ClassesManagementDatabase;
using System.Diagnostics;

namespace CarShowroomSystem.WindowProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для pagePayment.xaml
    /// </summary>
    public partial class pageContract : Page
    {
        private List<ProductCar> cars;
        private List<ProductCar> acess;
        private bool _isChanged = false;
        private string login;
        private int _countCar;
        Eventslog eventslog = new Eventslog();
        public pageContract(string logi)
        {
            try
            {
                InitializeComponent();
                WindowLoaded();
                login = logi;
                cars = new List<ProductCar>();
                acess = new List<ProductCar>();
                comboBoxPay.SelectedIndex = 0;
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
                var users = from manufac in db.Manufacturers
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
                                _color = car.Color,
                                _price = car.Price,
                            };
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
                TextBoxStavka.Text = string.Empty;
                TextBoxMonthPay.Text = string.Empty;
                _isChanged = false;
            }
            if (comboBoxPay.SelectedIndex == 1) //Частичный расчет и кредит
            {
                comboBoxMonth.IsEnabled = true;
                TextBoxStavka.IsEnabled = true;
                button_Credit.IsEnabled = true;
                _isChanged = false;
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
                foreach (var item in acess)
                {
                    Summ += item.Price;
                }
                TextBlockPrice.Text = Summ.ToString();
                if (comboBoxPay.SelectedIndex == 0)
                {
                    TextBoxInitialPay.Text = Summ.ToString();
                }
                else
                {
                    TextBoxInitialPay.Text = string.Empty;
                }
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Невозможно расчитать стоимость");
            }
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
                                where car.ContractId == null
                                select new
                                {
                                    _Vin = car.Vin,
                                    _manufacturer = manufac.Carbrand,
                                    _model = model.NameModel,
                                    _equipment = eq.NameEquipment,
                                    _color = car.Color,
                                    _price = car.Price
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
                                _countCar++;
                            }
                        }
                    }

                    foreach (var item in listViewProduct.Items)
                    {
                        var a = (ProductCar)item;
                        if (productCar.Vin == a.Vin)
                        {
                            throw new ArgumentException();
                        }
                    }

                    cars.Add(productCar);
                    listViewProduct.Items.Add(productCar);

                    var carse = new Car();
                    carse = carse.Get(productCar.Vin);

                    var query = from typ in db.TypeAccessories
                                join ac in db.Accessories on typ.Id equals ac.TypeAccessoryId
                                where ac.CarId == carse.Id
                                select new { _name = typ.NameTypeAccessory + " " + ac.NameAccessory, _price = ac.Price };

                    foreach (var item in query)
                    {
                        ProductCar product = new ProductCar();
                        product.ManufacModelEquip = item._name;
                        product.Price = item._price;
                        listViewProduct.Items.Add(product);
                        cars.Add(product);
                    }
                }
            }
            catch (ArgumentException)
            {
                ErorrWindow.ShowS("Невозможно добавить этот автомобиль так как он уже находиться в чеке");
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Не удалось добавить автомобиль в чек");
            }


        }

        private void button_Remove_Click(object sender, RoutedEventArgs e)
        {
            ClearLists();
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
                                where car.ContractId == null
                                select new
                                {
                                    _Vin = car.Vin,
                                    _manufacturer = manufac.Carbrand,
                                    _model = model.NameModel,
                                    _equipment = eq.NameEquipment,
                                    _color = car.Color,
                                    _price = car.Price,
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

                        TextBoxVIN.Text = string.Empty;
                        TextBoxManufac.Text = string.Empty;
                        TextBoxModel.Text = string.Empty;
                        TextBoxEquipment.Text = string.Empty;
                        TextBoxColor.Text = string.Empty;
                    }
                }
            }
            catch (Exception)
            {
                DataGridSelCar.ItemsSource = null;
                Done.ShowS("Ничего не найдено");
            }

        }

        private void button_Contract_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((comboBoxPay.SelectedIndex == 1) && (TextBoxMonthPay.Text == ""))
                {
                    ErorrWindow.ShowS("Расчитайте ежемесячный платеж");
                    return;
                }
                if ((comboBoxPay.SelectedIndex == 0) && (TextBoxInitialPay.Text != TextBlockPrice.Text))
                {
                    ErorrWindow.ShowS("Начальный взнос должен соответствовать стоимости товаров");
                    return;
                }
                if (comboBoxPay.SelectedIndex == 0)
                {

                }
                else if(!_isChanged)
                {
                    ErorrWindow.ShowS("Вы изменяли поля\n Расчитайте платеж заново");
                    return;
                }
                Customer customer = new Customer();
                Employee employee = new Employee();
                Contract contract = new Contract();
                Car car = new Car();

                string FIO = (TextBoxFIO.Text != "") ? TextBoxFIO.Text : string.Empty;
                string Phone = "+7" + ((TextBoxPhoneNumber.Text != "") ? TextBoxPhoneNumber.Text : string.Empty);

                int? indexOfCustomer = -1;
                if (!string.IsNullOrEmpty(FIO) && Phone != "+7")
                {
                    indexOfCustomer = customer.Add(FIO, Phone).Id;
                }

                int indexOfEmploee = employee.GetEmployee(login, null).Id;
                employee = employee.GetEmployee(login, null);
                indexOfCustomer = (indexOfCustomer == -1) ? null : indexOfCustomer;
                string paymethod = (comboBoxPay.SelectedIndex == 0) ? "Полный расчет" : "Частичный расчет и кредит";
                Contract Contracts;
                if (paymethod == "Частичный расчет и кредит")
                {
                    int CountMonth = (comboBoxMonth.SelectedIndex + 1) * 6;

                    Contracts = contract.Add(indexOfCustomer, indexOfEmploee, DateTime.Now, paymethod, Convert.ToDouble(TextBoxInitialPay.Text),
                            Convert.ToDouble(TextBoxMonthPay.Text), CountMonth);
                    eventslog.AddEvents(login, "Информация", DateTime.Now, "Составление контракта №" + Convert.ToString(Contracts.Id));
                }
                else
                {
                    Contracts = contract.Add(indexOfCustomer, indexOfEmploee, DateTime.Now, paymethod, Convert.ToDouble(TextBoxInitialPay.Text),
                            null, null);
                    eventslog.AddEvents(login, "Информация", DateTime.Now, "Составление контракта №" + Convert.ToString(Contracts.Id));
                }

                string WordContractCar = string.Empty;
                string WordContractPrice = string.Empty;
                string WordContractVin = string.Empty;
                foreach (var item in cars)
                {
                    car.Edit(item.Vin, Contracts.Id);
                    WordContractVin += item.Vin + " ";
                    WordContractCar += item.ManufacModelEquip + Convert.ToChar(94) + Convert.ToChar(112);
                    WordContractPrice += Convert.ToString(item.Price) + " рублей" + Convert.ToChar(94) + Convert.ToChar(112);
                }
                string monthpay = (Convert.ToString(Contracts.MonthlyPay) == string.Empty) ? "--------------" : Convert.ToString(Contracts.MonthlyPay) + " Месяцев";
                string countMonth = (Convert.ToString(Contracts.CountMonthInstallment) == string.Empty) ? "---------" : Convert.ToString(Contracts.CountMonthInstallment) + " рублей";
                FIO = (FIO == string.Empty) ? "_____________________________" : FIO;
                ProcessingWord Conword = new ProcessingWord("Contract.docx");
                var items = new Dictionary<string, string>
                    {
                        {"<date>",       Contracts.DateSale.ToString("«dd» MMMM yyyy г.") },
                        {"<Initial>",    Convert.ToString(Contracts.InitialDonatMoney)    },
                        {"<Type>",       Convert.ToString(Contracts.PayMethod)            },
                        {"<countMonth>", countMonth                                       },
                        {"<MonthPay>",   monthpay                                         },
                        {"<Cars>",       WordContractCar                                  },
                        {"<Price>",      WordContractPrice                                },
                        {"<Count>",      Convert.ToString(_countCar)                      },
                        {"<Employee>",   employee.Fio                                     },
                        {"<Customer>",   FIO                                              },
                        {"<Position>",   employee.Position                                },
                        {"<IdContrac>",  Convert.ToString(Contracts.Id)                   },
                        {"<Summ>",       TextBlockPrice.Text                              },
                        
                    };

                Conword.Process(items, @"Контракты", 1);
                eventslog.AddEvents(login, "Изменение", DateTime.Now, "Добавление товаров в контракт" + WordContractCar +" Vin коды автомобилей"+ WordContractVin);
                if (Conword.IsSuccsesfull == true)
                {
                    Done.ShowS("Контракт сформирован");
                }
                updateDataGrid();
                ClearLists();
                ClearBox();
                TextBoxInitialPay.Text = string.Empty;
                TextBlockPrice.Text = string.Empty;
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Не получилось сформировать контракт");
                eventslog.AddEvents(login, "Ошибка", DateTime.Now, "Добавление товаров в контракт");
            }
        }
        private void ClearLists()
        {
            listViewProduct.Items.Clear();
            cars.Clear();
            acess.Clear();
            _countCar = 0;
        }
        private void ClearBox()
        {
            TextBlockPrice.Text = string.Empty;
            TextBoxMonthPay.Text = string.Empty;
            TextBoxInitialPay.Text = string.Empty;
        }

        private void updateDataGrid()
        {
            using (var db = new CarShowroomContext())
            {
                var users = from manufac in db.Manufacturers
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
                                _color = car.Color,
                                _price = car.Price,
                            };

                DataGridSelCar.ItemsSource = null;
                DataGridSelCar.ItemsSource = users.ToList();
            }
        }


        private void button_Credit_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (TextBlockPrice.Text == "")
                {
                    ErorrWindow.ShowS("Расчитайте стоимость");
                    return;
                }
                int CountDay = (comboBoxMonth.SelectedIndex + 1) * 6;
                double stavka = Convert.ToDouble(TextBoxStavka.Text) / 100 / 12;


                double initialpay;
                if (TextBoxInitialPay.Text == "")
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

                if (monthpay <= 0) throw new ArgumentException();
                TextBoxMonthPay.Text = Convert.ToString(Math.Round(monthpay, 0));
                _isChanged = true;
            }
            catch (ArgumentException)
            {
                ErorrWindow.ShowS("Неправильно заданы параметры");
            }
            catch (Exception)
            {

                ErorrWindow.ShowS("Не удалось посчитать ежемесячный платеж");
            }


        }

        private void TextBoxInitialPay_TextChanged(object sender, TextChangedEventArgs e)
        {
            _isChanged = false;
        }

        private void TextBoxStavka_TextChanged(object sender, TextChangedEventArgs e)
        {
            _isChanged = false;
        }

        private void comboBoxMonth_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _isChanged = false;
        }

        private void button_Update_Click(object sender, RoutedEventArgs e)
        {
            updateDataGrid();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
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
                                where car.ContractId == null
                                select new
                                {
                                    _Vin = car.Vin,
                                    _manufacturer = manufac.Carbrand,
                                    _model = model.NameModel,
                                    _equipment = eq.NameEquipment,
                                    _color = car.Color,
                                    _price = car.Price
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
                                _countCar++;
                            }
                        }
                    }

                    foreach (var item in listViewProduct.Items)
                    {
                        var a = (ProductCar)item;
                        if (productCar.Vin == a.Vin)
                        {
                            throw new ArgumentException();
                        }
                    }

                    cars.Add(productCar);
                    listViewProduct.Items.Add(productCar);

                    var carse = new Car();
                    carse = carse.Get(productCar.Vin);

                    var query = from typ in db.TypeAccessories
                                join ac in db.Accessories on typ.Id equals ac.TypeAccessoryId
                                where ac.CarId == carse.Id
                                select new { _name = typ.NameTypeAccessory + " " + ac.NameAccessory, _price = ac.Price };

                    foreach (var item in query)
                    {
                        ProductCar product = new ProductCar();
                        product.ManufacModelEquip = item._name;
                        product.Price = item._price;
                        listViewProduct.Items.Add(product);
                        cars.Add(product);
                    }

                }
            }
            catch (ArgumentException)
            {
                ErorrWindow.ShowS("Невозможно добавить этот автомобиль так как он уже находиться в чеке");
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Не удалось добавить автомобиль в чек");
            }

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            using (var db = new CarShowroomContext())
            {
                var users = from manufac in db.Manufacturers
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
                                _color = car.Color,
                                _price = car.Price
                            };

                string vin = string.Empty;
                foreach (var item in DataGridSelCar.SelectedItems)
                {
                    foreach (var items in users)
                    {
                        if (item.Equals(items))
                        {
                            vin = items._Vin;
                        }
                    }
                }
                CarInformation carInformation = new CarInformation(vin,login);
                carInformation.Show();
            }
        }
    }
}
