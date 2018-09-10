using StoreHouse.API.Models.Products;
using StoreHouse.API.Models.Warehouses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreHouse.API.Models.Documents
{
    public class DocumentItemModel
    {
        public Guid Id { get; set; }
        public WarehouseItemModel WarehouseFrom { get; set; }
        public WarehouseItemModel WarehouseTo { get; set; }
        public ProductItemModel Product { get; set; }
        public int Value { get; set; }
    }
}
