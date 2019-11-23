using business.infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.infrastructure.Repositories
{
    public interface IUserRepository
    {
        string Hello();
        IUser GetObject(Guid id);

        void Add(IUser user);
    }
}
