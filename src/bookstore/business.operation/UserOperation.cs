using business.infrastructure.Entities;
using business.infrastructure.Operations;

namespace business.operation
{
    public class UserOperation : IUserOperation
    {      
        public IUser CurrentUser { get; set; }

        public void SignIn(IUser user)
        {
            CurrentUser = user;
        }
    }
}
