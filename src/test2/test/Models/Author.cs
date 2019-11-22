﻿using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class Author
    {
        public Author()
        {
            LiteraryWorkAuthor = new HashSet<LiteraryWorkAuthor>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<LiteraryWorkAuthor> LiteraryWorkAuthor { get; set; }
    }
}
