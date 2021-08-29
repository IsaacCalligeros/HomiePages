using AutoMapper;
using HomiePages.Application.RepositoryInterfaces;
using HomiePages.Application.ServiceInterfaces;
using HomiePages.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HomiePages.Infrastructure.Services.EntityServices
{
    public class PortfolioService : ServiceBaseHelper<Portfolio>, IPortfolioService
    {
        private readonly IRepositoryWrapper _repo;
        private readonly IMapper _mapper;

        public PortfolioService(IRepositoryWrapper repo, IMapper mapper, IHttpContextAccessor httpContextAccessor) 
            : base(repo, repo.Portfolios, httpContextAccessor)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public Portfolio GetPortfolio(Expression<Func<Portfolio, bool>> expression)
        {
            return GetBy(expression).Include(t => t.Equities).FirstOrDefault();
        }

        public Portfolio FindOrCreate(string userId, long containerId)
        {
            var portfolio = GetPortfolio(p => p.ContainerId == containerId);

            if (portfolio != null)
            {
                return portfolio;
            }

            var newPortfolio = new Portfolio()
            {
                UserId = userId,
                ContainerId = containerId
            };

            _repo.Portfolios.Create(newPortfolio);
            var res = _repo.SaveChanges();

            return newPortfolio;
        }

        public bool CreatePortfolio(Portfolio portfolio)
        {
            _repo.Portfolios.Create(portfolio);
            return _repo.SaveChanges();
        }

        public bool DeletePortfolio(int portfolioId)
        {
            return DeleteById(portfolioId);
        }

    }
}
