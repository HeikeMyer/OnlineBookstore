﻿using System;
using System.Collections.Generic;

namespace business.entity.Entities
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Payment = new HashSet<Payment>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Payment> Payment { get; set; }
    }
}
