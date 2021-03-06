using System.Collections.Generic;
using static HomiePages.Domain.Enums.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomiePages.Domain.Entities
{
    public class Equity
    {
        [Key]
        public int Id { get; set; }
        public string Ticker { get; set; }
        public EquityType Type { get; set; }
        public float NumberHeld { get; set; }
        public float PurchasePrice { get; set; }

        public int PortfolioId { get; set; }

        [ForeignKey("PortfolioId")]
        protected Portfolio Portfolio { get; set; }
    }
}