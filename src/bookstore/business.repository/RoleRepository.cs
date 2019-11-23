using System;
using System.Collections.Generic;
using System.Linq;
using business.entity;
using business.infrastructure.Entities;
using business.infrastructure.Repositories;

namespace business.repository
{
    public class RoleRepository : BaseRepository, IRoleRepository
    {
        public RoleRepository(EntityContext entityContext) : base(entityContext) { }

        public IRole GetObject(Guid id)
        {
            return EntityContext.Role.Find(id);
        }

        public IRole GetObject(string code)
        {
            return EntityContext.Role.SingleOrDefault(role => role.Code == code);
        }

        public IEnumerable<IRole> GetCollection(Guid userId)
        {
            var collection =
                from role in EntityContext.Role
                join userRole in EntityContext.UserRole on role.Id equals userRole.RoleFk
                where userRole.UserFk == userId
                select role;

            return collection.AsEnumerable();
        }
    }
}
