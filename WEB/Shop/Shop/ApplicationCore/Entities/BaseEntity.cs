using Shop.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ApplicationCore.Entities
{
    public class BaseEntity: IAggregateRoot
    {
        public int Id { get; set; }
    }
}
