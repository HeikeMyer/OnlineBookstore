using business.entity.Entities;
using business.infrastructure.Entities;
using business.infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace business.repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(EntityContext entityContext) : base(entityContext) { }

        public string Hello()
        {
            return "Hi, dude!";
        }
        public IUser GetObject(Guid id)
        {
            var a = EntityContext.User.SingleOrDefault(u => u.Id == id);

            return a;
        }

        public void Add(IUser user)
        {
            var a = user as User;
            EntityContext.User.Add(a);
            EntityContext.SaveChanges();
        }
    }
}
