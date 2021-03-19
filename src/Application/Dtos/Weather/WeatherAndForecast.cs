namespace HomiePages.Application.Dtos.Weather
{
    public class WeatherAndForecast
    {
        public WeatherAndForecast(CurrentWeather currentWeather, WeatherDto weather)
        {
            CurrentWeather = currentWeather;
            Weather = weather;
        }
        public CurrentWeather CurrentWeather { get; set; }
        public WeatherDto Weather { get; set; }
    }
}