using System;
using System.Collections.Generic;

namespace StoreHouse.API.Data.StoreHouseStorage.Domain
{
    public partial class Documents
    {
        public Guid Id { get; set; }
        public Guid? StockId { get; set; }
        public Guid? WarehouseFrom { get; set; }
        public Guid? WarehouseTo { get; set; }
        public int? Value { get; set; }

        public virtual Products Stock { get; set; }
        public virtual Warehouses WarehouseFromNavigation { get; set; }
        public virtual Warehouses WarehouseToNavigation { get; set; }
    }
}
