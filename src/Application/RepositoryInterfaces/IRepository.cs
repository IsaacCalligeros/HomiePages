using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HomiePages.Application.RepositoryInterfaces
{
    public interface IRepository<T> where T : class
    {
        public void Create(T entity);
        public void CreateRange(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteById<T>(object id) where T : class;
        void DeleteRange(IEnumerable<T> entities);
        Task<bool> SaveAll();
        public IQueryable<T> FindAll();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        public void Update(T entity);
        public void UpdateRange(IEnumerable<T> entities);
        public Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);

#pragma warning disable CS0693 // Type parameter has the same name as the type parameter from outer type
        public T FindById<T>(object id) where T : class;
#pragma warning restore CS0693 // Type parameter has the same name as the type parameter from outer type
    }
}