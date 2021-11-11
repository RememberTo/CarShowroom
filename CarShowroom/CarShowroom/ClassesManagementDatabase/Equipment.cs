using System;
using System.Collections.Generic;

#nullable disable

namespace CarShowroom
{
    public partial class Equipment
    {
        public Equipment()
        {
            Cars = new HashSet<Car>();
        }

        public int Id { get; set; }
        public int? ModelId { get; set; }
        public string NameEquipment { get; set; }
        public int Price { get; set; }
        public string TypeDrive { get; set; }
        public string Fuel { get; set; }

        public virtual Model Model { get; set; }
        public virtual ICollection<Car> Cars { get; set; }

        public Equipment Add(string name, int price, string typeDrive, string fuel, int modelId)
        {
            using (var context = new CarShowroomContext())
            {
                var eq = new Equipment { ModelId = modelId, NameEquipment = name, Price = price, Fuel = fuel, TypeDrive = typeDrive };

                context.Equipment.Add(eq);
                context.SaveChanges();

                return eq;
            }
        }

    }
}
