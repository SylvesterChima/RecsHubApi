using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecsHub.Domain.Entities;

namespace RecsHub.Domain.Abstract
{
    public interface IAspNetUserRepository : IGenericRepository<AspNetUser>
    {
    }
}
