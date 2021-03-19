using HomiePages.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HomiePages.Application.RepositoryInterfaces
{
    public interface IContainerRepository : IRepository<BaseContainer>
    {
        IEnumerable<BaseContainer> GetUserContainers(string userId);
    }
}