using System;
using System.Collections.Generic;

#nullable disable

namespace CarShowroom
{
    public partial class Payment
    {
        public int Id { get; set; }
        public string PayMethod { get; set; }
        public double? InitialDonatMoney { get; set; }
        public double? MonthlyPay { get; set; }
        public int? CountMonthInstallment { get; set; }

        public Payment Add(string paymethod, double initialmoney, double monthlypay, int countmonth)
        {
            using (var context = new CarShowroomContext())
            {
                if (paymethod == "Полный рассчет")
                {
                    var pay = new Payment { PayMethod = paymethod, InitialDonatMoney = initialmoney, MonthlyPay = null, CountMonthInstallment = null };

                    context.Payments.Add(pay);
                    context.SaveChanges();

                    return pay;
                }
                else
                {
                    var pay = new Payment { PayMethod = paymethod, InitialDonatMoney = initialmoney, MonthlyPay = monthlypay, CountMonthInstallment = countmonth };

                    context.Payments.Add(pay);
                    context.SaveChanges();

                    return pay;
                }
            }

        }
    }
}
