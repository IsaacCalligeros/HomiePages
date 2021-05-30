using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace HomiePages.WebUI.Controllers
{
    // [ApiExplorerSettings(IgnoreApi = true)]
    public class OidcConfigurationController : ApiControllerBase
    {
        private readonly ILogger<OidcConfigurationController> logger;

        public OidcConfigurationController(IClientRequestParametersProvider clientRequestParametersProvider, ILogger<OidcConfigurationController> _logger)
        {
            ClientRequestParametersProvider = clientRequestParametersProvider;
            logger = _logger;
        }

        public IClientRequestParametersProvider ClientRequestParametersProvider { get; }

        [HttpGet("{clientId}")]
        [AllowAnonymous]
        public IActionResult GetClientRequestParameters([FromRoute]string clientId)
        {
            var parameters = ClientRequestParametersProvider.GetClientParameters(HttpContext, clientId);
            return Ok(parameters);
        }

        [NonAction]
        public string DictionaryToString(IDictionary<string, string> dictionary)
        {
            string dictionaryString = "{";
            foreach (KeyValuePair<string, string> keyValues in dictionary)
            {
                dictionaryString += keyValues.Key + " : " + keyValues.Value + ", ";
            }
            return dictionaryString.TrimEnd(',', ' ') + "}";
        }
    }
}
