using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Domain.Repositories
{
    public interface IWeatherRepository : IDisposable
    {
        IEnumerable<City> FindCity(string cityName);
        City FindCityById(int id);
        IEnumerable<Forecast> FindForecast(int id);
        void AddCity(IEnumerable<City> city);
        void AddForecast(IEnumerable<Forecast> forecast);
        void DeleteForecast(IEnumerable<Forecast> forecast); 
        void Save();
    }
}
