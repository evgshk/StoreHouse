using StoreHouse.API.Models.Products;
using StoreHouse.API.Models.Warehouses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreHouse.API.Models.Documents
{
    public class DocumentAddItemModel: DocumentItemModel
    {
        public List<WarehouseItemModel> WarehouseFromDdl { get; set; }
        public List<WarehouseItemModel> WarehouseToDdl { get; set; }
        public List<ProductItemModel> ProductDdl { get; set; }
    }
}
