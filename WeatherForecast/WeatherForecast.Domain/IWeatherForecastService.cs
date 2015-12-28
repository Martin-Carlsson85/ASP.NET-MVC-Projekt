using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Domain
{
    public interface IWeatherForecastService : IDisposable
    {
        IEnumerable<City> GetCity(string cityName);
        City FindCity(int id);
        IEnumerable<Forecast> GetForecast(City city);
    }
}
