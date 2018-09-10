using StoreHouse.API.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreHouse.API.Services.Interfaces
{
    public interface IProductsService
    {
        Task<ProductItemModel> GetItem(Guid id);
        Task<ProductListModel> GetItems();
    }
}
