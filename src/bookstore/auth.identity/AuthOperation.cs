using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace auth.identity
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

        public void Create()
        {
            var dto = new IdentityDto
            {
                Login = "cat.cat999",
                Email = "cattt888@gmail.com",
                FirstName = "Cat",
                SecondName = "Fluffy"
            };

            var a = UserManager.CreateAsync(dto, "fsdd88koo0_Kbcn");
            var b = a.Result;
        }

        public void Test()
        {
            var p = "ptktYsq678_Kbcn";
            

            var dto = new IdentityDto
            {
                Login = "heike.myer",
                Email = "abcd832@gmail.com",
                FirstName = "Heike",
                SecondName = "Myer"
            };

            var h = UserManager.PasswordHasher.HashPassword(dto, p);
            dto.PasswordHash = h;

            //var b = SignInManager.CanSignInAsync(dto);
            var a = SignInManager.SignInAsync(dto, false);


            int c = 56;
        }
    }
}
