using HomiePages.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomiePages.Domain.Entities
{
    public class ToDoType
    {
        public long Id { get; set; }
        public string Type { get; set; }
    }
}
