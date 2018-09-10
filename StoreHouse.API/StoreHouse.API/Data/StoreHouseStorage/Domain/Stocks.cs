using System;
using System.Collections.Generic;

namespace StoreHouse.API.Data.StoreHouseStorage.Domain
{
    public partial class Stocks
    {
        public int Id { get; set; }
        public Guid? ProductId { get; set; }
        public int? Value { get; set; }
        public Guid? WarehouseId { get; set; }

        public virtual Products Product { get; set; }
        public virtual Warehouses Warehouse { get; set; }
    }
}
