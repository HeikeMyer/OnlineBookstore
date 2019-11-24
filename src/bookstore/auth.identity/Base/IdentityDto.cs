using System;
using business.infrastructure.Entities;

namespace auth.identity.Base
{
    public class IdentityDto
    {
        public Guid UserId { get; set; }
        public string Login { get; set; }
        public string NormalizedLogin { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public IdentityDto() { }

        public IdentityDto(IUser user)
        {
            UserId = user.Id;
            Login = user.Login;
            NormalizedLogin = user.NormalizedLogin;
            PasswordHash = user.PasswordHash;
            Email = user.Email;
            NormalizedEmail = user.NormalizedEmail;
            PhoneNumber = user.PhoneNumber;
            FirstName = user.FirstName;
            SecondName = user.SecondName;
        }
    }
}
