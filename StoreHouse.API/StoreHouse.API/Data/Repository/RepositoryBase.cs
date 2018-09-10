using Microsoft.EntityFrameworkCore;
using StoreHouse.API.Data.StoreHouseStorage.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreHouse.API.Data.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly StoreHouseContext _dbContext;
        protected readonly DbSet<T> DbSet;

        protected RepositoryBase(StoreHouseContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<T>();
        }

        public virtual Task<T> GetItemByid(Guid id)
        {
            return DbSet.FindAsync(id);
        }

        public virtual IQueryable<T> GetItems()
        {
            return DbSet;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
