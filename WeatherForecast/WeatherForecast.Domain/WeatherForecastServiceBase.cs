using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Domain
{
   public abstract class WeatherForecastServiceBase : IWeatherForecastService
    {
       public abstract IEnumerable<City> GetCity(string cityName);

       public abstract City FindCity(int id);
       public abstract IEnumerable<Forecast> GetForecast(City city);

        protected virtual void Dispose(bool disposing)
        {
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
