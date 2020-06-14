using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecsHub.DTO.Response
{
    public class DailyStoreRecordResponse
    {
        public long Id { get; set; }
        public string CompanyKey { get; set; }
        public string ProdId { get; set; }
        public DateTime EntryDate { get; set; }
        public decimal QtyInStore { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public decimal Rate { get; set; }
    }
}
