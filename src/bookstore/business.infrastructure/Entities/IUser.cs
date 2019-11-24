using System;

namespace business.infrastructure.Entities
{
    public interface IUser
    {
        Guid Id { get; set; }
        string Login { get; set; }
        string PasswordHash { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string FirstName { get; set; }
        string SecondName { get; set; }
    }
}
