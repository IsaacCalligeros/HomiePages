using HomiePages.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomiePages.Domain.Common
{
    public class Control
    {
        [ForeignKey("Container")]
        public long ContainerId { get; set; }
        public BaseContainer Container { get; set; }
    }
}
