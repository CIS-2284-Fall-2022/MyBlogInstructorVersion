namespace MyBlog.Data
{
    public interface IWeatherForecastService
    {
        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate);
    }
}
