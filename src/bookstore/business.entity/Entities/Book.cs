using System;
using System.Collections.Generic;

namespace business.entity.Entities
{
    public partial class Book
    {
        public Book()
        {
            Item = new HashSet<Item>();
        }

        public Guid Id { get; set; }
        public Guid LiteraryWorkFk { get; set; }
        public Guid PublisherFk { get; set; }
        public int PageAmount { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public Guid UpdatedBy { get; set; }
        public bool IsSoldOut { get; set; }
        public bool IsDeleted { get; set; }

        public virtual LiteraryWork LiteraryWorkFkNavigation { get; set; }
        public virtual Publisher PublisherFkNavigation { get; set; }
        public virtual User UpdatedByNavigation { get; set; }
        public virtual ICollection<Item> Item { get; set; }
    }
}
