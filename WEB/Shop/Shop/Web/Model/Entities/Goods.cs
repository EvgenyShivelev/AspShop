using Shop.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Model.Entities
{
    public class Goods: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUri { get; set; }
        public int GoodsTypeId { get; set; }
        public GoodsType CatalogType { get; set; }
        public int GoodsBrandId { get; set; }
        public GoodsBrand CatalogBrand { get; set; }
    }
}
