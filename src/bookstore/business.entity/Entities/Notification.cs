using System;
using System.Collections.Generic;

namespace business.entity.Entities
{
    public partial class Notification
    {
        public Guid Id { get; set; }
        public Guid UserFk { get; set; }
        public Guid OperationTypeFk { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool IsSent { get; set; }

        public virtual OperationType OperationTypeFkNavigation { get; set; }
        public virtual User UserFkNavigation { get; set; }
    }
}
