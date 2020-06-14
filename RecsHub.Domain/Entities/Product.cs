using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecsHub.Domain.Entities
{
    [Table("Product")]
    public partial class Product
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string CompanyKey { get; set; }
        [Required]
        [Column("ProdID")]
        [StringLength(32)]
        public string ProdId { get; set; }
        [Required]
        [StringLength(60)]
        public string ProdName { get; set; }
        [Required]
        [StringLength(30)]
        public string ProdCategory { get; set; }
        [Required]
        [StringLength(10)]
        public string UnitOfMeasure { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Discount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DiscountAmount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateEntered { get; set; }
        [Required]
        [StringLength(50)]
        public string Department { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CostPrice { get; set; }
    }
}
