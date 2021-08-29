using HomiePages.Domain.Common;
using HomiePages.Domain.Entities.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomiePages.Domain.Entities
{
    public class NoteItem : AuditableEntity, IOwnedEntity
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public int Order { get; set; }

        [ForeignKey("NotesContainer")]
        [JsonIgnore]
        public long? NoteId { get; set; }
        [JsonIgnore]
        public Notes NoteContainer { get; set; }

        public string UserId => NoteContainer.UserId;

    }
}
