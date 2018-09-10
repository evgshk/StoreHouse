using StoreHouse.API.Models.Products;
using StoreHouse.API.Models.Warehouses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreHouse.API.Models.Stocks
{
    public class StockItemModel
    {
        public int Id { get; set; }
        public WarehouseItemModel Warehouse { get;set; }
        public ProductItemModel Product { get; set; }
        public int Value { get; set; }
    }
}
