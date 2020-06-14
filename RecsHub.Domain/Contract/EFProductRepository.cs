using RecsHub.Domain.Abstract;
using RecsHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecsHub.Domain.Contract
{
    public class EFProductRepository : GenericRepository<Product>, IProductRepository
    {
        public EFProductRepository(RecsHubContext context) : base(context)
        {

        }
    }
}

