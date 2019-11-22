using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class Country
    {
        public Country()
        {
            City = new HashSet<City>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public virtual ICollection<City> City { get; set; }
    }
}
