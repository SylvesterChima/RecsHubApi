﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecsHub.DTO.Request
{
    public class StockKeepingRequest
    {
        public string CompanyKey { get; set; }
        public string ProdId { get; set; }
        public DateTime Date { get; set; }
        public decimal? OpeningStock { get; set; }
        public decimal? ClosingStock { get; set; }
    }
}
