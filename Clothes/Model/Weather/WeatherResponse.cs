namespace Clothes.Model
{
    public class WeatherResponse
    {
        public TemperatureInfo Main { get; set; }
        public WeatherInfo[] Weather { get; set; }
        public string Name { get; set; }
    }
}