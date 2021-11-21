using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using HomiePages.Infrastructure.Persistence;
using HomiePages.Application.RepositoryInterfaces;

namespace HomiePages.Infrastructure.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        //Based off of https://code-maze.com/net-core-web-development-part4/#comments

        private ApplicationDbContext _dataContext;
        private IWeatherRepository _weather;
        private INewsRepository _news;
        private IEquityRepository _equity;
        private IContainerRepository _container;
        private IPortfolioRepository _portfolio;
        private ILayoutRepository _layout;
        private IToDoRepository _toDo;
        private IToDoItemRepository _toDoItems;
        private INotesRepository _notes;
        private INotesItemRepository _noteItems;
        private IAuthCodeRepository _authCodes;

        private readonly IHttpContextAccessor _httpContextAccessor;

        public RepositoryWrapper(ApplicationDbContext dataContext, IHttpContextAccessor httpContextAccessor)
        {
            _dataContext = dataContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public IWeatherRepository Weather
        {
            get
            {
                if (_weather == null)
                {
                    _weather = new WeatherRepository(_dataContext);
                }

                return _weather;
            }
        }

        public INewsRepository News
        {
            get
            {
                if (_news == null)
                {
                    _news = new NewsRepository(_dataContext);
                }

                return _news;
            }
        }

        public IEquityRepository Equities
        {
            get
            {
                if (_equity == null)
                {
                    _equity = new EquityRepository(_dataContext);
                }

                return _equity;
            }
        }

        public IContainerRepository Containers
        {
            get
            {
                if (_container == null)
                {
                    _container = new ContainerRepository(_dataContext);
                }

                return _container;
            }
        }

        public ILayoutRepository Layouts
        {
            get
            {
                if (_layout == null)
                {
                    _layout = new LayoutRepository(_dataContext);
                }

                return _layout;
            }
        }

        public IPortfolioRepository Portfolios
        {
            get
            {
                if (_portfolio == null)
                {
                    _portfolio = new PortfolioRepository(_dataContext);
                }

                return _portfolio;
            }
        }

        public IToDoRepository ToDos
        {
            get
            {
                if (_toDo == null)
                {
                    _toDo = new ToDoRepository(_dataContext);
                }

                return _toDo;
            }
        }

        public IToDoItemRepository ToDoItems
        {
            get
            {
                if (_toDoItems == null)
                {
                    _toDoItems = new ToDoItemRepository(_dataContext);
                }

                return _toDoItems;
            }
        }

        public INotesRepository Notes
        {
            get
            {
                if (_notes == null)
                {
                    _notes = new NotesRepository(_dataContext);
                }

                return _notes;
            }
        }

        public INotesItemRepository NoteItems
        {
            get
            {
                if (_noteItems == null)
                {
                    _noteItems = new NotesItemRepository(_dataContext);
                }

                return _noteItems;
            }
        }

        public IAuthCodeRepository AuthCodes
        {
            get
            {
                if (_authCodes == null)
                {
                    _authCodes = new AuthCodeRepository(_dataContext);
                }

                return _authCodes;
            }
        }

        public async Task<bool> SaveAsync(string savingEntity)
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> SaveAsync()
        {
            return await _dataContext.SaveChangesAsync() > 0;
        }

        public bool SaveChanges()
        {
            return _dataContext.SaveChanges() > 0;
        }
    }
}