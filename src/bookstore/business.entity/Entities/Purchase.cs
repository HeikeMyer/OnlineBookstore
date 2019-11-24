using System;
using System.Collections.Generic;

namespace business.entity.Entities
{
    public partial class Purchase
    {
        public Guid Id { get; set; }
        public Guid UserFk { get; set; }
        public Guid? BasketFk { get; set; }
        public Guid ItemFk { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Basket BasketFkNavigation { get; set; }
        public virtual Item ItemFkNavigation { get; set; }
        public virtual User UserFkNavigation { get; set; }
    }
}
