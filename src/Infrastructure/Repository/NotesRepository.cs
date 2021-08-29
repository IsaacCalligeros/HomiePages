using HomiePages.Application.RepositoryInterfaces;
using HomiePages.Domain.Entities;
using HomiePages.Infrastructure.Persistence;


namespace HomiePages.Infrastructure.Repository
{
    public class NotesRepository : Repository<Notes>, INotesRepository
    {
        private readonly ApplicationDbContext _context;

        public NotesRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}