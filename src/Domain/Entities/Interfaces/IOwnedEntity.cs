using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomiePages.Domain.Entities.Interfaces
{
    public interface IOwnedEntity
    {
        public string UserId { get; }

        public long Id { get;}
    }
}
