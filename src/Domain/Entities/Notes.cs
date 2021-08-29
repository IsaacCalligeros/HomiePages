using HomiePages.Domain.Common;
using HomiePages.Domain.Entities.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace HomiePages.Domain.Entities
{
    public class Notes : Control, IOwnedEntity
    {
        public long Id { get; set; }
        public string UserId { get; set; }

        [Required]
        public virtual ICollection<NoteItem> Items { get; set; } = new List<NoteItem>();
    }
}
