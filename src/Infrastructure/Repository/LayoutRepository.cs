using HomiePages.Application.RepositoryInterfaces;
using HomiePages.Domain.Entities;
using HomiePages.Infrastructure.Persistence;


namespace HomiePages.Infrastructure.Repository
{
    public class LayoutRepository : Repository<Layout>, ILayoutRepository
    {
        private readonly ApplicationDbContext _context;

        public LayoutRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


    }
}