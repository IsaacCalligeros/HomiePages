using HomiePages.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomiePages.WebUI.Models.APIModels
{
    public class PortfolioModel
    {
        [Required]
        public IEnumerable<EquityModel> Equities { get; set; }
        public long Id { get; set; }
        public string UserId { get; set; }

        public PortfolioModel(Portfolio portfolio)
        {
            Id = portfolio.Id;
            UserId = portfolio.UserId;
            Equities = EquityModelHelpers.MapToModelCollection(portfolio.Equities);
        }
    }
}
