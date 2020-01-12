using Shop.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ApplicationCore.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T item);
        T GetById(int id);
        IEnumerable<T> List();
        IEnumerable<T> List(Func<T, bool> predicate);
        void Delete(T item);
        void Update(T item);
    }
}
