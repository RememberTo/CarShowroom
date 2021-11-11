using System;
using System.Collections.Generic;

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

    }
}
