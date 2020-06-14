using RecsHub.Domain.Abstract;
using RecsHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecsHub.Domain.Contract
{
    public class EFSupplyRecordRepository : GenericRepository<SupplyRecord>, ISupplyRecordRepository
    {
        public EFSupplyRecordRepository(RecsHubContext context) : base(context)
        {

        }
    }
}

