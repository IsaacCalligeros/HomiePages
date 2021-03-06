using HomiePages.Domain.Entities;
using HomiePages.Domain.RepositoryInterfaces;
using HomiePages.Infrastructure.Persistence;


namespace HomiePages.Infrastructure.Repository
{
    public class PortfolioRepository : Repository<Portfolio>, IPortfolioRepository
    {
        private readonly ApplicationDbContext _context;

        public PortfolioRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}