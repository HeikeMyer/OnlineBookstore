using System;
using System.Collections.Generic;
using business.infrastructure.Entities;

namespace business.infrastructure.Repositories
{
    public interface IRoleRepository
    {
        IRole GetObject(Guid id);
        IRole GetObject(string code);

        IEnumerable<IRole> GetCollection(Guid userId);
    }
}
