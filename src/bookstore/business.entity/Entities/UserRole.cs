﻿using System;
using System.Collections.Generic;

namespace business.entity.Entities
{
    public partial class UserRole
    {
        public Guid Id { get; set; }
        public Guid UserFk { get; set; }
        public Guid RoleFk { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Guid UpdatedBy { get; set; }

        public virtual Role RoleFkNavigation { get; set; }
        public virtual User UpdatedByNavigation { get; set; }
        public virtual User UserFkNavigation { get; set; }
    }
}
