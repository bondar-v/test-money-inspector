using MoneyInspector.Server.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyInspector.Server.Data.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        public void Add(T entity);
        public void Delete(T entity);
        public void Update(T entity);
        public IEnumerable<T> GetByFilter(Func<T, bool> filter);
    }
}
