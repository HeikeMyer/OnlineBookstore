using System;
using System.Linq;
using business.entity;
using business.entity.Entities;
using business.infrastructure.Entities;
using business.infrastructure.Repositories;

namespace business.repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(EntityContext entityContext) : base(entityContext) { }

        public IUser GetObject(Guid id)
        {
            return EntityContext.User.Find(id);
        }

        public IUser GetObject(string login)
        {
            return EntityContext.User.SingleOrDefault(user => user.Login == login);
        }

        public IUser GetObject(string login, string passwordHash)
        {
            return EntityContext.User.SingleOrDefault(user => user.Login == login && user.PasswordHash == passwordHash);
        }

        public IUser Create(string login, string password, string email, string phoneNumber = null, string firstName = null, string secondName = null)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Login = login,
                PasswordHash = password,
                Email = email,
                PhoneNumber = phoneNumber,
                FirstName = firstName,
                SecondName = secondName
            };

            EntityContext.User.Add(user);
            EntityContext.SaveChanges();

            return user;
        }
    }
}
