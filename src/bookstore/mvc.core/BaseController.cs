using business.infrastructure.Entities;
using business.infrastructure.Operations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace mvc.core
{
    public class BaseController : Controller
    {
        #region [ Dependency -> Operations ]

        protected IUserOperation UserOperation { get; set; }

        #endregion
        public IUser CurrentUser => UserOperation.CurrentUser;

        public BaseController(IUserOperation userOperation)
        {
            UserOperation = userOperation;
        }
    }
}
