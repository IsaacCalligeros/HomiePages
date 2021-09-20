using HomiePages.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomiePages.WebUI.Models.APIModels
{
    public class NotesModel
    {
        public NotesModel(Notes notes)
        {

            Id = notes.Id;
            Items = NotesItemModelHelper.MapToModelCollection(notes.Items);
            UserId = notes.UserId;
        }

        public long Id { get; set; }
        public string UserId { get; set; }

        [Required]
        public IEnumerable<NotesItemModel> Items { get; set; }
    }
}
