using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace auth.identity.Base
{
    public abstract class BaseUserStore : IUserRoleStore<IdentityDto>, IUserPasswordStore<IdentityDto>, IUserEmailStore<IdentityDto>
    {
        public virtual void Dispose()
        {

        }

        public virtual Task AddToRoleAsync(IdentityDto user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IdentityResult> CreateAsync(IdentityDto user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IdentityResult> DeleteAsync(IdentityDto user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
      
        public virtual Task<IdentityDto> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IdentityDto> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IdentityDto> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<string> GetEmailAsync(IdentityDto user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> GetEmailConfirmedAsync(IdentityDto user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<string> GetNormalizedEmailAsync(IdentityDto user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<string> GetNormalizedUserNameAsync(IdentityDto user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<string> GetPasswordHashAsync(IdentityDto user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IList<string>> GetRolesAsync(IdentityDto user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<string> GetUserIdAsync(IdentityDto user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<string> GetUserNameAsync(IdentityDto user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IList<IdentityDto>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> HasPasswordAsync(IdentityDto user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> IsInRoleAsync(IdentityDto user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task RemoveFromRoleAsync(IdentityDto user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task SetEmailAsync(IdentityDto user, string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task SetEmailConfirmedAsync(IdentityDto user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task SetNormalizedEmailAsync(IdentityDto user, string normalizedEmail, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task SetNormalizedUserNameAsync(IdentityDto user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task SetPasswordHashAsync(IdentityDto user, string passwordHash, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task SetUserNameAsync(IdentityDto user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IdentityResult> UpdateAsync(IdentityDto user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
