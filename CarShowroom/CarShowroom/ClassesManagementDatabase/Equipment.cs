using System;
using System.Collections.Generic;
using System.Linq;

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
        public string TypeDrive { get; set; }
        public string Fuel { get; set; }

        public virtual Model Model { get; set; }
        public virtual ICollection<Car> Cars { get; set; }

        public Equipment Add(string name, string typeDrive, string fuel, int modelId)
        {
            using (var context = new CarShowroomContext())
            {
                var eq = new Equipment { ModelId = modelId, NameEquipment = name, Fuel = fuel, TypeDrive = typeDrive };

                context.Equipment.Add(eq);
                context.SaveChanges();

                return eq;
            }
        }

        public Equipment GetSoEquipment(string name, string fuel, string drive, int price)
        {
            using (var context = new CarShowroomContext())
            {
                var query = context.Equipment.FirstOrDefault(x => x.NameEquipment == name && x.Fuel == fuel && x.TypeDrive == drive);

                return query;
            }
        }

        public Equipment FullEdit(int? Id, string TypeDrive, string Fuel)
        {
            using (var db = new CarShowroomContext())
            {
                var car = db.Equipment.FirstOrDefault(x => x.Id == Id);

                if (car != null)
                {
                    car.TypeDrive = TypeDrive;
                    car.Fuel = Fuel;

                    db.Equipment.Update(car);
                    db.SaveChanges();
                }
                return car;
            }
        }

    }
}
