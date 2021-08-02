using HomiePages.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HomiePages.Domain.Enums.Enums;

namespace HomiePages.WebUI.Models.APIModels
{
    public class ToDoItemModel
    {
        public long Id { get; set; }
        public string ToDoText { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public int Order { get; set; }
        public long? ToDoTypeId { get; set; }
        public ToDoType ToDoType { get; set; }

        public ToDoItemModel(ToDoItem toDoItem)
        {
            Id = toDoItem.Id;
            ToDoText = toDoItem.ToDoText;
            DueDate = toDoItem.DueDate;
            CompletionDate = toDoItem.CompletionDate;
            Order = toDoItem.Order;
            ToDoTypeId = toDoItem.ToDoTypeId;
            ToDoType = toDoItem.ToDoType;
        }
    }

    public static class ToDoItemModelHelpers
    {
        public static IEnumerable<ToDoItemModel> MapToModelCollection(ICollection<ToDoItem> items)
        {
            if (items == null)
                return null;

            return items.Select(e => new ToDoItemModel(e));
        }
    }
}
