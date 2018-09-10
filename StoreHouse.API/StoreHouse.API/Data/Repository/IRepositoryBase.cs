using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreHouse.API.Data.Repository
{
    public interface IRepositoryBase<T> where T: class
    {
        IQueryable<T> GetItems();
        Task<T> GetItemByid(Guid id);

        void SaveChanges();
    }
}
