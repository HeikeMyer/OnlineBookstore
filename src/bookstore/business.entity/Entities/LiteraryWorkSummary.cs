using System;
using System.Collections.Generic;

namespace business.entity.Entities
{
    public partial class LiteraryWorkSummary
    {
        public LiteraryWorkSummary()
        {
            LiteraryWork = new HashSet<LiteraryWork>();
        }

        public Guid Id { get; set; }
        public Guid LanguageFk { get; set; }
        public Guid DataStorageFk { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }

        public virtual DataStorage DataStorageFkNavigation { get; set; }
        public virtual Language LanguageFkNavigation { get; set; }
        public virtual User UpdatedByNavigation { get; set; }
        public virtual ICollection<LiteraryWork> LiteraryWork { get; set; }
    }
}
