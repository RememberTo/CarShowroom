using AddWord;
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
using CarShowroom.SelectedClass;
using CarShowroom.WindowProject;
using System.Text.RegularExpressions;
using System.Diagnostics;
using CarShowroomSystem.Window;
using CarShowroom.ClassesManagementDatabase;
using System.IO;

namespace CarShowroomSystem.WindowProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для pageBidCar.xaml
    /// </summary>
    public partial class pageBidCar : Page
    {
        List<Auto> autos;
        List<Acess> acesses;
        Eventslog eventslog = new Eventslog();
        string login;
        public pageBidCar(string logi)
        {
            try
            {
                InitializeComponent();
                autos = new List<Auto>();
                acesses = new List<Acess>();
                login = logi;
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("инициализации");
            }

        }
        public pageBidCar()
        {

        }

        private void button_Word_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                bool isReadyA = false;
                bool isReadyAcess = false;
                int i = 0;
                if ((autos.Count == 0) && (acesses.Count == 0)) throw new ArgumentException();
                Bid bid = new Bid();
                if (autos.Count != 0)
                {
                    string Auto = string.Empty;
                    string countAuto = string.Empty;
                    ProcessingWord Autosword = new ProcessingWord("SampleBid.docx");
                    foreach (var item in autos)
                    {
                        Auto += item.Manufacturer + " " + item.Model + " " + item.Equipment + Convert.ToChar(94) + Convert.ToChar(112);
                        countAuto += Convert.ToString(item.Amount) + Convert.ToChar(94) + Convert.ToChar(112);
                        int id = bid.AddBid(login, "Автомобили", item.Manufacturer + " " + item.Model + " " + item.Equipment, item.Amount).Id;
                        eventslog.AddEvents(login, "Информация", DateTime.Now, "Сформирована заявка на закупку автомобиля №" + Convert.ToString(id));
                    }
                    var items = new Dictionary<string, string>
                        {
                        {"<Auto>", Auto},
                        { "<count>", countAuto}
                        };
                    Autosword.Process(items, @"Заявки\Автомобили", i);
                    i++;

                    isReadyA = Autosword.IsSuccsesfull;
                }
                if (acesses.Count != 0)
                {

                    string type = string.Empty;
                    string typcount = string.Empty;
                    ProcessingWord Accesword = new ProcessingWord("Access.docx");
                    foreach (var item in acesses)
                    {
                        type += item.Type + " " + item.Name + Convert.ToChar(94) + Convert.ToChar(112);
                        typcount += Convert.ToString(item.Amount) + Convert.ToChar(94) + Convert.ToChar(112);
                        int id = bid.AddBid(login, "Аксессуары", item.Type + " " + item.Name, item.Amount).Id;
                        eventslog.AddEvents(login, "Информация", DateTime.Now, "Сформирована заявка на закупку аксессуара №" + Convert.ToString(id));
                    }

                    var items = new Dictionary<string, string>
                    {
                        {"<TypesName>", type},
                        { "<count>", typcount}
                    };
                    Accesword.Process(items, @"Заявки\Аксессуары", i);
                    i++;

                    isReadyAcess = Accesword.IsSuccsesfull;
                }
                if (isReadyA || isReadyAcess)
                {

                    DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Users\fdkir\OneDrive\Рабочий стол\Курсовая работа\CarShowroom\CarShowroom\WordFile\Заявки");
                    string path = Directory.GetCurrentDirectory();
                    Done.ShowS("Заявка сформирована");
                }
                else
                {
                    ErorrWindow.ShowS("Не получилось сформировать заявку");
                }
            }
            catch (ArgumentException)
            {
                ErorrWindow.ShowS("Списки из автомобилей и аксессуаров отсутствуют");
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Не получилось сформировать заявку");
            }

        }

        private void TextBox_Amount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void button_AddCar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Auto auto = new Auto
                {
                    Manufacturer = TextBox_Manufacturer.Text,
                    Model = TextBox_Model.Text,
                    Equipment = TextBox_Equipment.Text,
                    Amount = (Convert.ToInt32(TextBox_Amount.Text) < 1) ? throw new Exception() : Convert.ToInt32(TextBox_Amount.Text),
                };
                autos.Add(auto);
                listViewCar.Items.Add(auto);
                TextBox_Manufacturer.Text = "";
                TextBox_Equipment.Text = "";
                TextBox_Model.Text = "";
                TextBox_Amount.Text = "";
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Количество машин не может быть равным: " + TextBox_Amount.Text);
            }
        }

        private void button_AddAccessory_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Acess acess = new Acess
                {
                    Type = TextBox_Type.Text,
                    Name = TextBox_Name.Text,
                    Opis = TextBoxOpis.Text,
                    Amount = (Convert.ToInt32(TextBox_AmountA.Text) < 1) ? throw new Exception() : Convert.ToInt32(TextBox_AmountA.Text),


                };
                acesses.Add(acess);
                listViewAccessory.Items.Add(acess);
                TextBox_Type.Text = "";
                TextBox_Name.Text = "";
                TextBoxOpis.Text = "";
                TextBox_AmountA.Text = "";
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Количество аксессуаров не может быть равным: " + TextBox_AmountA.Text);
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            int index = listViewCar.SelectedIndex;
            listViewCar.Items.RemoveAt(index);
            autos.RemoveAt(index);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            int index = listViewAccessory.SelectedIndex;
            listViewAccessory.Items.RemoveAt(index);
            acesses.RemoveAt(index);
        }

        private void button_DeleteCar_Click(object sender, RoutedEventArgs e)
        {
            listViewCar.Items.Clear();
            autos.Clear();
        }

        private void button_DeleteAccessory_Click(object sender, RoutedEventArgs e)
        {
            listViewAccessory.Items.Clear();
            acesses.Clear();
        }

        private void TextBox_AmountA_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
