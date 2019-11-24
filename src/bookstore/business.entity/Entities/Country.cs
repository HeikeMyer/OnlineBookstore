using System;
using System.Collections.Generic;

namespace business.entity.Entities
{
    public partial class Country
    {
        public Country()
        {
            Address = new HashSet<Address>();
            City = new HashSet<City>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<City> City { get; set; }
    }
}
