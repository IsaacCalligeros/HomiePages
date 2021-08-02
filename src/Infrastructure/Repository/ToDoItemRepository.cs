using HomiePages.Application.RepositoryInterfaces;
using HomiePages.Domain.Entities;
using HomiePages.Infrastructure.Persistence;


namespace HomiePages.Infrastructure.Repository
{
    public class ToDoItemRepository : Repository<ToDoItem>, IToDoItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ToDoItemRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}