using System;
using System.Text.Json.Serialization;

namespace HomiePages.Domain.Common
{
    public abstract class AuditableEntity
    {
        [JsonIgnore]
        public DateTime? Created { get; set; }
        [JsonIgnore]
        public string CreatedBy { get; set; }
        [JsonIgnore]
        public DateTime? LastModified { get; set; }
        [JsonIgnore]
        public string LastModifiedBy { get; set; }
    }
}
