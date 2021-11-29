using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable

namespace CarShowroom
{
    public partial class Manufacturer
    {
        public Manufacturer()
        {
            Models = new HashSet<Model>();
        }

        public int Id { get; set; }
        public string Carbrand { get; set; }

        public virtual ICollection<Model> Models { get; set; }

        public Manufacturer Add(string name)
        {
            using (var context = new CarShowroomContext())
            {
                var car = new Manufacturer { Carbrand = name };

                context.Manufacturers.Add(car);
                context.SaveChanges();

                return car;
            }

        }

        public Manufacturer GetSoId(int id)
        {
            using (var context = new CarShowroomContext())
            {
                var query = context.Manufacturers.FirstOrDefault(x => x.Id == id);

                return query;
            }
        }
        public Manufacturer GetSoCarbrand(string car)
        {
            using (var context = new CarShowroomContext())
            {
                var query = context.Manufacturers.FirstOrDefault(x => x.Carbrand == car);

                return query;
            }
        }

    }
}
