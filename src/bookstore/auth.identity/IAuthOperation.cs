using System;
using System.Collections.Generic;
using System.Text;

namespace auth.identity
{
    public interface IAuthOperation
    {
        void Create();
        void Test();
    }
}
