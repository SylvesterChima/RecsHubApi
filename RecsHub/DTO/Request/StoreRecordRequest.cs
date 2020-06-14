using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecsHub.DTO.Request
{
    public class StoreRecordRequest
    {
        public string CompanyKey { get; set; }
        public string ProdId { get; set; }
        public decimal QtyInStore { get; set; }
        public DateTime LastUpdate { get; set; }
        public string AddedBy { get; set; }
    }
}
