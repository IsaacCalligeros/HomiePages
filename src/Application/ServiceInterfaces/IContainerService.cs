using HomiePages.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomiePages.Application.ServiceInterfaces
{
    public interface IContainerService
    {
        Task<bool> SaveContainers(IEnumerable<BaseContainer> containers);
        Task<bool> SaveContainer(BaseContainer container);
        Task<bool> DeleteContainerByLayoutId(string i);
        Task<bool> UpdateContainers(IEnumerable<BaseContainer> container, string userId);
        IEnumerable<BaseContainer> GetUserContainers(string userId);
    }
}
