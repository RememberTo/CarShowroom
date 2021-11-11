using System;
using System.Collections.Generic;

#nullable disable

namespace CarShowroom
{
    public partial class TypeAccessory
    {
        public TypeAccessory()
        {
            Accessories = new HashSet<Accessory>();
        }

        public int Id { get; set; }
        public string NameTypeAccessory { get; set; }

        public virtual ICollection<Accessory> Accessories { get; set; }

        public TypeAccessory Add(string name)
        {
            using (var context = new CarShowroomContext())
            {
                var type = new TypeAccessory { NameTypeAccessory = name };

                context.TypeAccessories.Add(type);
                context.SaveChanges();

                return type;
            }
        }

    }
}
