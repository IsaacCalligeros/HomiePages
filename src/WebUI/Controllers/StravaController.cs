using HomiePages.Application.RepositoryInterfaces;
using HomiePages.Domain.Entities;
using HomiePages.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Strava.Authentication;
using System.Threading.Tasks;
using System.Linq;
using Strava.Clients;
using HomiePages.Application.ServiceInterfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using HomiePages.Application.Dtos;
using Newtonsoft.Json;
using System.Text;
using HomiePages.Application.Dtos.Strava;

namespace HomiePages.WebUI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class StravaController : ApiControllerBase
    {
        private readonly IAuthCodeService _authCodeService;
        private readonly IConfiguration _config;
        private IHttpClientFactory _factory;
        private readonly HttpClient _client;

        public StravaController(
            IAuthCodeService authCodeService,
            IConfiguration config,
            IHttpClientFactory factory,
            HttpClient client)
        {
            _authCodeService = authCodeService;
            _config = config;
            _factory = factory;
            _client = _factory.CreateClient();
        }

        [HttpGet("GetAuthUrl")]
        public async Task<string> GetAuthUrl()
        {
            var redirectUrl = Request.Headers["Referer"];
            string url = "https://www.strava.com/oauth/authorize";
            var scopeLevel = "activity:read";

            var authUrl = string.Format("{0}?client_id={1}&response_type=code&redirect_uri={2}&scope={3}&approval_prompt=auto", url, _config["Strava:ClientId"], redirectUrl, scopeLevel);
            return authUrl;
        }

        [HttpPost("SetAuthCode")]
        public bool SetAuthCode(string code)
        {
            return _authCodeService.AddAuthCode(code);
        }

        [HttpGet("GetActivity")]
        public async Task<bool> GetActivity()
        {
            var authCode = _authCodeService
                                .GetBy(u => u.UserId == UserId && u.Type == CodeType.AuthToken && u.Provider == AuthProvider.Strava)
                                .OrderByDescending(d => d.Created).FirstOrDefault();

            if (authCode == null)
            {
                return false;
            }

            var exchangeUrl = "https://www.strava.com/api/v3/oauth/token";
            var tokenUrl = string.Format("{0}?client_id={1}&client_secret={2}&code={3}&grant_type={4}", exchangeUrl, _config["Strava:ClientId"], _config["Strava:ClientSecret"], authCode.Code, "authorization_code");

            var tokenRequest = new StravaTokenRequest
            {
                client_id = _config["Strava:ClientId"],
                client_secret = _config["Strava:ClientSecret"],
                code = authCode.Code,
                grant_type = "authorization_code",
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(tokenRequest), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(exchangeUrl, stringContent);
            var resStr = await response.Content.ReadAsStringAsync();
            var stravaToken = JsonConvert.DeserializeObject<StravaTokenModel>(resStr);

            StaticAuthentication auth = new StaticAuthentication(stravaToken.AccessToken);
            StravaClient client = new StravaClient(auth);
            var page = 1;
            var pageSize = 50;

            var activities = client.Activities.GetActivities(page, pageSize);

            return true;
        }
    }
}