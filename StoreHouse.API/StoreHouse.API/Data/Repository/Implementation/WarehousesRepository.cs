using Microsoft.EntityFrameworkCore;
using StoreHouse.API.Data.Repository.Interfaces;
using StoreHouse.API.Data.StoreHouseStorage.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreHouse.API.Data.Repository.Implementation
{
    public class WarehousesRepository : RepositoryBase<Warehouses>, IWarehousesRepository
    {
        public WarehousesRepository(StoreHouseContext dbContext) : base(dbContext)
        {
        }

        public async override Task<Warehouses> GetItemByid(Guid id)
        {
            return await DbSet.Include(x => x.Stocks).ThenInclude(y => y.Product)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
               
    }
}
