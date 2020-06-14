using RecsHub.Domain.Abstract;
using RecsHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecsHub.Domain.Contract
{
    public class EFStockKeepingRepository : GenericRepository<StockKeeping>, IStockKeepingRepository
    {
        public EFStockKeepingRepository(RecsHubContext context) : base(context)
        {

        }
    }
}

