using HomiePages.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomiePages.WebUI.Models.APIModels
{
    public class ToDoModel
    {
        [Required]
        public IEnumerable<ToDoItemModel> Items { get; set; }
        public long Id { get; set; }
        public string UserId { get; set; }

        public ToDoModel(ToDo toDo)
        {
            Id = toDo.Id;
            UserId = toDo.UserId;
            Items = ToDoItemModelHelpers.MapToModelCollection(toDo.Items);
        }
    }
}
