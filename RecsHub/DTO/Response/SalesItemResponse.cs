using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecsHub.DTO.Response
{
    public class SalesItemResponse
    {
        public long Id { get; set; }
        public string CompanyKey { get; set; }
        public long DiD { get; set; }
        public long SalesId { get; set; }
        public string ProdId { get; set; }
        public decimal QtySold { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SalesVat { get; set; }
        public decimal Discount { get; set; }
        public decimal SalesDiscount { get; set; }
        public decimal CostPrice { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
    }
}
