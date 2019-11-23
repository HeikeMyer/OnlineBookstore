using System;
using business.infrastructure.Entities;

namespace business.infrastructure.Repositories
{
    public interface IUserRepository
    {
        IUser GetObject(Guid id);
        IUser GetObject(string login);
        IUser Create(string login, string password, string email, string phoneNumber = null, string firstName = null, string secondName = null);
    }
}
