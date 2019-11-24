using System;
using System.Collections.Generic;

namespace business.entity.Entities
{
    public partial class Item
    {
        public Item()
        {
            Purchase = new HashSet<Purchase>();
        }

        public Guid Id { get; set; }
        public string Barcode { get; set; }
        public Guid BookFk { get; set; }
        public Guid ProviderFk { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsSold { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Book BookFkNavigation { get; set; }
        public virtual Provider ProviderFkNavigation { get; set; }
        public virtual User UpdatedByNavigation { get; set; }
        public virtual ICollection<Purchase> Purchase { get; set; }
    }
}
