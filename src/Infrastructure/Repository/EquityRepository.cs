using HomiePages.Domain.Entities;
using HomiePages.Domain.RepositoryInterfaces;
using HomiePages.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HomiePages.Infrastructure.Repository
{
    public class EquityRepository : Repository<Equity>, IEquityRepository
    {
        private readonly ApplicationDbContext _context;

        public EquityRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}