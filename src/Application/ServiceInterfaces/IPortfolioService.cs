using HomiePages.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HomiePages.Application.ServiceInterfaces
{
    public interface IPortfolioService
    {
        public Portfolio GetPortfolio(Expression<Func<Portfolio, bool>> expression);
        public Portfolio FindOrCreate(string userId, long containerId);
        public bool CreatePortfolio(Portfolio portfolio);
        public bool DeletePortfolio(int portfolioId);
    }
}
