using System;
using System.Collections.Generic;

namespace business.entity.Entities
{
    public partial class User
    {
        public User()
        {
            Address = new HashSet<Address>();
            Basket = new HashSet<Basket>();
            Book = new HashSet<Book>();
            Item = new HashSet<Item>();
            LiteraryWork = new HashSet<LiteraryWork>();
            LiteraryWorkSummary = new HashSet<LiteraryWorkSummary>();
            LoginActivity = new HashSet<LoginActivity>();
            Notification = new HashSet<Notification>();
            Payment = new HashSet<Payment>();
            Purchase = new HashSet<Purchase>();
            UserRoleUpdatedByNavigation = new HashSet<UserRole>();
            UserRoleUserFkNavigation = new HashSet<UserRole>();
        }

        public Guid Id { get; set; }
        public string Login { get; set; }
        public string NormalizedLogin { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public bool IsBlocked { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Basket> Basket { get; set; }
        public virtual ICollection<Book> Book { get; set; }
        public virtual ICollection<Item> Item { get; set; }
        public virtual ICollection<LiteraryWork> LiteraryWork { get; set; }
        public virtual ICollection<LiteraryWorkSummary> LiteraryWorkSummary { get; set; }
        public virtual ICollection<LoginActivity> LoginActivity { get; set; }
        public virtual ICollection<Notification> Notification { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<Purchase> Purchase { get; set; }
        public virtual ICollection<UserRole> UserRoleUpdatedByNavigation { get; set; }
        public virtual ICollection<UserRole> UserRoleUserFkNavigation { get; set; }
    }
}
