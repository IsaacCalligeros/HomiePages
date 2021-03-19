using HomiePages.Application.RepositoryInterfaces;
using HomiePages.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HomiePages.Infrastructure.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {

        protected ApplicationDbContext DataContext;
        public Repository(ApplicationDbContext context)
        {
            DataContext = context;
        }

        public async Task<bool> SaveAll()
        {
            return await DataContext.SaveChangesAsync() > 0;
        }

        public IQueryable<T> FindAll()
        {
            return DataContext.Set<T>().AsNoTracking();
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await DataContext.Set<T>().Where(match).ToListAsync();
        }

        public T FindById<T>(object id) where T : class
        {
            return DataContext.Set<T>().Find(id);
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return DataContext.Set<T>().Where(expression);
        }

        public void Create(T entity)
        {
            DataContext.Set<T>().Add(entity);
        }

        public void CreateRange(IEnumerable<T> entities)
        {
            DataContext.Set<T>().AddRange(entities);
        }

        public void Update(T entity)
        {
            DataContext.Set<T>().Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            DataContext.Set<T>().UpdateRange(entities);
        }

        public void Delete(T entity)
        {
            DataContext.Set<T>().Remove(entity);
        }

        public void DeleteById<T>(object id) where T : class
        {
            var entity = DataContext.Set<T>().Find(id);
            DataContext.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            DataContext.Set<T>().RemoveRange(entities);
        }
    }
}