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
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class TestController : ApiControllerBase
    {
        public TestController()
        {
        }

        [HttpGet]
        public string FindOrCreate(long containerId)
        {
            return "This is from the test controller";
        }
    }
}