using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecsHub.Domain.Entities
{
    [Table("SalesMaster")]
    public partial class SalesMaster
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string CompanyKey { get; set; }
        [Column("SalesID")]
        public long SalesId { get; set; }
        [Required]
        [Column("CustomerID")]
        [StringLength(15)]
        public string CustomerId { get; set; }
        [Required]
        [Column("StaffID")]
        [StringLength(20)]
        public string StaffId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal AmountTendered { get; set; }
        [Column("VAT", TypeName = "decimal(18, 2)")]
        public decimal Vat { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalDiscount { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateSold { get; set; }
        [Required]
        [StringLength(10)]
        public string PaymentType { get; set; }
        [Required]
        [Column("TCost")]
        [StringLength(2)]
        public string Tcost { get; set; }
        [Required]
        [StringLength(50)]
        public string Department { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateEntered { get; set; }
        public bool IsDeleted { get; set; }
    }
}
