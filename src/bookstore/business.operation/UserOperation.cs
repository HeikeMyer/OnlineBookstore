using business.infrastructure.Operations;
using business.infrastructure.Repositories;
using System;

namespace business.operation
{
    public class UserOperation: IUserOperation
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
            var a = UserRepository.Hello();
            return "Helo ms " + a;
        }
    }
}
