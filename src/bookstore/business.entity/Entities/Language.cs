using System;
using System.Collections.Generic;

namespace business.entity.Entities
{
    public partial class Language
    {
        public Language()
        {
            LiteraryWorkSummary = new HashSet<LiteraryWorkSummary>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<LiteraryWorkSummary> LiteraryWorkSummary { get; set; }
    }
}
