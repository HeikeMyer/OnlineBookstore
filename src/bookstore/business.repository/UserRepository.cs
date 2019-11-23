using System;
using System.Linq;
using business.entity;
using business.infrastructure.Entities;
using business.infrastructure.Repositories;

namespace business.repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(EntityContext entityContext) : base(entityContext) { }

        public IUser GetObject(Guid id)
        {
            return EntityContext.User.SingleOrDefault(u => u.Id == id);
        }
    }
}
