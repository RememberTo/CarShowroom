using CarShowroomSystem.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using CarShowroom;
using CarShowroom.ClassesManagementDatabase;

namespace CarShowroomSystem
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization
    {
        Eventslog eventslog = new Eventslog();
        static public string login;
        public Authorization()
        {
            InitializeComponent();
        }

        private void button_OK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var employee = new Employee();
                using (var db = new CarShowroomContext())
                {
                    var user = employee.GetEmployee(TextBox_Login.Text, TextBox_Password.Password);
                    if (employee.GetEmployee(TextBox_Login.Text, TextBox_Password.Password) == null) throw new Exception();

                    Work workWindow = new Work(user.Fio,user.Login, user.Position);
                    login = user.Login;
                    workWindow.Show();
                    eventslog.AddEvents(TextBox_Login.Text, "Авторизация", DateTime.Now, "Вход в систему: " + user.Fio);
                    this.Close();
                }
            }
            catch (Exception)
            {
                LabelErrorAuth.Text = "Неправильный логин или пароль";
            }
           
        }

        private void button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Registr_Click(object sender, RoutedEventArgs e)
        {
            var registrWindow = new Registration();
            registrWindow.Show();

        }
    }
}
