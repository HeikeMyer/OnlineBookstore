using System;
using System.Collections.Generic;

namespace test.Models
{
    public partial class User
    {
        public User()
        {
            Address = new HashSet<Address>();
        }

        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public virtual ICollection<Address> Address { get; set; }
    }
}
