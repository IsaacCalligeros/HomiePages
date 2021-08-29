using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HomiePages.Application.ServiceInterfaces
{
    public interface IServiceBaseHelper<T> where T : class
    {
        public void Create(T entity);
        public void CreateRange(IEnumerable<T> entities);
        public IQueryable<T> GetBy(Expression<Func<T, bool>> expression);
        public bool DeleteBy(Expression<Func<T, bool>> expression);
        public bool DeleteById(int id);
        public bool DeleteById(long id);
    }
}
