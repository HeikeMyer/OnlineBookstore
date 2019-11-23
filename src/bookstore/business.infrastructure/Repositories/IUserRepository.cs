using System;
using business.infrastructure.Entities;

namespace business.infrastructure.Repositories
{
    public interface IUserRepository
    {
        IUser GetObject(Guid id);
    }
}
