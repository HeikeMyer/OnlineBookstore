using business.infrastructure.Entities;

namespace business.infrastructure.Operations
{
    public interface IUserOperation
    {
        IUser CurrentUser { get; }
        void SignIn(IUser user);
    }
}
