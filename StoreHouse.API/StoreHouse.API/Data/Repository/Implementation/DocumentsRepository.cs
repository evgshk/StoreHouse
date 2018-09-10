using Microsoft.EntityFrameworkCore;
using StoreHouse.API.Data.Repository.Interfaces;
using StoreHouse.API.Data.StoreHouseStorage.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreHouse.API.Data.Repository.Implementation
{
    public class DocumentsRepository : RepositoryBase<Documents>, IDocumentsRepository
    {
        public DocumentsRepository(StoreHouseContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Documents> GetItems()
        {
            return DbSet.Include(x => x.WarehouseFromNavigation)
                .Include(x => x.WarehouseToNavigation)
                .Include(x => x.Stock);
        }

        public async override Task<Documents> GetItemByid(Guid id)
        {
            return await DbSet.Include(x => x.WarehouseFromNavigation)
                .Include(x => x.WarehouseToNavigation)
                .Include(x => x.Stock)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Add(Documents entity)
        {
            DbSet.Add(entity);
        }
    }
}
