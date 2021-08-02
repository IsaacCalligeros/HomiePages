using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HomiePages.Application.ServiceInterfaces;
using HomiePages.Domain.Entities;
using HomiePages.WebUI.Models.APIModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using HomiePages.Infrastructure.Services.EntityServices;

namespace HomiePages.WebUI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ToDoController : ApiControllerBase
    {
        private readonly IToDoService _toDoService;
        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpPut]
        [Route("FindOrCreate/{containerId}")]
        public ToDoModel FindOrCreate(long containerId)
        {
            var toDo = _toDoService.FindOrCreate(UserId, containerId);
            toDo.Items = toDo.Items
                .Where(d => d.CompletionDate != null)
                .OrderBy(o => o.Order).ToList();
            return new ToDoModel(toDo);
        }

        [HttpPost]
        [Route("AddToDoItem/{containerId}")]
        public ToDoItemModel AddToDoItem(ToDoItem toDoItem, long containerId)
        {
            var item = _toDoService.AddToDoItem(UserId, toDoItem, containerId);
            return new ToDoItemModel(item);
        }

        [HttpPost]
        [Route("UpdateOrder/{containerId}")]
        public ToDoModel AddToDoItem(List<ToDoItem> toDoItems, long containerId)
        {
            var item = _toDoService.UpdateToDoItemsOrder(UserId, toDoItems, containerId);
            return new ToDoModel(item);
        }

        [HttpPost]
        [Route("UpdateToDoItem/{containerId}")]
        public ToDoItemModel UpdateToDoItem(ToDoItem toDoItem, long containerId)
        {
            var item = _toDoService.UpdateToDoItem(UserId, toDoItem, containerId);
            return new ToDoItemModel(item);
        }

        [HttpDelete]
        [Route("DeleteToDoItem/{toDoItemId}")]
        public bool DeleteToDoItem(long toDoItemId)
        {
            var res = _toDoService.DeleteToDoItem(toDoItemId, UserId);
            return res;
        }
    }
}