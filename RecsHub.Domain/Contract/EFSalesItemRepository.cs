using RecsHub.Domain.Abstract;
using RecsHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecsHub.Domain.Contract
{
    public class EFSalesItemRepository : GenericRepository<SalesItem>, ISalesItemRepository
    {
        public EFSalesItemRepository(RecsHubContext context) : base(context)
        {

        }
    }
}
