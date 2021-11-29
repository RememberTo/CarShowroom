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
    }

    class Payment
    {
        public string Type { get; set; }
        public double InitialPay { get; set; }
        public double MonthPay { get; set; }
        public  int CountMonth { get; set; }
    }
    class Access
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Discription { get; set; }
    }

    class FullCar
    {
        public string ManufacModelEquip { get; set; }
        public string Price { get; set; }
        public string Drive { get; set; }
        public string Fuel { get; set; }
        public string Color { get; set; }
        public DateTime Date { get; set; }
        public string Vin { get; set; }
        public string Mileage { get; set; }
    }

    class AddingAccessToCar
    {
        public int _Id { get; set; }
        public string _type { get; set; }
        public string _name { get; set; }
        public int _price { get; set; }
        public string _opis { get; set; }
        
    }

    class FullCarToAcess
    {
        public string Manufac { get; set; }
        public string Model { get; set; }
        public string Equip { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public DateTime Date { get; set; }
        public string Vin { get; set; }
    }
}
