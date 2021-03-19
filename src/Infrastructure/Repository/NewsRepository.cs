using HomiePages.Application.RepositoryInterfaces;
using HomiePages.Domain.Entities;
using HomiePages.Infrastructure.Persistence;


namespace HomiePages.Infrastructure.Repository
{
    public class NewsRepository : Repository<News>, INewsRepository
    {
        private readonly ApplicationDbContext _context;

        public NewsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


    }
}