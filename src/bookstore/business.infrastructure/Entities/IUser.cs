﻿using System;

namespace business.infrastructure.Interfaces
{
    public interface IUser
    {
        Guid Id { get; set; }
        string Login { get; set; }
        string Password { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string FirstName { get; set; }
        string SecondName { get; set; }
    }
}
