using HomiePages.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HomiePages.Application.ServiceInterfaces
{
    public interface IToDoService
    {
        public ToDo FindOrCreate(string userId, long containerId);

    }
}
