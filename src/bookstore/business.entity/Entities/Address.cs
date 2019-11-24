using System;
using System.Collections.Generic;

namespace business.entity.Entities
{
    public partial class Address
    {
        public Guid Id { get; set; }
        public Guid UserFk { get; set; }
        public Guid CountryFk { get; set; }
        public Guid CityFk { get; set; }
        public string PostIndex { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Apartment { get; set; }
        public bool IsDefault { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public virtual City CityFkNavigation { get; set; }
        public virtual Country CountryFkNavigation { get; set; }
        public virtual User UserFkNavigation { get; set; }
    }
}
