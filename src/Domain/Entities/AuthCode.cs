using HomiePages.Domain.Common;
using HomiePages.Domain.Entities.Interfaces;
using HomiePages.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomiePages.Domain.Entities
{
    public class AuthCode : AuditableEntity, IOwnedEntity
    {
        [Key]
        public long Id { get; set; }
        public string Code { get; set; }
        public string UserId { get; set; }
        public CodeType Type { get; set; }
        public AuthProvider Provider { get; set; }
    }
}
