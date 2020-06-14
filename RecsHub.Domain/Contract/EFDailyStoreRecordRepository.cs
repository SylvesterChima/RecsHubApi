using RecsHub.Domain.Abstract;
using RecsHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecsHub.Domain.Contract
{
    public class EFDailyStoreRecordRepository : GenericRepository<DailyStoreRecord>, IDailyStoreRecordRepository
    {
        public EFDailyStoreRecordRepository(RecsHubContext context) : base(context)
        {

        }
    }
}

