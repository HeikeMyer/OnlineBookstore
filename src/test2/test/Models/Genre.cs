using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class Genre
    {
        public Genre()
        {
            LiteraryWorkGenre = new HashSet<LiteraryWorkGenre>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<LiteraryWorkGenre> LiteraryWorkGenre { get; set; }
    }
}
