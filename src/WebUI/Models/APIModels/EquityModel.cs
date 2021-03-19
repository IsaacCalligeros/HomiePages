using HomiePages.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HomiePages.Domain.Enums.Enums;

namespace HomiePages.WebUI.Models.APIModels
{
    public class EquityModel
    {
        public int Id { get; set; }
        public string Ticker { get; set; }
        public EquityType Type { get; set; }
        public float NumberHeld { get; set; }
        public float PurchasePrice { get; set; }
        public int PortfolioId { get; set; }

        public float CurrentPrice { get; set; }
        public float Change { get; set; }

        public EquityModel(Equity equity)
        {

            Id = equity.Id;
            Ticker = equity.Ticker;
            Type = equity.Type;
            NumberHeld = equity.NumberHeld;
            PurchasePrice = equity.PurchasePrice;
            CurrentPrice = 0;
            Change = 0;
            PortfolioId = equity.PortfolioId;
        }
    }

    public static class EquityModelHelpers
    {
        public static IEnumerable<EquityModel> MapToModelCollection(ICollection<Equity> equities)
        {
            if (equities == null)
                return null;

            return equities.Select(e => new EquityModel(e));
        }
    }
}
