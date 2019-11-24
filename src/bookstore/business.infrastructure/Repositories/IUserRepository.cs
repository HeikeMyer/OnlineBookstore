using System;
using business.infrastructure.Entities;

namespace business.infrastructure.Repositories
{
    public interface IUserRepository
    {
        IUser GetObject(Guid id);
        IUser GetObject(string normalizedLogin);
        IUser GetObject(string normalizedLogin, string passwordHash);
        IUser Create(string login, string normalizedLogin, string passwordHash, string email, string normalizedEmail, string phoneNumber = null, string firstName = null, string secondName = null);
    }
}
