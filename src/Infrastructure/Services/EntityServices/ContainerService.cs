using AutoMapper;
using HomiePages.Application.RepositoryInterfaces;
using HomiePages.Application.ServiceInterfaces;
using HomiePages.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomiePages.Infrastructure.Services.EntityServices
{
    public class ContainerService : ServiceBaseHelper<BaseContainer>, IContainerService
    {
        private readonly IRepositoryWrapper _repo;
        private readonly IMapper _mapper;

        public ContainerService(IRepositoryWrapper repo, IMapper mapper, IHttpContextAccessor httpContextAccessor) 
            : base(repo, repo.Containers, httpContextAccessor)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<bool> SaveContainers(IEnumerable<BaseContainer> containers)
        {
            _repo.Containers.CreateRange(containers);
            var res = await _repo.SaveAsync();
            return res;
        }

        public async Task<bool> SaveContainer(BaseContainer container)
        {
            _repo.Containers.Create(container);
            var res = await _repo.SaveAsync();
            return res;
        }

        public async Task<bool> DeleteContainerByLayoutId(string i)
        {
            var container = _repo.Containers.FindByCondition(c => c.Layout.I == i).FirstOrDefault();
            if (container != null)
            {
                _repo.Containers.Delete(container);
                var res = await _repo.SaveAsync();
                return res;
            }

            return false;
        }

        public async Task<bool> UpdateContainers(IEnumerable<BaseContainer> containers, string userId)
        {
            foreach (var container in containers)
            {
                _repo.Layouts.Update(container.Layout);
            }
            return await _repo.SaveAsync();
        }

        public IEnumerable<BaseContainer> GetUserContainers(string userId)
        {

            return _repo.Containers.GetUserContainers(userId);
        }
    }
}
