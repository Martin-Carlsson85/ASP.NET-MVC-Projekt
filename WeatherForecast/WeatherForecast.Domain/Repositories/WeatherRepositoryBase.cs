using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Domain.Repositories
{
    public abstract class WeatherRepositoryBase : IWeatherRepository
    {
        public abstract IEnumerable<City> FindCity(string cityName);
        public abstract City FindCityById(int id);
        public abstract IEnumerable<Forecast> FindForecast(int id);

        public abstract void AddCity(IEnumerable<City> city);
        public abstract void AddForecast(IEnumerable<Forecast> forecast);
        public abstract void DeleteForecast(IEnumerable<Forecast> forecast);

        public abstract void Save();

        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
