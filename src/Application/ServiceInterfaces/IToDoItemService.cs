using HomiePages.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HomiePages.Application.ServiceInterfaces
{
    public interface IToDoItemService
    {
        public ToDoItem AddToDoItem(string UserId, ToDoItem toDoItem, long containerId);
        public ToDoItem UpdateToDoItem(string userId, ToDoItem toDoItem, long containerId);
        public ToDo UpdateToDoItemsOrder(string userId, List<ToDoItem> toDoItems, long containerId);       
        public bool DeleteToDoItem(long toDoItemId);
    }
}
