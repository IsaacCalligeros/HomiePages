using HomiePages.Domain.Entities;
using HomiePages.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomiePages.Domain.RepositoryInterfaces
{
    public interface IWeatherRepository : IRepository<Weather>
    {

    }
}