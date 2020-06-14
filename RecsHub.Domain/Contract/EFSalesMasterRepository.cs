using RecsHub.Domain.Abstract;
using RecsHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecsHub.Domain.Contract
{
    public class EFSalesMasterRepository : GenericRepository<SalesMaster>, ISalesMasterRepository
    {
        public EFSalesMasterRepository(RecsHubContext context) : base(context)
        {

        }
    }
}

