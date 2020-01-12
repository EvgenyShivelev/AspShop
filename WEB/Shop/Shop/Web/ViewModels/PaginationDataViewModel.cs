using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.ViewModels
{
    public class PaginationDataViewModel
    {
        public class PaginationInfoViewModel
        {
            public int TotalQuantityOfGoods { get; set; }
            public int GoodsPerPage { get; set; }
            public int ActualPage { get; set; }
            public int TotalPages { get; set; }
            public string Previous { get; set; }
            public string Next { get; set; }
        }
    }
}
