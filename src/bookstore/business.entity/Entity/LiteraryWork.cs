using System;
using System.Collections.Generic;

namespace business.entity.Entity
{
    public partial class LiteraryWork
    {
        public LiteraryWork()
        {
            LiteraryWorkAuthor = new HashSet<LiteraryWorkAuthor>();
            LiteraryWorkGenre = new HashSet<LiteraryWorkGenre>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? YearWritten { get; set; }

        public virtual ICollection<LiteraryWorkAuthor> LiteraryWorkAuthor { get; set; }
        public virtual ICollection<LiteraryWorkGenre> LiteraryWorkGenre { get; set; }
    }
}
