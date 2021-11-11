using System;
using System.Collections.Generic;

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
        public DateTime ReleaseDate { get; set; }

        public virtual Contract Contract { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual ICollection<Accessory> Accessories { get; set; }

        public Car Add(string color, string vin, int EqID, int ContractId, DateTime release)
        {
            using (var context = new CarShowroomContext())
            {
                var car = new Car { Color = color, Vin = vin, EquipmentId = EqID, ContractId = ContractId, ReleaseDate = release };

                context.Cars.Add(car);
                context.SaveChanges();

                return car;
            }
        }
    }
}
