using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecsHub.Domain.Abstract;
using RecsHub.Domain.Entities;

namespace RecsHub.Domain.Contract
{
    public class EFAspNetUserRepository : GenericRepository<AspNetUser>, IAspNetUserRepository
    {
        public EFAspNetUserRepository(RecsHubContext context) : base(context)
        {

        }
    }
}
