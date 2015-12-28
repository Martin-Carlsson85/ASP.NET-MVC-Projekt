using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Domain; 

namespace WeatherForecast.Domain.Repositories
{
    public class WeatherRepository : WeatherRepositoryBase
    {

        private WeatherEntities _context = new WeatherEntities(); 
        
        public override void AddCity(IEnumerable<City> city)
        {
            foreach (City item in city)
            {
                _context.Cities.Add(item);
            }     
        }

        public override void AddForecast(IEnumerable<Forecast> forecast)
        {
            foreach (Forecast item in forecast)
            {
                _context.Forecasts.Add(item); 
            }
        }

        public override void DeleteForecast(IEnumerable<Forecast> forecast)
        {
            foreach (Forecast item in forecast)
            {
                if (_context.Entry(item).State == EntityState.Detached)
                {
                    _context.Forecasts.Attach(item);
                }

                _context.Forecasts.Remove(item);
            }
        }

        public override IEnumerable<City> FindCity(string cityName)
        {
    
            var findCity = from city in _context.Cities.ToList() 
                               where city.Name.ToLower().Contains(cityName.ToLower())
                               select city;

            return findCity;
        }

        public override City FindCityById(int id)
        {
            return _context.Cities.Find(id); 
        }

        public override IEnumerable<Forecast> FindForecast(int id)
        {
           
            var findForecast = from forecast in _context.Forecasts.ToList()
                               where forecast.CityID == id
                               select forecast;

            return findForecast;
        }

        public override void Save()
        {
            _context.SaveChanges();
        }
    }
}
