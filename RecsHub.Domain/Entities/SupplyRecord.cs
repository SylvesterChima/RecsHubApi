using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecsHub.Domain.Entities
{
    [Table("SupplyRecord")]
    public partial class SupplyRecord
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string CompanyKey { get; set; }
        [Column("SupplyID")]
        public Guid SupplyId { get; set; }
        [Column("SupplierID")]
        public long SupplierId { get; set; }
        [Required]
        [Column("ProdID")]
        [StringLength(32)]
        public string ProdId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Quantity { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitCost { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime SupplyDate { get; set; }
        [Required]
        [StringLength(20)]
        public string EnteredBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EntryDate { get; set; }
        [Column("SupID")]
        public long SupId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
