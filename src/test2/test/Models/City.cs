using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class City
    {
        public City()
        {
            Address = new HashSet<Address>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? CountryFk { get; set; }

        public virtual Country CountryFkNavigation { get; set; }
        public virtual ICollection<Address> Address { get; set; }
    }
}
