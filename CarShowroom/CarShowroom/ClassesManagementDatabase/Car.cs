using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

#nullable disable

namespace CarShowroom
{
    public partial class Car
    {
        public Car()
        {
            Accessories = new HashSet<Accessory>();
        }

        public int Id { get; set; }
        public string Color { get; set; }
        public int? EquipmentId { get; set; }
        public int? ContractId { get; set; }
        public string Vin { get; set; }
        public string Mileage { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Price { get; set; }
        public virtual Contract Contract { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual ICollection<Accessory> Accessories { get; set; }


        public Car Add(string color, string vin, int EqID, int? ContractId, DateTime release, string mileage, int price)
        {
            using (var context = new CarShowroomContext())
            {
                var car = new Car { Color = color, Vin = vin, EquipmentId = EqID, ContractId = ContractId, ReleaseDate = release, Mileage = mileage, Price = price };

                context.Cars.Add(car);
                context.SaveChanges();

                return car;
            }
        }

       
        public Car FullEdit(string vin, string color, string mileage, DateTime date, int price,string editVin)
        {
            using (var db = new CarShowroomContext())
            {
                var car = db.Cars.FirstOrDefault(x => x.Vin == vin);

                if (car != null)
                {
                    car.Color = color;
                    car.Mileage = mileage;
                    car.ReleaseDate = date;
                    car.Price = price;
                    car.Vin = editVin;

                    db.Cars.Update(car);
                    db.SaveChanges();
                }
                return car;
            }
        }
        public Car Edit(string vin, int contractID)
        {
            using (var db = new CarShowroomContext())
            {
                var car = db.Cars.FirstOrDefault(x => x.Vin == vin);
                
                if(car != null) {
                    car.ContractId = contractID;

                    db.Cars.Update(car);
                    db.SaveChanges();
                }
                return car;
            }
        }

        public Car Get(string vin)
        {
            using (var context = new CarShowroomContext())
            {
                var query = context.Cars.FirstOrDefault(x => x.Vin == vin);

                return query;
            }
        }

        public Car Delete (string vin)
        {
            using (var db = new CarShowroomContext())
            {
                var car = db.Cars.FirstOrDefault(x => x.Vin == vin);
                if(car!= null)
                {
                    db.Cars.Remove(car);
                    db.SaveChanges();
                }
                return car;
            }
        }
    }
}
