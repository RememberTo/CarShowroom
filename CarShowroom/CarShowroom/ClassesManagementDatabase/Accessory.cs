using System;
using System.Collections.Generic;

#nullable disable

namespace CarShowroom
{
    public partial class Accessory
    {
        public int Id { get; set; }
        public int? TypeAccessoryId { get; set; }
        public int? CarId { get; set; }
        public string NameAccessory { get; set; }
        public int Price { get; set; }

        public virtual Car Car { get; set; }
        public virtual TypeAccessory TypeAccessory { get; set; }

        public Accessory Add(string name, int price, int TypeAccessoryId, int CarId)
        {
            using (var context = new CarShowroomContext())
            {
                var empl = new Accessory { NameAccessory = name, Price = price, CarId = CarId, TypeAccessoryId = TypeAccessoryId };

                context.Accessories.Add(empl);
                context.SaveChanges();

                return empl;
            }
        }
    }
}
