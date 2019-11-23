using business.entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.repository
{
    public class BaseRepository
    {
        protected EntityContext EntityContext { get; set; }
        public BaseRepository(EntityContext entityContext)
        {
            EntityContext = entityContext;
        }
    }
}
