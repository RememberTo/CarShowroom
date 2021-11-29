using CarShowroomSystem.WindowProject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarShowroom.WindowProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для Eventslog.xaml
    /// </summary>
    public partial class pageEventslog : Page
    {
        public ObservableCollection<string> listComboTyp = new ObservableCollection<string>();
        public ObservableCollection<string> listComboEmployee = new ObservableCollection<string>();
        public pageEventslog(string login)
        {
            try
            {
                InitializeComponent();
                WindowLoaded();
                TickTimer();
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("инициализации");
            }

        }
        private void TickTimer()
        {
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 40);
            timer.IsEnabled = true;
            timer.Tick += (o, e) => { WindowLoaded(); };
            timer.Start();
        }
        public void WindowLoaded()
        {
            using (var db = new CarShowroomContext())
            {
                var users = from ev in db.Eventslogs
                            join empl in db.Employees on ev.EmployeeId equals empl.Id
                            where ev.Date >= DateTime.Today && ev.Date <= DateTime.Today.AddHours(24)
                            select new
                            {
                                _date = Convert.ToDateTime(ev.Date).ToString("dd.MM.yyyy"),
                                _time = Convert.ToDateTime(ev.Date).ToString("HH:mm"),
                                _type = ev.Type,
                                _employee = empl.Fio,
                                _employeeLog = empl.Login,
                                _event = ev.Event,
                            };

                GridDatabase.ItemsSource = users.ToList();
                listComboTyp.Clear();
                listComboEmployee.Clear();
                foreach (var item in users)
                {
                    listComboEmployee.Add(item._employee);
                    listComboTyp.Add(item._type);
                }
                var liste = listComboEmployee.Distinct();
                var listt = listComboTyp.Distinct();
                comboTyp.ItemsSource = listt;
                comboEmployee.ItemsSource = liste;
                SortDataGrid(GridDatabase, 2);
            }
        }

        private void comboEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetEmpl(Convert.ToString(comboEmployee.SelectedItem));
        }

        private void GetEmpl(string condition)
        {
            using (var db = new CarShowroomContext())
            {
                var users = from ev in db.Eventslogs
                            join empl in db.Employees on ev.EmployeeId equals empl.Id
                            where empl.Fio == condition
                            select new
                            {
                                _date = Convert.ToDateTime(ev.Date).ToString("dd.MM.yyyy"),
                                _time = Convert.ToDateTime(ev.Date).ToString("HH:mm"),
                                _type = ev.Type,
                                _employee = empl.Fio,
                                _employeeLog = empl.Login,
                                _event = ev.Event,
                            };
                GridDatabase.ItemsSource = users.ToList();
            }

        }

        private void comboTyp_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetType(Convert.ToString(comboTyp.SelectedItem));
        }

        private void GetType(string condition)
        {
            using (var db = new CarShowroomContext())
            {
                var users = from ev in db.Eventslogs
                            join empl in db.Employees on ev.EmployeeId equals empl.Id
                            where ev.Type == condition
                            select new
                            {
                                _date = Convert.ToDateTime(ev.Date).ToString("dd.MM.yyyy"),
                                _time = Convert.ToDateTime(ev.Date).ToString("HH:mm"),
                                _type = ev.Type,
                                _employee = empl.Fio,
                                _employeeLog = empl.Login,
                                _event = ev.Event,
                            };
                GridDatabase.ItemsSource = users.ToList();
            }

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (pickC.Text == string.Empty || pickPo.Text == string.Empty)
            {
                ErorrWindow.ShowS("Выберите даты");
                return;
            }
            using (var db = new CarShowroomContext())
            {
                var users = from ev in db.Eventslogs
                            join empl in db.Employees on ev.EmployeeId equals empl.Id
                            where ev.Date >= pickC.SelectedDate && ev.Date <= pickPo.SelectedDate
                            select new
                            {
                                _date = Convert.ToDateTime(ev.Date).ToString("dd.MM.yyyy"),
                                _time = Convert.ToDateTime(ev.Date).ToString("HH:mm"),
                                _type = ev.Type,
                                _employee = empl.Fio,
                                _employeeLog = empl.Login,
                                _event = ev.Event,
                            };
                listComboTyp.Clear();
                listComboEmployee.Clear();
                foreach (var item in users)
                {
                    listComboEmployee.Add(item._employee);
                    listComboTyp.Add(item._type);
                }
                var liste = listComboEmployee.Distinct();
                var listt = listComboTyp.Distinct();
                comboTyp.ItemsSource = listt;
                comboEmployee.ItemsSource = liste;
                GridDatabase.ItemsSource = users.ToList();
            }
        }

        private void drop_Click(object sender, RoutedEventArgs e)
        {
            using (var db = new CarShowroomContext())
            {
                var users = from ev in db.Eventslogs
                            join empl in db.Employees on ev.EmployeeId equals empl.Id
                            where ev.Date >= DateTime.Today && ev.Date <= DateTime.Today.AddHours(24)
                            select new
                            {
                                _date = Convert.ToDateTime(ev.Date).ToString("dd.MM.yyyy"),
                                _time = Convert.ToDateTime(ev.Date).ToString("HH:mm"),
                                _type = ev.Type,
                                _employee = empl.Fio,
                                _employeeLog = empl.Login,
                                _event = ev.Event,
                            };
                GridDatabase.ItemsSource = users.ToList();
                SortDataGrid(GridDatabase, 2);
            }
        }

        private void button_Update_Click(object sender, RoutedEventArgs e)
        {
            WindowLoaded();
        }

        private void GridDatabase_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                using (var db = new CarShowroomContext())
                {
                    var users = from ev in db.Eventslogs
                                join empl in db.Employees on ev.EmployeeId equals empl.Id
                                where ev.Date >= DateTime.Today && ev.Date <= DateTime.Today.AddHours(24)
                                select new
                                {
                                    _date = Convert.ToDateTime(ev.Date).ToString("dd.MM.yyyy"),
                                    _time = Convert.ToDateTime(ev.Date).ToString("HH:mm"),
                                    _type = ev.Type,
                                    _employee = empl.Fio,
                                    _employeeLog = empl.Login,
                                    _event = ev.Event,
                                };
                    var events = string.Empty;
                    foreach (var item in GridDatabase.SelectedItems)
                    {
                        foreach (var items in users)
                        {
                            if (items.Equals(item))
                            {
                                events = items._event;
                            }
                        }
                    }
                    MessageBox.Show(events, "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
                ErorrWindow.ShowS("наведитесь на элемент таблицы");
            }
        }

        public static void SortDataGrid(DataGrid dataGrid, int columnIndex = 0, ListSortDirection sortDirection = ListSortDirection.Descending)
        {
            var column = dataGrid.Columns[columnIndex];

            dataGrid.Items.SortDescriptions.Clear();

            dataGrid.Items.SortDescriptions.Add(new SortDescription(column.SortMemberPath, sortDirection));

            foreach (var col in dataGrid.Columns)
            {
                col.SortDirection = null;
            }
            column.SortDirection = sortDirection;

            dataGrid.Items.Refresh();
        }
    }
}
