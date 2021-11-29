using CarShowroom.ClassesManagementDatabase;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace CarShowroom
{
    public partial class Employee
    {
        public Employee()
        {
            Contracts = new HashSet<Contract>();
        }

        public int Id { get; set; }
        public string Fio { get; set; }
        public string Departament { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Eventslog> Eventslogs { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }

        public Employee Add(string Fio, string Departament, string Position, string PhoneNumber, string Login, string Password)
        {
            using (var context = new CarShowroomContext())
            {
                var empl = new Employee { Fio = Fio, PhoneNumber = PhoneNumber, Departament = Departament, Position = Position, Login = Login, Password = Password };

                context.Employees.Add(empl);
                context.SaveChanges();

                return empl;
            }
        }

        public Employee GetEmployee(string login, string pass)
        {
            using (var db = new CarShowroomContext())
            {
                if (pass == null)
                {
                    var user = db.Employees.FirstOrDefault(x => x.Login == login);
                    return user;
                }
                else
                {
                    var user = db.Employees.FirstOrDefault(x => x.Login == login && x.Password == pass);
                    return user;
                }
            }
        }
    }
}
