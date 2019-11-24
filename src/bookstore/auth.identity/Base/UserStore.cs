using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using business.infrastructure.Repositories;

namespace auth.identity.Base
{
    public class UserStore : BaseUserStore
    {
        #region [ Dependencies ]

        private IUserRepository UserRepository { get; set; }

        public UserStore(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        #endregion
        
        public override Task<IdentityResult> CreateAsync(IdentityDto dto, CancellationToken cancellationToken)
        {
            UserRepository.Create(dto.Login, dto.NormalizedLogin, dto.PasswordHash, dto.Email, dto.NormalizedEmail, dto.PhoneNumber, dto.FirstName, dto.SecondName);
            return Task.FromResult(IdentityResult.Success);
        }

        public override Task<IdentityDto> FindByNameAsync(string normalizedLogin, CancellationToken cancellationToken)
        {
            var user = UserRepository.GetObject(normalizedLogin);
            return Task.FromResult(user != null ? new IdentityDto(user) : null);     
        }

        public override Task<string> GetEmailAsync(IdentityDto identityDto, CancellationToken cancellationToken)
        {
            return Task.FromResult(identityDto.Email);
        }

        public override Task<string> GetUserIdAsync(IdentityDto identityDto, CancellationToken cancellationToken)
        {
            var user = UserRepository.GetObject(identityDto.NormalizedLogin, identityDto.PasswordHash);
            return Task.FromResult(user?.Id.ToString());
        }

        public override Task<string> GetUserNameAsync(IdentityDto identityDto, CancellationToken cancellationToken)
        {
            return Task.FromResult(identityDto.Login);
        }

        public override Task SetNormalizedEmailAsync(IdentityDto identityDto, string normalizedEmail, CancellationToken cancellationToken)
        {
            return Task.FromResult(identityDto.NormalizedEmail = normalizedEmail);
        }

        public override Task SetNormalizedUserNameAsync(IdentityDto identityDto, string normalizedLogin, CancellationToken cancellationToken)
        {
            return Task.FromResult(identityDto.NormalizedLogin = normalizedLogin);
        }

        public override Task SetPasswordHashAsync(IdentityDto identityDto, string passwordHash, CancellationToken cancellationToken)
        {
            return Task.FromResult(identityDto.PasswordHash = passwordHash);
        }
     
        public override Task<IList<string>> GetRolesAsync(IdentityDto user, CancellationToken cancellationToken)
        {
            return Task.FromResult((IList<string>)new[] { string.Empty });
        }
    }
}
