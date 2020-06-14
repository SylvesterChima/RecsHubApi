using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecsHub.DTO.Request
{
    public class SalesMasterRequest
    {
        public string CompanyKey { get; set; }
        public long SalesId { get; set; }
        public string CustomerId { get; set; }
        public string StaffId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountTendered { get; set; }
        public decimal Vat { get; set; }
        public decimal TotalDiscount { get; set; }
        public DateTime DateSold { get; set; }
        public string PaymentType { get; set; }
        public string Tcost { get; set; }
        public string Department { get; set; }
        public DateTime DateEntered { get; set; }
        public bool IsDeleted { get; set; }
    }
}
