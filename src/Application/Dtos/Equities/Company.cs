using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomiePages.Application.Dtos.Equities
{
    public class Company
    {
        public string Ticker { get; set; }
        [JsonProperty("Company")]
        public string CompanyName { get; set; }
        public DateTime? ListingDate { get; set; }
        public string Industry { get; set; }
    }
}
