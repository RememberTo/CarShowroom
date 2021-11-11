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

namespace CarShowroomSystem.WindowProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для pagePayment.xaml
    /// </summary>
    public partial class pagePayment : Page
    {
        public pagePayment()
        {
            InitializeComponent();
        }

        private void comboBoxPay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBoxPay.SelectedIndex == 0) //Полный расчет
            {
               
            }
            if (comboBoxPay.SelectedIndex == 1) //Частичный расчет и кредит
            {
             
            }
            if (comboBoxPay.SelectedIndex == 2) //Кредит
            {
                
            }
        }

        private void button_getPrice_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (TextBoxVIN.Text != "") throw new Exception();
                using (var db = new CarShowroomContext())
                {

                    var users = (from manufac in db.Manufacturers
                                 join model in db.Models on manufac.Id equals model.ManufacturerId
                                 join eq in db.Equipment on model.Id equals eq.ModelId
                                 join car in db.Cars on eq.Id equals car.EquipmentId
                                 where car.Vin == TextBoxVIN.Text
                                 select new
                                 {
                                     eq.Price
                                 }).FirstOrDefault();
                    string a = users.ToString();

                    string[] b = a.Split(' ', 'P', 'r', 'i', 'c', 'e', '=', '{', '}');
                    price.Text = b[10];
                }
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Такого VIN номера не существует\nили он неправильно введен");
            }
        }
    }
}
