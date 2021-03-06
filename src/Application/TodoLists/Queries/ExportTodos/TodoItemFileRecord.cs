using HomiePages.Application.Common.Mappings;
using HomiePages.Domain.Entities;

namespace HomiePages.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
