using HomiePages.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HomiePages.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<TodoList> TodoLists { get; set; }

        DbSet<TodoItem> TodoItems { get; set; }

        DbSet<Weather> Weather { get; set; }
        DbSet<Equity> Equities { get; set; }
        DbSet<News> News { get; set; }
        DbSet<BaseContainer> Containers { get; set; }
        DbSet<Portfolio> Portfolios { get; set; }
        DbSet<Layout> Layouts { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
