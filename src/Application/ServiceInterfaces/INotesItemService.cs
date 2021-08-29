using HomiePages.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HomiePages.Application.ServiceInterfaces
{
    public interface INoteItemService
    {
        public Notes UpdateNotesOrder(List<NoteItem> noteItems, long containerId);
        public NoteItem AddNoteItem(NoteItem noteItem, long containerId);
        public NoteItem UpdateNoteItem(NoteItem noteItem, long containerId);
        public bool DeleteNoteItem(long noteItemId);
    }
}
