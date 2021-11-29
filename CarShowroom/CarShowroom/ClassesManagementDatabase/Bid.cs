using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.ClassesManagementDatabase
{
    public partial class Bid
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }

        public virtual Employee Employee { get; set; }

        public Bid AddBid(string loginEmpl, string type, string Name, int Count)
        {
            using (var db = new CarShowroomContext())
            {
                Employee employee = new Employee();
                employee = (loginEmpl != null) ? employee.GetEmployee(loginEmpl, null) : null;
                int? id = (employee != null) ? employee.Id : null;

                Bid bid = new Bid
                {
                    EmployeeId = id,
                    Type = type,
                    Name = Name,
                    Count = Count,
                };

                db.Bids.Add(bid);
                db.SaveChanges();


                return bid;
            }
        }
    }
}
