using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.ClassesManagementDatabase
{
    public partial class Eventslog
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Event { get; set; }

        public virtual Employee Employee { get; set; }

        public Eventslog AddEvents(string loginEmpl, string type, DateTime date, string Event)
        {
            using (var db = new CarShowroomContext())
            {
                Employee employee = new Employee();
                employee = (loginEmpl != null) ? employee.GetEmployee(loginEmpl, null) : null;
                int? id = (employee != null) ? employee.Id : null;

                Eventslog eventslog = new Eventslog
                {
                    EmployeeId = id,
                    Type = type,
                    Date = date,
                    Event = Event,
                };

                db.Eventslogs.Add(eventslog);
                db.SaveChanges();


                return eventslog;
            }
        }
    }
}
