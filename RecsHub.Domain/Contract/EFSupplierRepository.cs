using RecsHub.Domain.Abstract;
using RecsHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecsHub.Domain.Contract
{
    public class EFSupplierRepository : GenericRepository<Supplier>, ISupplierRepository
    {
        public EFSupplierRepository(RecsHubContext context) : base(context)
        {

        }
    }
}
