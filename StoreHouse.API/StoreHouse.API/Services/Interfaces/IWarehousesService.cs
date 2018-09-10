using StoreHouse.API.Models.Warehouses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreHouse.API.Services.Interfaces
{
    public interface IWarehousesService
    {
        Task<WarehouseItemModel> GetItem(Guid id);
        Task<WarehouseListModel> GetItems();
        Task<bool> PossibleToTransactFrom(Guid warehouseId, Guid productId, int value);
    }
}
