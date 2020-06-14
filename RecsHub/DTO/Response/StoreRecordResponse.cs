using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecsHub.DTO.Response
{
    public class StoreRecordResponse
    {
        public long Id { get; set; }
        public string CompanyKey { get; set; }
        public string ProdId { get; set; }
        public decimal QtyInStore { get; set; }
        public DateTime LastUpdate { get; set; }
        public string AddedBy { get; set; }
    }
}
