using business.infrastructure.Entities;
using System;

namespace auth.identity
{
    public class IdentityDto
    {
        public Guid UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public IdentityDto() { }

        public IdentityDto(IUser user)
        {
            UserId = user.Id;
            Login = user.Login;
            PasswordHash = user.PasswordHash;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            FirstName = user.FirstName;
            SecondName = user.SecondName;
        }
    }
}
