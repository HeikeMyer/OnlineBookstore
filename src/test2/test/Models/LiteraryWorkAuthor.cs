using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class LiteraryWorkAuthor
    {
        public Guid Id { get; set; }
        public Guid? LiteraryWorkFk { get; set; }
        public Guid? AuthorFk { get; set; }

        public virtual Author AuthorFkNavigation { get; set; }
        public virtual LiteraryWork LiteraryWorkFkNavigation { get; set; }
    }
}
