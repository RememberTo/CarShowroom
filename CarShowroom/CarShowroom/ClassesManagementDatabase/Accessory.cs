using System;
using System.Collections.Generic;
using System.Linq;

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
        public string Description { get; set; }

        public virtual Car Car { get; set; }
        public virtual TypeAccessory TypeAccessory { get; set; }

        public Accessory Add(string name, int price, int TypeAccessoryId, int? CarId, string des)
        {
            using (var context = new CarShowroomContext())
            {
                var empl = new Accessory { NameAccessory = name, Price = price, CarId = CarId, TypeAccessoryId = TypeAccessoryId, Description = des};

                context.Accessories.Add(empl);
                context.SaveChanges();

                return empl;
            }
        }

        public Accessory Edit(int CarId, int AccessoryId)
        {
            using (var context = new CarShowroomContext())
            {
                var empl = context.Accessories.FirstOrDefault(x => x.Id == AccessoryId);
                empl.CarId = CarId;

                context.Accessories.Update(empl);
                context.SaveChanges();
                
                return empl;
            }
        }

        public Accessory Delete(int AccessoryId)
        {
            using (var context = new CarShowroomContext())
            {
                var empl = context.Accessories.FirstOrDefault(x => x.Id == AccessoryId);
                
                if(empl != null)
                {
                    context.Accessories.Remove(empl);
                    context.SaveChanges();
                }

                return empl;
            }
        }

        public Accessory DeleteInCar(int AccessoryId)
        {
            using (var context = new CarShowroomContext())
            {
                var empl = context.Accessories.FirstOrDefault(x => x.Id == AccessoryId);

                if (empl != null)
                {
                    empl.CarId = null;
                    context.Accessories.Update(empl);
                    context.SaveChanges();
                }

                return empl;
            }
        }
    }
}
