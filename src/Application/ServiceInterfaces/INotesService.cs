using HomiePages.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HomiePages.Application.ServiceInterfaces
{
    public interface INotesService
    {
        public Notes FindOrCreate(long containerId);
        public bool DeleteNote(long containerId);
    }
}
