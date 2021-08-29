using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomiePages.Application.RepositoryInterfaces
{
    public interface IRepositoryWrapper
    {
        IWeatherRepository Weather { get; }
        INewsRepository News { get; }
        IEquityRepository Equities { get; }
        IContainerRepository Containers { get; }
        IPortfolioRepository Portfolios { get; }
        ILayoutRepository Layouts { get; }
        IToDoRepository ToDos { get; }
        IToDoItemRepository ToDoItems { get; }
        INotesRepository Notes { get; }
        INotesItemRepository NoteItems { get; }

        Task<bool> SaveAsync(string savingEntity);
        Task<bool> SaveAsync();
        bool SaveChanges();
    }
}