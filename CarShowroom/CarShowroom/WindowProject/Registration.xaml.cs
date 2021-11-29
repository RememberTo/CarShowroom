using CarShowroom;
using CarShowroom.ClassesManagementDatabase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
        Eventslog eventslog = new Eventslog();
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

                if (TextBox_Password.Password != TextBox_RePassword.Password)

                {
                    MessageBox.Show("Пароли не совпадают");
                    return;
                }
                if (TextBox_FIO.Text == string.Empty || 
                    TextBox_Login.Text == string.Empty || 
                    TextBox_Position.Text == string.Empty || 
                    TextBox_Depart.Text == string.Empty ||
                    TextBox_Password.Password == string.Empty
                    )
                {
                    MessageBox.Show("Заполните поля с ФИО, Логин, Отдел, Должность и пароль");
                    return;
                }
                if (employee.GetEmployee(TextBox_Login.Text,TextBox_Password.Password) != null) throw new ArgumentException();
                if (employee.GetEmployee(TextBox_Login.Text, null) != null) throw new InvalidOperationException();
                employee.Add(TextBox_FIO.Text, TextBox_Depart.Text, TextBox_Position.Text,
                                 TextBox_Phone.Text, TextBox_Login.Text, TextBox_Password.Password);

                eventslog.AddEvents(null, "Регистрация", DateTime.Now, "Регистрация нового пользователя: " + TextBox_FIO.Text + " Логин: "+TextBox_Login.Text );
                MessageBox.Show("Вы успешно зарегестрировались");
                this.Close();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Пользователь с данным логином уже существует");
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

        private void TextBox_Phone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
