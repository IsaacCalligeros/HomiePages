using HomiePages.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HomiePages.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Weather> Weather { get; set; }
        DbSet<Equity> Equities { get; set; }
        DbSet<News> News { get; set; }
        DbSet<BaseContainer> Containers { get; set; }
        DbSet<Portfolio> Portfolios { get; set; }
        DbSet<Layout> Layouts { get; set; }

        DbSet<ToDo> ToDos { get; set; }
        DbSet<ToDoItem> ToDoItems { get; set; }
        DbSet<ToDoType> ToDoTypes { get; set; }

        DbSet<Notes> Notes { get; set; }
        DbSet<NoteItem> NoteItems { get; set; }
        DbSet<AuthCode> AuthCodes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        int SaveChanges();
    }
}
