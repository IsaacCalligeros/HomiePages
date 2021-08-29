using AutoMapper;
using HomiePages.Application.RepositoryInterfaces;
using HomiePages.Application.ServiceInterfaces;
using HomiePages.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomiePages.Infrastructure.Services.EntityServices
{
    public class NotesService : ServiceBaseHelper<Notes>, INotesService
    {
        private readonly IRepositoryWrapper _repo;
        private readonly IMapper _mapper;

        public NotesService(IRepositoryWrapper repo, IMapper mapper, IHttpContextAccessor httpContextAccessors) 
            : base(repo, repo.Notes, httpContextAccessors)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public Notes FindOrCreate(long containerId)
        {
            var notes = GetBy(p => p.ContainerId == containerId).Include(n => n.Items).FirstOrDefault();

            if (notes != null)
            {
                return notes;
            }

            var noteItem = new NoteItem()
            {
                Content = String.Empty,
                Order = 1
            };

            var newNotes = new Notes()
            {
                UserId = UserId,
                ContainerId = containerId,
                Items = new List<NoteItem>() { noteItem }
            };

            _repo.Notes.Create(newNotes);
            var res = _repo.SaveChanges();

            return newNotes;
        }

        public bool DeleteNote(long containerId)
        {
            return DeleteBy(i => i.ContainerId == containerId);
        }
    }
}
