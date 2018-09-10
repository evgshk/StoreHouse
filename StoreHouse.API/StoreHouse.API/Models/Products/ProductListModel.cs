using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreHouse.API.Models.Products
{
    public class ProductListModel
    {
        public List<ProductItemModel> Items { get; set; }
        //Additional info used to implement pagination in future
        public int Skipped { get; set; }
        public int Taken { get; set; }
        public int OverallCount { get; set; }
    }
}
