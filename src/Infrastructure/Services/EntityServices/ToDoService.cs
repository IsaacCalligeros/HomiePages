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
    public class ToDoService : ServiceBaseHelper<ToDo>, IToDoService
    {
        private readonly IRepositoryWrapper _repo;
        private readonly IMapper _mapper;

        public ToDoService(IRepositoryWrapper repo, IMapper mapper, IHttpContextAccessor httpContextAccessor) 
            : base(repo, repo.ToDos, httpContextAccessor)
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

        public bool CreateToDo(ToDo toDo)
        {
            _repo.ToDos.Create(toDo);
            return _repo.SaveChanges();
        }
    }
}
