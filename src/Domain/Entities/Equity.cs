using System.Collections.Generic;
using static HomiePages.Domain.Enums.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HomiePages.Domain.Common;
using HomiePages.Domain.Entities.Interfaces;

namespace HomiePages.Domain.Entities
{
    public class Equity : AuditableEntity, IOwnedEntity
    {
        [Key]
        public long Id { get; set; }
        public string Ticker { get; set; }
        public EquityType Type { get; set; }
        public float NumberHeld { get; set; }
        public float PurchasePrice { get; set; }

        public int PortfolioId { get; set; }

        [ForeignKey("PortfolioId")]
        protected Portfolio Portfolio { get; set; }

        public string UserId => Portfolio.UserId;
    }
}