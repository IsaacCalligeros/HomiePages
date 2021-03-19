using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HomiePages.Application.Dtos.News;
using HomiePages.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace HomiePages.WebUI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class NewsController : ApiControllerBase
    {
        private IConfiguration configuration;
        private IHttpClientFactory _factory;
        private readonly HttpClient _client;
        public NewsController(IConfiguration config, IHttpClientFactory factory)
        {
            configuration = config;
            _factory = factory;
            _client = _factory.CreateClient(HttpClientHelper.News);
        }

        [HttpGet("GetNews")]
        public async Task<NewsDto> GetNewsApi(string searchTerm)
        {
            //api only accepts apiKey as query paramater, can't append this to default httpClient base address since it cuts back to the final trailing backslash
            //overall really messy and need to workout clean query paramaters for httpClients when headers not allowed for auth.
            var news = await _client.GetStringAsync("everything?q=" + searchTerm + "&apiKey=" + configuration["newsApiKey"]);
            var newsDto = JsonConvert.DeserializeObject<NewsDto>(news);
            return newsDto;
        }
    }
}