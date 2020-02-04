using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ToDoAPI.Data
{
    public class EFCoreRepository<TContext> : IRepository where TContext : DbContext
    {
        protected TContext context;
        public EFCoreRepository(TContext context)
        {
            this.context = context;
        }

        public bool IsEmpty<T>() where T : class
        {
            return !context.Set<T>().Any();
        }

        public async Task Add<T>(T entity) where T : class
        {
            await context.AddAsync<T>(entity);
            await context.SaveChangesAsync();
        }

        public async Task AddRange<T>(params T []entities) where T : class
        {
            await context.AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }

        public async Task Delete<T>(T entity) where T : class
        {
            context.Remove<T>(entity);
            await context.SaveChangesAsync();
        }

        public async Task<T> Get<T>(int id) where T : class
        {
            return await context.FindAsync<T>(id);
        }

        public async Task<List<T>> GetAll<T>() where T : class
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task Update<T>(T entity) where T : class
        {
            context.Update<T>(entity);
            await context.SaveChangesAsync();
        }
    }
}
