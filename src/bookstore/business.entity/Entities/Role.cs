using System;
using System.Collections.Generic;

namespace business.entity.Entities
{
    public partial class Role
    {
        public Role()
        {
            UserRole = new HashSet<UserRole>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
