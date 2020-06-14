using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecsHub.Domain.Entities
{
    [Table("SalesItem")]
    public partial class SalesItem
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string CompanyKey { get; set; }
        public long DiD { get; set; }
        [Column("SalesID")]
        public long SalesId { get; set; }
        [Required]
        [Column("ProdID")]
        [StringLength(32)]
        public string ProdId { get; set; }
        [Column(TypeName = "decimal(18, 14)")]
        public decimal QtySold { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; }
        [Column("SalesVAT", TypeName = "decimal(18, 2)")]
        public decimal SalesVat { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Discount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SalesDiscount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CostPrice { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
    }
}
