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

        public IUser GetObject(string normalizedLogin)
        {
            return EntityContext.User.SingleOrDefault(user => user.NormalizedLogin == normalizedLogin);
        }

        public IUser GetObject(string normalizedLogin, string passwordHash)
        {
            return EntityContext.User.SingleOrDefault(user => user.NormalizedLogin == normalizedLogin && user.PasswordHash == passwordHash);
        }

        public IUser Create(string login, string normalizedLogin, string password, string email, string normalizedEmail, string phoneNumber = null, string firstName = null, string secondName = null)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Login = login,
                NormalizedLogin = normalizedLogin,
                PasswordHash = password,
                Email = email,
                NormalizedEmail = normalizedEmail,
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
