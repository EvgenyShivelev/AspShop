using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Model.ValueObjects
{
    public class PreOrderedItem
    {
        public PreOrderedItem(int catalogItemId, string productName, string pictureUri)
        {
            GoodsId = catalogItemId;
            ProductName = productName;
            PictureUri = pictureUri;
        }

        private PreOrderedItem()
        {
        }

        public int GoodsId { get; private set; }
        public string ProductName { get; private set; }
        public string PictureUri { get; private set; }
    }
}
