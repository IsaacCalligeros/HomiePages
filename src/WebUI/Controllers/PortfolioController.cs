using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HomiePages.Application.ServiceInterfaces;
using HomiePages.Domain.Entities;
using HomiePages.WebUI.Models.APIModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace HomiePages.WebUI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PortfolioController : ApiControllerBase
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpPut]
        [Route("FindOrCreate/{containerId}")]
        public PortfolioModel FindOrCreate(long containerId)
        {
            var portfolio = _portfolioService.FindOrCreate(UserId, containerId);
            return new PortfolioModel(portfolio);
        }

        [HttpPost]
        [Route("CreatePortfolio")]
        public ActionResult CreatePortfolio(Portfolio portfolio)
        {
            portfolio.UserId = UserId;
            var addRes = _portfolioService.CreatePortfolio(portfolio);
            var dbPortfolio = _portfolioService.GetPortfolio(p => p.UserId == UserId);
            return Ok(new PortfolioModel(dbPortfolio));
        }

        [HttpDelete]
        [Route("DeletePortfolio")]
        public ActionResult DeletePortfolio(int portfolioId)
        {
            var dbModel = _portfolioService.GetPortfolio(t => t.Id == portfolioId);
            if (dbModel.UserId != UserId)
            {
                return BadRequest("This Aint yours");
            }
            var delRes = _portfolioService.DeletePortfolio(portfolioId);
            return Ok(delRes);
        }
    }
}