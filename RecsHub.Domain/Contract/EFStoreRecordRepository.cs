using RecsHub.Domain.Abstract;
using RecsHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecsHub.Domain.Contract
{
    public class EFStoreRecordRepository : GenericRepository<StoreRecord>, IStoreRecordRepository
    {
        public EFStoreRecordRepository(RecsHubContext context) : base(context)
        {

        }
    }
}

