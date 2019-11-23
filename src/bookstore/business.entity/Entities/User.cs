using System;
using System.Collections.Generic;

namespace business.entity.Entities
{
    public partial class User
    {
        public User()
        {
            Address = new HashSet<Address>();
            UserRole = new HashSet<UserRole>();
        }

        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
