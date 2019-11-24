using System;
using System.Collections.Generic;

namespace business.entity.Entities
{
    public partial class LoginActivity
    {
        public Guid Id { get; set; }
        public Guid UserFk { get; set; }
        public byte[] IpAddressRaw { get; set; }
        public string IpAddress { get; set; }
        public DateTime LoginDate { get; set; }

        public virtual User UserFkNavigation { get; set; }
    }
}
