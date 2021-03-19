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
        //public T GetBy(Expression<Func<T, bool>> expression);
        //public bool DeleteBy(Expression<Func<T, bool>> expression);
    }
}
