
using System.Collections.Generic;
using System.Threading.Tasks;
using HomiePages.Application.RepositoryInterfaces;
using HomiePages.Application.ServiceInterfaces;
using HomiePages.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomiePages.WebUI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ContainersController : ApiControllerBase
    {
        private readonly IContainerService _containersService;
        private readonly IRepositoryWrapper _repo;

        public ContainersController(IContainerService containerService, IRepositoryWrapper repo)
        {
            _containersService = containerService;
            _repo = repo;
        }

        [HttpPost]
        [Route("SaveContainer")]
        public async Task<BaseContainer> SaveContainer(BaseContainer container)
        {
            if (container.LayoutId == null)
            {
                container.LayoutId = container.Layout.I;
            }
            container.UserId = UserId;
            var containersSaved = await _containersService.SaveContainer(container);
            return container;
        }

        [HttpDelete]
        [Route("Delete/{layoutId}")]
        public async Task<bool> DeleteContainer(string layoutId)
        {
            var containersSaved = await _containersService.DeleteContainerByLayoutId(layoutId);
            return containersSaved;
        }

        [HttpPost]
        [Route("UpdateContainers")]
        public async Task<bool> updateContainers(List<BaseContainer> containers)
        {
            var containersSaved = await _containersService.UpdateContainers(containers, UserId);
            return containersSaved;
        }

        [HttpPost]
        [Route("UpdateContainer")]
        public bool updateContainer(BaseContainer container)
        {
            _repo.Layouts.Update(container.Layout);
            var res = _repo.SaveChanges();
            return res;
        }

        [HttpGet]
        [Route("GetContainers")]
        public IEnumerable<BaseContainer> GetContainers()
        {
            return _containersService.GetUserContainers(UserId);
        }
    }
}