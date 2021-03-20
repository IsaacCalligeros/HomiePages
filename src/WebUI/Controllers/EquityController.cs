using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HomiePages.Application.Dtos.Equities;
using HomiePages.Application.ServiceInterfaces;
using HomiePages.Domain.Entities;
using IEXSharp;
using IEXSharp.Model;
using IEXSharp.Model.Shared.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HomiePages.WebUI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class EquityController : ApiControllerBase
    {
        private readonly IEquityService _equityService;
        private IHttpClientFactory _factory;
        private IConfiguration _config;

        public EquityController(IEquityService equityService, IHttpClientFactory factory, IConfiguration config)
        {
            _equityService = equityService;
            _factory = factory;
            _config = config;
        }

        [HttpPost]
        [Route("AddEquity")]
        public async Task<ActionResult> AddEquity(Equity equity)
        {
            var addRes = await _equityService.AddEquity(UserId, equity);
            return Ok(addRes);
        }

        [HttpDelete]
        [Route("DeleteEquity/{equityId}")]
        public async Task<ActionResult> DeleteEquity(int equityId)
        {
            var addRes = await _equityService.DeleteEquity(equityId, UserId);
            return Ok(addRes);
        }

        [HttpGet]
        [Route("GetAsxCompanies")]
        public List<Company> GetAsxCompanies(string searchTerm)
        {
            return _equityService.GetASXCompanies(searchTerm);
        }

        [HttpGet("GetCompany")]
        public async Task<Quote> GetCompany(string companyTicker, string exchangeCode = "-AT")
        {
            using (var iexCloudClient =
                new IEXCloudClient(_config["iexPublic"], _config["iexPrivate"], signRequest: false, useSandBox: false))
            {

                var res = await iexCloudClient.StockPrices.QuoteAsync(companyTicker + exchangeCode);
                if (res.Data != null)
                {
                    return res.Data;
                }
                return null;
            }
        }
    }
}
