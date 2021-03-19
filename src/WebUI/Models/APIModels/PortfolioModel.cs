using HomiePages.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomiePages.WebUI.Models.APIModels
{
    public class PortfolioModel
    {
        public IEnumerable<EquityModel> Equities { get; set; }
        public int Id { get; set; }
        public string UserId { get; set; }

        public PortfolioModel(Portfolio portfolio)
        {
            Id = portfolio.Id;
            UserId = portfolio.UserId;
            Equities = EquityModelHelpers.MapToModelCollection(portfolio.Equities);
        }
    }
}
