using StoreHouse.API.Data.Repository.Interfaces;
using StoreHouse.API.Data.StoreHouseStorage.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreHouse.API.Data.Repository.Implementation
{
    public class StocksRepository : RepositoryBase<Stocks>, IStocksRepository
    {
        public StocksRepository(StoreHouseContext dbContext) : base(dbContext)
        {
        }
    }
}
