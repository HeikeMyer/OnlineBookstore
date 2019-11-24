using System;
using System.Collections.Generic;

namespace business.entity.Entities
{
    public partial class Payment
    {
        public Payment()
        {
            Basket = new HashSet<Basket>();
        }

        public Guid Id { get; set; }
        public Guid UserFk { get; set; }
        public Guid PaymentMethodFk { get; set; }
        public Guid PaymentStatusFk { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public virtual PaymentMethod PaymentMethodFkNavigation { get; set; }
        public virtual PaymentStatus PaymentStatusFkNavigation { get; set; }
        public virtual User UserFkNavigation { get; set; }
        public virtual ICollection<Basket> Basket { get; set; }
    }
}
