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
using System.Windows.Navigation;
using System.Linq;
using System.Windows.Shapes;
using CarShowroom.SelectedClass;
using CarShowroom.WindowProject;
using CarShowroom.WindowProject.Pages.WindowForPages;

namespace CarShowroomSystem.WindowProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для pageAccessory.xaml
    /// </summary>
    public partial class pageAccessory : Page
    {
        private string login;
        public pageAccessory(string logi)
        {
            try
            {
                InitializeComponent();
                WindowLoaded();
                login = logi;
                List<Access> accesses = new List<Access>();
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("Инициализации");
            }

        }


        private void WindowLoaded()
        {
            using (var db = new CarShowroomContext())
            {
                var users = from typ in db.TypeAccessories
                            join acces in db.Accessories on typ.Id equals acces.TypeAccessoryId
                            where acces.CarId == null
                            select new
                            {
                                _Id = acces.Id,
                                _Type = typ.NameTypeAccessory,
                                _Name = acces.NameAccessory,
                                _Price = acces.Price,
                                _Discription = acces.Description,
                            };

                GridDatabase.ItemsSource = users.ToList();
            }
        }

        private void button_Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new CarShowroomContext())
                {
                    var users = from typ in db.TypeAccessories
                                join acces in db.Accessories on typ.Id equals acces.TypeAccessoryId
                                where acces.CarId == null
                                select new
                                {
                                    _Id = acces.Id,
                                    _Type = typ.NameTypeAccessory,
                                    _Name = acces.NameAccessory,
                                    _Price = acces.Price,
                                    _Discription = acces.Description,
                                };

                    GridDatabase.ItemsSource = users.ToList();
                
                    if (string.IsNullOrEmpty(TextBoxType.Text) && string.IsNullOrEmpty(TextBoxName.Text))
                    {
                        GridDatabase.ItemsSource = null;
                        GridDatabase.ItemsSource = users.ToList();
                    }
                    else
                    {
                        var query = users.Where(q => q._Type == TextBoxType.Text || q._Name == TextBoxName.Text);

                        if (query == null) throw new Exception();

                        GridDatabase.ItemsSource = null;

                        GridDatabase.ItemsSource = query.ToList();
                    }
                }
            }
            catch (Exception)
            {
                GridDatabase.ItemsSource = null;
                Done.ShowS("Ничего не найдено");
            }
        }

        private void button_Update_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new CarShowroomContext())
            {
                var users = from typ in db.TypeAccessories
                            join acces in db.Accessories on typ.Id equals acces.TypeAccessoryId
                            where acces.CarId == null
                            select new
                            {
                                _Id = acces.Id,
                                _Type = typ.NameTypeAccessory,
                                _Name = acces.NameAccessory,
                                _Price = acces.Price,
                                _Discription = acces.Description,
                            };

                GridDatabase.ItemsSource = users.ToList();
            }
        }

        private void button_Add_Click(object sender, RoutedEventArgs e)
        {
            AcessoryAdd acessoryAdd = new AcessoryAdd(login);
            acessoryAdd.Show();
        }

        private void button_AddAcessoryToCar_Click(object sender, RoutedEventArgs e)
        {
            AddAccessToCar car = new AddAccessToCar(login);
            car.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new CarShowroomContext())
            {
                var users = from typ in db.TypeAccessories
                            join acces in db.Accessories on typ.Id equals acces.TypeAccessoryId
                            where acces.CarId == null
                            select new
                            {
                                _Id = acces.Id,
                                _Type = typ.NameTypeAccessory,
                                _Name = acces.NameAccessory,
                                _Price = acces.Price,
                                _Discription = acces.Description,
                            };

                int idDel = -1;
                foreach (var item in GridDatabase.SelectedItems)
                {
                    foreach (var items in users)
                    {
                        if (items.Equals(item))
                        {
                            idDel = items._Id;
                        }
                    }
                }
                if (idDel != -1)
                {
                    Accessory accessory = new Accessory();
                    accessory.Delete(idDel);
                }

                var users1 = from typ in db.TypeAccessories
                            join acces in db.Accessories on typ.Id equals acces.TypeAccessoryId
                            where acces.CarId == null
                            select new
                            {
                                _Id = acces.Id,
                                _Type = typ.NameTypeAccessory,
                                _Name = acces.NameAccessory,
                                _Price = acces.Price,
                                _Discription = acces.Description,
                            };

                GridDatabase.ItemsSource = users1.ToList();
            }
        }
    }
}
