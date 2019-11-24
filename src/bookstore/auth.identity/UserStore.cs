using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using business.infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;

namespace auth.identity
{
    public class UserStore : IUserRoleStore<IdentityDto>, IUserPasswordStore<IdentityDto>, IUserEmailStore<IdentityDto>
    {
        #region [ Dependencies ]

        private IUserRepository UserRepository { get; set; }

        public UserStore(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        #endregion

        private Task DefaultResult => Task.FromResult<object>(null);

        public Task<IdentityResult> CreateAsync(IdentityDto identityDto, CancellationToken cancellationToken)
        {
            UserRepository.Create(identityDto.Login, identityDto.PasswordHash, identityDto.Email, identityDto.PhoneNumber, identityDto.FirstName, identityDto.SecondName);
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(IdentityDto user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public Task<IdentityDto> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityDto> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityDto> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            var user = UserRepository.GetObject(normalizedUserName);
            return Task.FromResult(user != null ? new IdentityDto(user) : null);     
        }

        public Task<string> GetEmailAsync(IdentityDto identityDto, CancellationToken cancellationToken)
        {
            return Task.FromResult(identityDto.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(IdentityDto user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedEmailAsync(IdentityDto user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNormalizedUserNameAsync(IdentityDto user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(IdentityDto user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserIdAsync(IdentityDto identityDto, CancellationToken cancellationToken)
        {
            var user = UserRepository.GetObject(identityDto.Login, identityDto.PasswordHash);
            //return Task.FromResult(identityDto.UserId.ToString());
            return Task.FromResult(user?.Id.ToString());
        }

        public Task<string> GetUserNameAsync(IdentityDto identityDto, CancellationToken cancellationToken)
        {
            return Task.FromResult(identityDto.Login);
        }

        public Task<bool> HasPasswordAsync(IdentityDto user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(IdentityDto user, string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(IdentityDto user, bool confirmed, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetNormalizedEmailAsync(IdentityDto identityDto, string normalizedEmail, CancellationToken cancellationToken)
        {
            //identityDto.Email = normalizedEmail;
            return DefaultResult;
        }

        public Task SetNormalizedUserNameAsync(IdentityDto identityDto, string normalizedName, CancellationToken cancellationToken)
        {
            //identityDto.Login = normalizedName;
            return DefaultResult;
        }

        public Task SetPasswordHashAsync(IdentityDto identityDto, string passwordHash, CancellationToken cancellationToken)
        {
            identityDto.PasswordHash = passwordHash;
            return DefaultResult;
        }

        public Task SetUserNameAsync(IdentityDto user, string userName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(IdentityDto user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task AddToRoleAsync(IdentityDto user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromRoleAsync(IdentityDto user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(IdentityDto user, CancellationToken cancellationToken)
        {
            IList<string> roles = new[] { string.Empty };
            return Task.FromResult(roles);
        }

        public Task<bool> IsInRoleAsync(IdentityDto user, string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IList<IdentityDto>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
