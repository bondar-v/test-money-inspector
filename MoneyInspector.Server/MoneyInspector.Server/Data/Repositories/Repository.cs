using Microsoft.EntityFrameworkCore;
using MoneyInspector.Server.Data.Entities;
using MoneyInspector.Server.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyInspector.Server.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext context;
        private readonly DbSet<T> dbSet;

        public Repository(AppDbContext context)
        {
            this.context = context;
            dbSet = this.context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<T> GetByFilter(Func<T, bool> filter)
        {
            return dbSet.Where(filter);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
            context.SaveChanges();
        }
    }
}
