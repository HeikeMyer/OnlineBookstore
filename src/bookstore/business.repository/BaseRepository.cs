using business.entity;

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
