using business.infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace business.repository
{
    public class UserRepository: IUserRepository
    {
        public string Hello()
        {
            return "Hi, dude!";
        }
    }
}
