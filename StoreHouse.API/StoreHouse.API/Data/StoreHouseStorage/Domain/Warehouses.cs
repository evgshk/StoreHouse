using System;
using System.Collections.Generic;

namespace StoreHouse.API.Data.StoreHouseStorage.Domain
{
    public partial class Warehouses
    {
        public Warehouses()
        {
            DocumentsWarehouseFromNavigation = new HashSet<Documents>();
            DocumentsWarehouseToNavigation = new HashSet<Documents>();
            Stocks = new HashSet<Stocks>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Adress { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Documents> DocumentsWarehouseFromNavigation { get; set; }
        public virtual ICollection<Documents> DocumentsWarehouseToNavigation { get; set; }
        public virtual ICollection<Stocks> Stocks { get; set; }
    }
}
