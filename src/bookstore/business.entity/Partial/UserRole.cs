using business.infrastructure.Entities;

namespace business.entity.Entities
{
    public partial class UserRole : IUserRole
    {
        public IUser User 
        { 
            get => UserFkNavigation;
            set => UserFkNavigation = value as User; 
        }
        public IRole Role
        { 
            get => RoleFkNavigation; 
            set => RoleFkNavigation = value as Role; 
        }
    }
}
