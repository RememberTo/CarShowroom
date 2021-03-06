using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace CarShowroom
{
    public partial class Model
    {
        public Model()
        {
            Equipment = new HashSet<Equipment>();
        }

        public int Id { get; set; }
        public int? ManufacturerId { get; set; }
        public string NameModel { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }
        public virtual ICollection<Equipment> Equipment { get; set; }

        public Model Add(string name, int idManufacturer)
        {
            using (var context = new CarShowroomContext())
            {
                var model = new Model { ManufacturerId = idManufacturer, NameModel = name };

                context.Models.Add(model);
                context.SaveChanges();

                return model;
            }

        }

        public Model GetSoModel(string car)
        {
            using (var context = new CarShowroomContext())
            {
                var query = context.Models.FirstOrDefault(x => x.NameModel == car);

                return query;
            }
        }

    }
}
