using Shop.ApplicationCore.Entities;
using Shop.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Model.Entities
{
    public class GoodsBrand: BaseEntity
    {
        public string Brand { get; set; }
    }
}
