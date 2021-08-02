using HomiePages.Domain.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomiePages.Domain.Entities
{
    public class ToDoItem : AuditableEntity
    {
        public long Id { get; set; }
        public string ToDoText { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public int Order { get; set; }
        
        [ForeignKey("ToDoType")]
        public long? ToDoTypeId { get; set; }
        public ToDoType ToDoType { get; set; }


        [ForeignKey("ToDo")]
        [JsonIgnore]
        public long? ToDoId { get; set; }
        [JsonIgnore]
        public ToDo ToDo { get; set; }

    }
}
