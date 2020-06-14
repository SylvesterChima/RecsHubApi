using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecsHub.DTO.Request
{
    public class SupplyRecordRequest
    {
        public string CompanyKey { get; set; }
        public Guid SupplyId { get; set; }
        public long SupplierId { get; set; }
        public string ProdId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitCost { get; set; }
        public DateTime SupplyDate { get; set; }
        public string EnteredBy { get; set; }
        public DateTime EntryDate { get; set; }
        public long SupId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
