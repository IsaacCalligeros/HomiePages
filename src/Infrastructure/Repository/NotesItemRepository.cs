using HomiePages.Application.RepositoryInterfaces;
using HomiePages.Domain.Entities;
using HomiePages.Infrastructure.Persistence;


namespace HomiePages.Infrastructure.Repository
{
    public class NotesItemRepository : Repository<NoteItem>, INotesItemRepository
    {
        private readonly ApplicationDbContext _context;

        public NotesItemRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}