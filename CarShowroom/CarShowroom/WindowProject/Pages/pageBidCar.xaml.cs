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

namespace CarShowroomSystem.WindowProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для pageBidCar.xaml
    /// </summary>
    public partial class pageBidCar : Page
    {
        List<Auto> autos;
        List<Acess> acesses;
        public pageBidCar()
        {
            InitializeComponent();
            autos = new List<Auto>();
            acesses = new List<Acess>();
        }

        private void button_Word_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                bool isReadyA = false;
                bool isReadyAcess =false;
                int i = 0;
                if ((autos.Count == 0)&&(acesses.Count == 0)) throw new ArgumentException();
                if (autos.Count != 0)
                {
                    ProcessingWord Autosword = new ProcessingWord("SampleBid.docx");
                    foreach (var item in autos)
                    {
                        var items = new Dictionary<string, string>
                    {
                        {"<Auto>", item.Manufacturer+" "+item.Model+" "+item.Equipment},
                        { "<count>", Convert.ToString(item.Amount)}
                    };
                        Autosword.Process(items, @"Заявки\Автомобили", i);
                        i++;
                    }
                    isReadyA = Autosword.IsSuccsesfull;
                }
                if (acesses.Count != 0)
                {
                    ProcessingWord Accesword = new ProcessingWord("Access.docx");
                    foreach (var item in acesses)
                    {
                        var items = new Dictionary<string, string>
                    {
                        {"<TypesName>", item.Type+" "+item.Name},
                        { "<count>", Convert.ToString(item.Amount)}
                    };
                        Accesword.Process(items, @"Заявки\Аксессуары", i);
                        i++;
                    }
                    isReadyAcess = Accesword.IsSuccsesfull;
                }
                if (isReadyA || isReadyAcess)
                {
                    Done.ShowS("Накладная сформирована");
                }
                else
                {
                    ErorrWindow.ShowS("Не получилось сформировать накладную");
                }
            }
            catch(ArgumentException)
            {
                ErorrWindow.ShowS("Списки из автомобилей и аксессуаров отсутствуют");
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Не получилось сформировать накладную");
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
                    Amount = Convert.ToInt32(TextBox_Amount.Text)
                };
                autos.Add(auto);
                listViewCar.Items.Add(auto);
                TextBox_Manufacturer.Text = "";
                TextBox_Equipment.Text = "";
                TextBox_Model.Text = "";
                TextBox_Amount.Text = "";
            }
            catch (Exception ex)
            {
                ErorrWindow.ShowS(ex.ToString());
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
                    Amount = Convert.ToInt32(TextBox_AmountA.Text)
                    
                };
                acesses.Add(acess);
                listViewAccessory.Items.Add(acess);
                TextBox_Type.Text = "";
                TextBox_Name.Text = "";
                TextBoxOpis.Text = "";
                TextBox_AmountA.Text = "";
            }
            catch (Exception ex)
            {
                ErorrWindow.ShowS(ex.ToString());
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
