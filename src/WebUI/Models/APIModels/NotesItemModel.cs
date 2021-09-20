using HomiePages.Domain.Entities;
using HomiePages.WebUI.Models.APIModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomiePages.WebUI.Models.APIModels
{
    public class NotesItemModel
    {
        public NotesItemModel(NoteItem noteItem)
        {
            Id = noteItem.Id;
            Content = noteItem.Content;
            Order = noteItem.Order;
        }

        public long Id { get; set; }
        public string Content { get; set; }
        public int Order { get; set; }
    }
}

public static class NotesItemModelHelper
{
    public static IEnumerable<NotesItemModel> MapToModelCollection(ICollection<NoteItem> notesItems)
    {
        if (notesItems == null)
            return null;

        return notesItems.Select(e => new NotesItemModel(e));
    }
}
