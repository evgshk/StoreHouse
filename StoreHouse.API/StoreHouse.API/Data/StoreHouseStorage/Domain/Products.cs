using System;
using System.Collections.Generic;

namespace StoreHouse.API.Data.StoreHouseStorage.Domain
{
    public partial class Products
    {
        public Products()
        {
            Documents = new HashSet<Documents>();
            Stocks = new HashSet<Stocks>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Documents> Documents { get; set; }
        public virtual ICollection<Stocks> Stocks { get; set; }
    }
}
