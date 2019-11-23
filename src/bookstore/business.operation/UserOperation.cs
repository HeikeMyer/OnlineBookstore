using business.infrastructure.Operations;
using business.infrastructure.Repositories;
using System;

namespace business.operation
{
    public class UserOperation : IUserOperation
    {
        #region [ Dependencies ]
        private IUserRepository UserRepository { get; set; }
        public UserOperation(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }
        #endregion
        public string Hi()
        {
            var u = UserRepository.GetObject(Guid.Parse("0E9AD9FA-DAC7-4D17-A244-C6B2B19D9081"));

            var a = UserRepository.Hello();
            return "Helo ms " + a;
        }
    }
}
