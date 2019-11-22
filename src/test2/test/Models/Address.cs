﻿using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class Address
    {
        public Guid Id { get; set; }
        public Guid? UserFk { get; set; }
        public Guid? CityFk { get; set; }
        public string PostIndex { get; set; }
        public string Street { get; set; }
        public string House { get; set; }
        public string Apartment { get; set; }
        public bool IsDefult { get; set; }

        public virtual City CityFkNavigation { get; set; }
        public virtual User UserFkNavigation { get; set; }
    }
}
