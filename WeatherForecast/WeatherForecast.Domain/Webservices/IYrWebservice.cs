using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Domain.Webservices
{
    public interface IYrWebservice
    {
        IEnumerable<Forecast> GetForecast(City city);
        DateTime fixDate(string date);
    }
}
