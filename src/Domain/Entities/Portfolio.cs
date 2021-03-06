using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomiePages.Domain.Entities
{
    public class Portfolio
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual ICollection<Equity> Equities { get; set; }
    }
}
