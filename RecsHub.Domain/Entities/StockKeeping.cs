﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecsHub.Domain.Entities
{
    [Table("StockKeeping")]
    public partial class StockKeeping
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
        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? OpeningStock { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ClosingStock { get; set; }
    }
}
