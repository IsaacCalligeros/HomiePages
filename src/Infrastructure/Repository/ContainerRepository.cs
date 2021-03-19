using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HomiePages.Domain.Entities;
using HomiePages.Infrastructure.Persistence;
using HomiePages.Application.RepositoryInterfaces;

namespace HomiePages.Infrastructure.Repository
{
    public class ContainerRepository : Repository<BaseContainer>, IContainerRepository
    {
        private readonly ApplicationDbContext _context;

        public ContainerRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<BaseContainer> GetUserContainers(string userId)
        {
            return _context.Containers
                .Include(u => u.Layout)
                .AsNoTracking()
                .Where(u => u.UserId == userId).ToList();
        }

    }
}