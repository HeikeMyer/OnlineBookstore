﻿using System;
using System.Collections.Generic;

namespace business.entity.Entities
{
    public partial class DataStorage
    {
        public DataStorage()
        {
            Book = new HashSet<Book>();
            LiteraryWorkSummary = new HashSet<LiteraryWorkSummary>();
        }

        public Guid Id { get; set; }
        public byte[] Data { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Book> Book { get; set; }
        public virtual ICollection<LiteraryWorkSummary> LiteraryWorkSummary { get; set; }
    }
}
