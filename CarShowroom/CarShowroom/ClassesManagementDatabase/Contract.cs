using System;
using System.Collections.Generic;

#nullable disable

namespace CarShowroom
{
    public partial class Contract
    {
        public Contract()
        {
            Cars = new HashSet<Car>();
        }

        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public int? PaymentId { get; set; }
        public DateTime DateBid { get; set; }
        public DateTime DateSale { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Car> Cars { get; set; }

        public Contract Add(int customerId, int employeeId, int PayId, DateTime Bid, DateTime Sale)
        {
            using (var context = new CarShowroomContext())
            {
                var eq = new Contract { CustomerId = customerId, EmployeeId = employeeId, PaymentId = PayId, DateBid = Bid, DateSale = Sale };

                context.Contracts.Add(eq);
                context.SaveChanges();

                return eq;
            }
        }

    }
}
