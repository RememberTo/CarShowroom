using System;
using System.Collections.Generic;
using System.Linq; 
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
        public DateTime DateSale { get; set; }
        public string PayMethod { get; set; }
        public double? InitialDonatMoney { get; set; }
        public double? MonthlyPay { get; set; }
        public int? CountMonthInstallment { get; set; }


        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Car> Cars { get; set; }

        public Contract Add(int? customerId, int employeeId,
            DateTime Sale, string paymethod, double initialmoney, double? monthlypay, int? countmonth)
        {
            using (var context = new CarShowroomContext())
            {
                var eq = new Contract { CustomerId = (customerId == -1)? null:customerId, 
                    EmployeeId = employeeId, 
                    DateSale = Sale, PayMethod = paymethod, 
                    InitialDonatMoney = initialmoney, MonthlyPay = monthlypay, 
                    CountMonthInstallment = countmonth };

                context.Contracts.Add(eq);
                context.SaveChanges();

                return eq;
            }
        }
    }
}
