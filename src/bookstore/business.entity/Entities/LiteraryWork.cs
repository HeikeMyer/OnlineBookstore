using System;
using System.Collections.Generic;

namespace business.entity.Entities
{
    public partial class LiteraryWork
    {
        public LiteraryWork()
        {
            Book = new HashSet<Book>();
            LiteraryWorkAuthor = new HashSet<LiteraryWorkAuthor>();
            LiteraryWorkGenre = new HashSet<LiteraryWorkGenre>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? YearWritten { get; set; }
        public Guid? LiteraryWorkSummaryFk { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsDeleted { get; set; }

        public virtual LiteraryWorkSummary LiteraryWorkSummaryFkNavigation { get; set; }
        public virtual User UpdatedByNavigation { get; set; }
        public virtual ICollection<Book> Book { get; set; }
        public virtual ICollection<LiteraryWorkAuthor> LiteraryWorkAuthor { get; set; }
        public virtual ICollection<LiteraryWorkGenre> LiteraryWorkGenre { get; set; }
    }
}
