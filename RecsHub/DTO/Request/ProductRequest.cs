using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecsHub.DTO.Request
{
    public class ProductRequest
    {
        public string CompanyKey { get; set; }
        public string ProdId { get; set; }
        public string ProdName { get; set; }
        public string ProdCategory { get; set; }
        public string UnitOfMeasure { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime DateEntered { get; set; }
        public string Department { get; set; }
        public decimal CostPrice { get; set; }
    }
}
