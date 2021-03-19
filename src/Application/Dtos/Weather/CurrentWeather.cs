using System;
using System.Collections.Generic;
using HomiePages.Application.Dtos.Weather;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

//TODO: Being lazy and using quicktype.io might go through and tidy up unused variables later
namespace HomiePages.Application.Dtos.Weather
{
    public class CurrentWeather
    {
        public Coord Coord { get; set; }

        [JsonProperty("weather")]
        public List<WeatherData> Weather { get; set; }
        public string Base { get; set; }

        [JsonProperty("main")]
        public DayTempDetails DayTempDetail { get; set; }
        public long Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public long Dt { get; set; }

        [JsonProperty("sys")]
        public DayDetails DayDetail { get; set; }
        public long Timezone { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public long Cod { get; set; }

        public class DayTempDetails
        {
            public double Temp { get; set; }
            public double FeelsLike { get; set; }

            [JsonProperty("temp_min")]
            public double TempMin { get; set; }

            [JsonProperty("temp_max")]
            public double TempMax { get; set; }
            public long Pressure { get; set; }
            public long Humidity { get; set; }
        }

        public class DayDetails
        {
            public long Type { get; set; }
            public long Id { get; set; }
            public string Country { get; set; }
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

        public class WeatherData
        {
            public long Id { get; set; }
            public string Main { get; set; }
            public string Description { get; set; }
            public string Icon { get; set; }
        }
    }
}