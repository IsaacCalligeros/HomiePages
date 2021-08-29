using HomiePages.Domain.Entities.Interfaces;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HomiePages.Domain.Enums.Enums;

namespace HomiePages.Domain.Entities
{
    public class BaseContainer : IOwnedEntity
    {
        [Key]
        public long ContainerId { get; set; }
        [JsonIgnore]
        public long Id { get => ContainerId; }
        public string UserId { get; set; }

        [ForeignKey("Layout")]
        public string LayoutId { get; set; }
        public Layout Layout { get; set; }

        public ComponentType ComponentType { get; set; }
    }

}
