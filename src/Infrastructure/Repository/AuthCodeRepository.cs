using HomiePages.Application.RepositoryInterfaces;
using HomiePages.Domain.Entities;
using HomiePages.Infrastructure.Persistence;

namespace HomiePages.Infrastructure.Repository
{
    public class AuthCodeRepository : Repository<AuthCode>, IAuthCodeRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthCodeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}