﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecsHub.DTO.Request
{
    public class SupplierRequest
    {
        public string CompanyKey { get; set; }
        public long SupplierId { get; set; }
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string ContactAddress { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
