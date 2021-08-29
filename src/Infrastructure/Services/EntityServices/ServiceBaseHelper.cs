using HomiePages.Application.RepositoryInterfaces;
using HomiePages.Application.ServiceInterfaces;
using HomiePages.Domain.Entities.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;

namespace HomiePages.Infrastructure.Services.EntityServices
{
    public class ServiceBaseHelper<T> : IServiceBaseHelper<T> where T : class, IOwnedEntity
    {
        private readonly IRepositoryWrapper _repo;
        private readonly IRepository<T> _implementedRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ServiceBaseHelper(IRepositoryWrapper repo, IRepository<T> implementedRepo, IHttpContextAccessor httpContextAccessor)
        {
            _repo = repo;
            _implementedRepo = implementedRepo;
            _httpContextAccessor = httpContextAccessor;
        }

        protected string UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

        public IQueryable<T> GetBy(Expression<Func<T, bool>> expression)
        {
            return _implementedRepo.FindByCondition(expression);
        }

        public bool DeleteBy(Expression<Func<T, bool>> expression)
        {
            var dbEntity = _implementedRepo.FindByCondition(expression).Single();

            if (dbEntity.UserId != UserId)
            {
                return false;
            }

            _implementedRepo.Delete(dbEntity);
            return _repo.SaveChanges();
        }

        public bool DeleteById(int id)
        {
            var dbEntity = _implementedRepo.FindById<T>(id);
            if (dbEntity.UserId != UserId)
            {
                return false;
            }

            _implementedRepo.DeleteById<T>(id);

            return _repo.SaveChanges();
        }

        public bool DeleteById(long id)
        {
            var dbEntity = _implementedRepo.FindByCondition(t => t.Id == id).FirstOrDefault();
            if (dbEntity.UserId != UserId)
            {
                return false;
            }

            _implementedRepo.DeleteById<T>(id);

            return _repo.SaveChanges();
        }

        public void Create(T entity)
        {
            _implementedRepo.Create(entity);
        }

        public void CreateRange(IEnumerable<T> entities)
        {
            _implementedRepo.CreateRange(entities);
        }
    }
}
