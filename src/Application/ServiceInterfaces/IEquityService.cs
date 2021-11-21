using HomiePages.Application.Dtos.Equities;
using HomiePages.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomiePages.Application.ServiceInterfaces
{
    public interface IEquityService
    {
        public Task<bool> AddEquity(string userId, Equity equity);

        public Task<bool> DeleteEquity(int equityId, string userId);
    }
}
