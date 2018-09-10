using StoreHouse.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreHouse.API.Models.Products;
using StoreHouse.API.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace StoreHouse.API.Services.Implementation
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepo;

        public ProductsService(IProductsRepository productsRepo)
        {
            this._productsRepo = productsRepo;
        }

        public async Task<ProductItemModel> GetItem(Guid id)
        {
            var item = await _productsRepo.GetItemByid(id);

            return new ProductItemModel
            {
                Id = item.Id,
                Name = item.Name ?? String.Empty,
                Code = item.Code ?? String.Empty,
                Description = item.Description ?? String.Empty
            };
        }

        public async Task<ProductListModel> GetItems()
        {
            var data = await _productsRepo.GetItems()
                //.Skip(0).Take(10)
                .ToListAsync();

            return new ProductListModel
            {
                Items = data.Select(x => new ProductItemModel
                {
                    Id = x.Id,
                    Name = x.Name ?? String.Empty,
                    Code = x.Code ?? String.Empty,
                    Description = x.Description ?? String.Empty
                }).ToList()
            };
        }
    }
}
