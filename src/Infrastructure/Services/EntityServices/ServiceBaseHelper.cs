using HomiePages.Application.RepositoryInterfaces;
using HomiePages.Application.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace HomiePages.Infrastructure.Services.EntityServices
{
    public class ServiceBaseHelper<T> : IServiceBaseHelper<T> where T : class
    {
        private readonly IRepositoryWrapper _repo;
        //private readonly IRepository<T> _implementedRepo;

        public ServiceBaseHelper(IRepositoryWrapper repo)
        {
            _repo = repo;

            //var interfaces = typeof(IRepositoryWrapper).GetInterfaces();
            //var props = _repo.GetType().GetProperties();
            //var repos = props.Select(t => t.PropertyType);
            //var implementedRepo = repos.Where(r => r.GetTypeInfo().ImplementedInterfaces.Any(i => i.GenericTypeArguments.Any(t => t == typeof(T)))).FirstOrDefault();
            //var test = (IRepository<T>)props[0];
        }

        //public T GetBy(Expression<Func<T, bool>> expression)
        //{
        //    return _implementedRepo.FindByCondition(expression).Single();
        //}
        //public bool DeleteBy(Expression<Func<T, bool>> expression)
        //{
        //    var dbEntity = _implementedRepo.FindByCondition(expression).Single();
        //    _implementedRepo.Delete(dbEntity);
        //    return true;
        //}
    }
}
