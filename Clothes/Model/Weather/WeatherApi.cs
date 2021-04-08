using System.IO;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Clothes.Model
{
    public class WeatherApi
    {
        private string _url = "http://api.openweathermap.org/data/2.5/weather?q=Kyiv&units=metric&appid=6104426589d31ed9fbcd49a9a10e7089";




        public WeatherResponse GetWeather()
        {
            HttpWebRequest http = (HttpWebRequest)WebRequest.Create(_url);
            HttpWebResponse response = (HttpWebResponse) http.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                WeatherResponse weather = JsonConvert.DeserializeObject<WeatherResponse>(result);
                return weather;
            }
        }
    }
}