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
    public class NoteItemService : ServiceBaseHelper<NoteItem>, INoteItemService

    {
        private readonly IRepositoryWrapper _repo;
        private readonly IMapper _mapper;

        public NoteItemService(IRepositoryWrapper repo, IMapper mapper, IHttpContextAccessor httpContextAccessor) 
            : base(repo, repo.NoteItems, httpContextAccessor)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public Notes UpdateNotesOrder(List<NoteItem> noteItems, long containerId)
        {
            var i = 0;
            foreach (var item in noteItems)
            {
                var repoNoteItem = GetBy(i => i.Id == item.Id)
                    .Include(t => t.NoteContainer)
                    .FirstOrDefault();

                if (repoNoteItem.NoteContainer.UserId != UserId)
                {
                    return null;
                }

                repoNoteItem.Order = i;
                i += 1;
            }

            var res = _repo.SaveChanges();
            var notes = _repo.Notes.FindByCondition(i => i.ContainerId == containerId)
                    .Include(t => t.Items.OrderBy(o => o.Order))
                    .FirstOrDefault();

            return notes;
        }

        public NoteItem AddNoteItem(NoteItem noteItem, long containerId)
        {
            var notes = _repo.Notes.FindByCondition(p => p.ContainerId == containerId)
                .Include(i => i.Items)
                .FirstOrDefault();

            var order = notes.Items.Count();

            if (notes.UserId != UserId)
            {
                return null;
            }

            noteItem.NoteId = notes.Id;
            noteItem.Order = order;

            _repo.Notes.Create(notes);
            var res = _repo.SaveChanges();

            return noteItem;
        }

        public NoteItem UpdateNoteItem(NoteItem noteItem, long containerId)
        {
            var repoNoteItem = GetBy(i => i.Id == noteItem.Id)
                .Include(t => t.NoteContainer)
                .FirstOrDefault();

            if (repoNoteItem.NoteContainer.UserId != UserId)
            {
                return null;
            }

            repoNoteItem.Content = noteItem.Content;

            var res = _repo.SaveChanges();

            if (res)
            {
                repoNoteItem = GetBy(i => i.Id == repoNoteItem.Id).FirstOrDefault();
            }

            return repoNoteItem;
        }
        
        public bool DeleteNoteItem(long noteItemId)
        {
            return DeleteById(noteItemId);
        }
    }
}
