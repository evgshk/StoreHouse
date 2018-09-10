using StoreHouse.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreHouse.API.Models.Warehouses;
using StoreHouse.API.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using StoreHouse.API.Models.Stocks;
using StoreHouse.API.Models.Products;

namespace StoreHouse.API.Services.Implementation
{
    public class WarehousesService : IWarehousesService
    {
        private readonly IWarehousesRepository _warehousesRepo;

        public WarehousesService(IWarehousesRepository warehousesRepo)
        {
            this._warehousesRepo = warehousesRepo;
        }

        public async Task<WarehouseItemModel> GetItem(Guid id)
        {
            var item = await _warehousesRepo.GetItemByid(id);

            return new WarehouseItemModel
            {
                Id = item.Id,
                Name = item.Name ?? String.Empty,
                Code = item.Code ?? String.Empty,
                Adress = item.Adress ?? String.Empty,
                Stocks = item.Stocks.Select(x => new StockItemModel
                {
                    Product = new ProductItemModel
                    {
                        Id = (Guid)x.ProductId,
                        Name = x.Product.Name
                    },
                    Value = (int)x.Value
                }).ToList()
            };
        }

        public async Task<WarehouseListModel> GetItems()
        {
            var data = await _warehousesRepo.GetItems()
                .ToListAsync();

            return new WarehouseListModel
            {
                Items = data.Select(x => new WarehouseItemModel
                {
                    Id = x.Id,
                    Name = x.Name ?? String.Empty,
                    Code = x.Code ?? String.Empty,
                    Adress = x.Adress ?? String.Empty
                }).ToList()
            };
        }

        /// <summary>
        /// Checks availability to ship from a given Warehouse. 
        /// If remainder of goods greater than requested value returns true.
        /// </summary>
        /// <param name="warehouseId"></param>
        /// <param name="productId"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<bool> PossibleToTransactFrom(Guid warehouseId, Guid productId, int value)
        {
            var warehouse = await _warehousesRepo.GetItemByid(warehouseId);

            var remainderOfGoods = warehouse.Stocks
                .SingleOrDefault(x => x.ProductId.Equals(productId)).Value;

            return remainderOfGoods > value;
        }
    }
}
