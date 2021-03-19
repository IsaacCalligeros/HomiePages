using HomiePages.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomiePages.Domain.Common
{
    public class Control
    {
        [ForeignKey("Container")]
        public long ContainerId { get; set; }
        public BaseContainer Container { get; set; }
    }
}
