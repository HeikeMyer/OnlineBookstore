﻿using System;
using System.Collections.Generic;

namespace business.entity.Entities
{
    public partial class LiteraryWorkGenre
    {
        public Guid Id { get; set; }
        public Guid LiteraryWorkFk { get; set; }
        public Guid GenreFk { get; set; }

        public virtual Genre GenreFkNavigation { get; set; }
        public virtual LiteraryWork LiteraryWorkFkNavigation { get; set; }
    }
}
