using System;
using System.Collections.Generic;

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
   
    }
}
