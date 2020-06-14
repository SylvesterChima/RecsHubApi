using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecsHub.Domain.Entities
{
    [Table("Supplier")]
    public partial class Supplier
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string CompanyKey { get; set; }
        [Column("SupplierID")]
        public long SupplierId { get; set; }
        [Required]
        [StringLength(120)]
        public string FullName { get; set; }
        [StringLength(150)]
        public string CompanyName { get; set; }
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        [StringLength(100)]
        public string EmailAddress { get; set; }
        [StringLength(200)]
        public string ContactAddress { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime EntryDate { get; set; }
    }
}
