using Microsoft.EntityFrameworkCore;
using Shop.ApplicationCore.Entities;
using Shop.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data
{

        public class GenericEfRepository<T> : IAsyncRepository<T> where T : BaseEntity, IAggregateRoot
        {
            protected readonly ShopContext _dbContext;
            private DbSet<T> _dbSet;

            public GenericEfRepository(ShopContext dbContext)
            {
                _dbContext = dbContext;
                _dbSet = dbContext.Set<T>();
            }

            public virtual async Task<T> GetByIdAsync(int id)
            {
                return await _dbContext.Set<T>().FindAsync(id);
            }
            public virtual async Task<T> GetByIdAsync(Func<T, bool> predicate)
            {
                return await _dbSet.FindAsync(predicate);
            }

            public async Task<IReadOnlyList<T>> ListAllAsync()
            {
                return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
            }

            public async Task<IReadOnlyList<T>> ListAsync(Func<T, bool> predicate)
            {
                return await _dbSet.Where(predicate).AsQueryable().ToListAsync();
            }

            public async Task<int> CountAsync(Func<T, bool> predicate)
            {
                return await _dbSet.Where(predicate).AsQueryable().CountAsync();
            }

            public async Task<T> AddAsync(T entity)
            {
                await _dbContext.Set<T>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }

            public async Task UpdateAsync(T entity)
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }

            public async Task DeleteAsync(T entity)
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
}
