using System;
using System.Collections.Generic;

namespace business.entity.Entities
{
    public partial class OperationType
    {
        public OperationType()
        {
            Notification = new HashSet<Notification>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Notification> Notification { get; set; }
    }
}
