using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Domain.Repositories;
using WeatherForecast.Domain.Webservices;

namespace WeatherForecast.Domain
{
    public class WeatherForecastService : WeatherForecastServiceBase
    {
        private IWeatherRepository _repository;
        private IGeonamesWebservice _geonameWebservice;
        private IYrWebservice _yrWebservice;
        public WeatherForecastService()
            : this(new WeatherRepository(), new GeonamesWebservice(), new YrWebservice())
        {
        }

        public WeatherForecastService(IWeatherRepository repository, IGeonamesWebservice geowebservice, IYrWebservice yrwebservice)
        {
            _repository = repository;
            _geonameWebservice = geowebservice;
            _yrWebservice = yrwebservice; 
        }

        public override IEnumerable<City> GetCity(string cityName)
        {
            var city = _repository.FindCity(cityName);

            if (city.Count() == 0)
            {
                city = _geonameWebservice.GetCity(cityName);

                _repository.AddCity(city);
                _repository.Save();
            }

            return city;
        }

        public override City FindCity(int id)
        {
            return _repository.FindCityById(id);
        }

        public override IEnumerable<Forecast> GetForecast(City city)
        {
            var forecast = _repository.FindForecast(city.CityID);

            if (forecast.Count() == 0)
            {
                forecast = _yrWebservice.GetForecast(city);
                _repository.AddForecast(forecast); 
                _repository.Save();
            }
            else
            {
                foreach (Forecast item in forecast)
                {
                    if (item.NextUpdate < DateTime.Now)
                    {
                        _repository.DeleteForecast(forecast);
                        _repository.Save();

                        forecast = _yrWebservice.GetForecast(city);

                        _repository.AddForecast(forecast);
                        _repository.Save();
                        break;
                    }
                }
            }
            return forecast;
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
    }
}
