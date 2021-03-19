using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

//TODO: Being lazy and using quicktype.io might go through and tidy up unused variables later
namespace HomiePages.Application.Dtos.Weather
{
    public class WeatherDto
    {
        public long Cod { get; set; }
        public long Message { get; set; }
        public long Cnt { get; set; }

        [JsonProperty("list")]
        public List<Data> List { get; set; }

        [JsonProperty("city")]
        public CityDetails City { get; set; }

        public class CityDetails
        {
            public long Id { get; set; }
            public string Name { get; set; }
            public Coord Coord { get; set; }
            public string Country { get; set; }
            public long Population { get; set; }
            public long Timezone { get; set; }
            public long Sunrise { get; set; }
            public DateTime SunriseDate
            {
                get
                {
                    DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                    dtDateTime = dtDateTime.AddSeconds(Sunrise).ToLocalTime();
                    return dtDateTime;
                }
            }
            public long Sunset { get; set; }
            public DateTime SunsetDate
            {
                get
                {
                    DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                    dtDateTime = dtDateTime.AddSeconds(Sunset).ToLocalTime();
                    return dtDateTime;
                }
            }
        }

        public class Coord
        {
            public double Lat { get; set; }
            public double Lon { get; set; }
        }

        public class Data
        {
            public long Dt { get; set; }
            public MainClass Main { get; set; }
            public List<WeatherElement> Weather { get; set; }
            public Clouds Clouds { get; set; }
            public Wind Wind { get; set; }
            public long Visibility { get; set; }
            public double Pop { get; set; }
            public Sys Sys { get; set; }

            [JsonProperty("dt_txt")]
            public DateTimeOffset DtTxt { get; set; }
            public Rain Rain { get; set; }
        }

        public class MainClass
        {
            public double Temp { get; set; }
            public double FeelsLike { get; set; }

            [JsonProperty("temp_min")]
            public double TempMin { get; set; }

            [JsonProperty("temp_max")]
            public double TempMax { get; set; }
            public long Pressure { get; set; }
            public long SeaLevel { get; set; }
            public long GrndLevel { get; set; }
            public long Humidity { get; set; }
            public double TempKf { get; set; }
        }

        public partial class Rain
        {
            [JsonProperty("3h")]
            public double The3H { get; set; }
        }

        public class Sys
        {
            public string Pod { get; set; }
        }

        public class WeatherElement
        {
            public long Id { get; set; }
            public string Main { get; set; }
            public string Description { get; set; }
            public string Icon { get; set; }
        }

        // public enum Pod { D, N }

        // public enum Description { BrokenClouds, ClearSky, FewClouds, LightRain, OvercastClouds, ScatteredClouds }

        // public enum MainEnum { Clear, Clouds, Rain }

    }
}