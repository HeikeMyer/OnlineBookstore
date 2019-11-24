using System;
using System.Collections.Generic;

namespace business.entity.Entities
{
    public partial class Basket
    {
        public Basket()
        {
            Purchase = new HashSet<Purchase>();
        }

        public Guid Id { get; set; }
        public Guid UserFk { get; set; }
        public Guid? PaymentFk { get; set; }
        public decimal Price { get; set; }
        public bool IsPaid { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Payment PaymentFkNavigation { get; set; }
        public virtual User UserFkNavigation { get; set; }
        public virtual ICollection<Purchase> Purchase { get; set; }
    }
}
