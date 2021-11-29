using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace CarShowroom
{
    public partial class Customer
    {
        public Customer()
        {
            Contracts = new HashSet<Contract>();
        }

        public int Id { get; set; }
        public string Fio { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }

        public Customer Add(string Fio, string PhoneNumber)
        {
            using (var context = new CarShowroomContext())
            {
                var empl = new Customer { Fio = Fio, PhoneNumber = PhoneNumber};

                context.Customers.Add(empl);
                context.SaveChanges();

                return empl;
            }
        }

        public Customer Get(string fio, string phone)
        {
            using (var context = new CarShowroomContext())
            {
                var cust = context.Customers.FirstOrDefault(x => x.Fio == Fio && x.PhoneNumber == phone);

                return cust;
            }
        }
    }
}
