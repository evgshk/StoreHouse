using StoreHouse.API.Models.Stocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreHouse.API.Models.Warehouses
{
    public class WarehouseItemModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Adress { get; set; }
        public string Name { get; set; }
        public List<StockItemModel> Stocks { get; set; }
    }
}
