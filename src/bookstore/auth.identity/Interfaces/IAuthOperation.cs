namespace auth.identity.Interfaces
{
    public interface IAuthOperation
    {
        bool Create(string login, string email, string password, string phoneNumber = null, string firstName = null, string secondName = null);
    }
}
