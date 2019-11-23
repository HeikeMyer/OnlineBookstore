using System;
using System.Collections.Generic;
using System.Text;

namespace business.infrastructure.Entities
{
    public interface IRole
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Code { get; set; }
    }
}
