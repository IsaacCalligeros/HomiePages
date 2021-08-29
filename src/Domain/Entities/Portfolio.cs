using HomiePages.Domain.Common;
using HomiePages.Domain.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomiePages.Domain.Entities
{
    public class Portfolio : Control, IOwnedEntity
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public virtual ICollection<Equity> Equities { get; set; } = new List<Equity>();
    }
}
