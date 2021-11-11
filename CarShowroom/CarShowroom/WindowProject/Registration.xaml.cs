using CarShowroom;
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
using System.Windows.Shapes;

namespace CarShowroomSystem.Window
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void button_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_OK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var employee = new Employee();

                if (TextBox_Password.Password != TextBox_RePassword.Password) MessageBox.Show("Пароли не совпадают");

                if (employee.GetEmployee(TextBox_Login.Text,TextBox_Password.Password) != null) throw new ArgumentException();

                employee.Add(TextBox_FIO.Text, TextBox_Depart.Text, TextBox_Position.Text, 
                             TextBox_Phone.Text, TextBox_Password.Password, TextBox_Login.Text);

                MessageBox.Show("Вы успешно зарегестрировались");
                this.Close();
            }
            catch(ArgumentException)
            {
                MessageBox.Show("Пользователь с данным логином и паролем уже существует");
            }
            catch (Exception)
            {
                MessageBox.Show("Возникла ошибка");
            }
        }
    }
}
