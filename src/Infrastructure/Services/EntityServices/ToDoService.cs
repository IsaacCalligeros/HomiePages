using AutoMapper;
using HomiePages.Application.RepositoryInterfaces;
using HomiePages.Application.ServiceInterfaces;
using HomiePages.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HomiePages.Infrastructure.Services.EntityServices
{
    public class ToDoService : ServiceBaseHelper<ToDo>, IToDoService
    {
        private readonly IRepositoryWrapper _repo;
        private readonly IMapper _mapper;

        public ToDoService(IRepositoryWrapper repo, IMapper mapper) : base(repo)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public ToDo FindOrCreate(string userId, long containerId)
        {
            var toDo = _repo.ToDos.FindByCondition(p => p.ContainerId == containerId)
                .Include(t => t.Items)
                .FirstOrDefault();

            if (toDo != null)
            {
                return toDo;
            }

            var newToDo = new ToDo()
            {
                UserId = userId,
                ContainerId = containerId
            };

            _repo.ToDos.Create(newToDo);
            var res = _repo.SaveChanges();

            return newToDo;
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

            var repoToDo = _repo.ToDoItems.FindByCondition(i => i.Id == toDoItem.Id)
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
                repoToDo = _repo.ToDoItems.FindByCondition(i => i.Id == toDoItem.Id)
                .FirstOrDefault();
            }

            return repoToDo;
        }

        public bool CreateToDo(ToDo toDo)
        {
            _repo.ToDos.Create(toDo);
            return _repo.SaveChanges();
        }

        public bool DeleteToDo(int toDoId)
        {
            _repo.ToDos.DeleteById<ToDo>(toDoId);
            return _repo.SaveChanges();
        }

        public bool DeleteToDoItem(long toDoItemId, string userId)
        {
            var item = _repo.ToDoItems.FindByCondition(i => i.Id == toDoItemId).Include(t => t.ToDo).FirstOrDefault();
            if (item?.ToDo?.UserId != userId)
            {
                return false;
            }
            _repo.ToDoItems.DeleteById<ToDoItem>(toDoItemId);
            return _repo.SaveChanges();
        }

    }
}
