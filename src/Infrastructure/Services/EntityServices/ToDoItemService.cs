using AutoMapper;
using HomiePages.Application.RepositoryInterfaces;
using HomiePages.Application.ServiceInterfaces;
using HomiePages.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HomiePages.Infrastructure.Services.EntityServices
{
    public class ToDoItemService : ServiceBaseHelper<ToDoItem>, IToDoItemService
    {
        private readonly IRepositoryWrapper _repo;
        private readonly IMapper _mapper;

        public ToDoItemService(IRepositoryWrapper repo, IMapper mapper, IHttpContextAccessor httpContextAccessor) 
            : base(repo, repo.ToDoItems, httpContextAccessor)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public ToDoItem AddToDoItem(string userId, ToDoItem toDoItem, long containerId)
        {
            var toDo = _repo.ToDos.FindByCondition(p => p.ContainerId == containerId)
                .FirstOrDefault();

            var order = _repo.ToDos.FindByCondition(p => p.ContainerId == containerId)
                .Select(t => t.Items.Count())
                .FirstOrDefault();

            if (toDo.UserId != userId)
            {
                return null;
            }
            toDoItem.ToDoId = toDo.Id;
            toDoItem.Order = order;

            _repo.ToDoItems.Create(toDoItem);
            var res = _repo.SaveChanges();

            return toDoItem;
        }

        public ToDo UpdateToDoItemsOrder(string userId, List<ToDoItem> toDoItems, long containerId)
        {
            var i = 0;
            foreach (var item in toDoItems)
            {
                var repoToDo = _repo.ToDoItems.FindByCondition(i => i.Id == item.Id)
                    .Include(t => t.ToDo)
                    .FirstOrDefault();

                if (repoToDo.ToDo.UserId != userId)
                {
                    return null;
                }

                repoToDo.Order = i;
                i += 1;
            }

            var res = _repo.SaveChanges();
            var toDo = _repo.ToDos
                .FindByCondition(t => t.ContainerId == containerId)
                .FirstOrDefault();

            toDo.Items = toDo.Items.OrderBy(o => o.Order).ToList();
            return toDo;
        }

        public ToDoItem UpdateToDoItem(string userId, ToDoItem toDoItem, long containerId)
        {
            var repoToDo = GetBy(i => i.Id == toDoItem.Id)
                .Include(t => t.ToDo)
                .FirstOrDefault();

            if (repoToDo.ToDo.UserId != userId)
            {
                return null;
            }

            repoToDo.ToDoText = toDoItem.ToDoText;
            repoToDo.ToDoTypeId = toDoItem.ToDoTypeId;

            var res = _repo.SaveChanges();

            if (res)
            {
                repoToDo = GetBy(i => i.Id == toDoItem.Id).FirstOrDefault();
            }

            return repoToDo;
        }

        public bool DeleteToDoItem(long toDoItemId)
        {
            return DeleteById(toDoItemId);
        }

    }
}
