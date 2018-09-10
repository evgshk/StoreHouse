using StoreHouse.API.Data.Repository.Interfaces;
using StoreHouse.API.Data.StoreHouseStorage.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreHouse.API.Data.Repository.Implementation
{
    public class ProductsRepository : RepositoryBase<Products>, IProductsRepository
    {
        public ProductsRepository(StoreHouseContext dbContext) : base(dbContext)
        {
        }
    }
}
