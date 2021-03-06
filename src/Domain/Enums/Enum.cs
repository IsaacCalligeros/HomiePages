using System;
using System.Collections.Generic;
using System.Text;

//May split out to individual files later easier for now.
namespace HomiePages.Domain.Enums
{
    public class Enums
    {
        public enum EquityType
        {
            Stock,
            Cryptocurrency,
        }

        public enum NewsSources
        {
            HackerNews,
            NewsApi
        }

        public enum ComponentType
        {
            News,
            Weather,
            Portfolio

        }
    }
}
