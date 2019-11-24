using System;
using System.Collections.Generic;

namespace business.entity.Entities
{
    public partial class Provider
    {
        public Provider()
        {
            Item = new HashSet<Item>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Item> Item { get; set; }
    }
}
