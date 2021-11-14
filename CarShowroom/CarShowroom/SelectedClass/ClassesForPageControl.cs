using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShowroom.SelectedClass
{
    class ClassesForPageControl
    {
    }

    class Auto
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Equipment { get; set;}
        public int Amount { get; set; }
    }
    class Acess
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Opis { get; set; }
        public int Amount { get; set; }

    }
    class ProductCar
    {
        public string ManufacModelEquip { get; set; }
        public int Price { get; set; }
        public string Vin { get; set; }

        public override bool Equals(Object productCar)
        {
            try
            {
                var pr = (ProductCar)productCar;
                if (Vin == pr.Vin)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    class Payment
    {
        string Type { get; set; }
        double InitialPay { get; set; }
        double MonthPay { get; set; }
        int CountMonth { get; set; }
    }
}
