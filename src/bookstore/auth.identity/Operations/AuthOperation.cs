using Microsoft.AspNetCore.Identity;
using auth.identity.Base;
using auth.identity.Interfaces;

namespace auth.identity.Operations
{
    public class AuthOperation : IAuthOperation
    {
        #region [ Dependencies ]

        private SignInManager<IdentityDto> SignInManager { get; set; }
        private UserManager<IdentityDto> UserManager { get; set; }

        public AuthOperation(SignInManager<IdentityDto> signInManager, UserManager<IdentityDto> userManager)
        {
            SignInManager = signInManager;
            UserManager = userManager;
        }

        #endregion
        public bool Create(string login, string email, string password, string phoneNumber = null, string firstName = null, string secondName = null)
        {
            var identityDto = new IdentityDto
            {
                Login = login,
                Email = email,
                PhoneNumber = phoneNumber,
                FirstName = firstName,
                SecondName = secondName
            };

            var result = UserManager.CreateAsync(identityDto, password);

            return result.Result == IdentityResult.Success;
        }
    }
}
