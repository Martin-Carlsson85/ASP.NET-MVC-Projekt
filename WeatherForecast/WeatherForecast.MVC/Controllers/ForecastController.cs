using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WeatherForecast.MVC.ViewModels;
using WeatherForecast.Domain;
using WeatherForecast.Domain.Webservices;


namespace WeatherForecast.MVC.Controllers
{
    public class ForecastController : Controller
    {
        private WeatherForecast.Domain.IWeatherForecastService _service;

        public ForecastController()
            : this(new WeatherForecastService())
        {
        }

        public ForecastController(WeatherForecast.Domain.IWeatherForecastService service)
        {
            _service = service;
        }

        // Get: City
        public ActionResult Index()
        {
            return View();
        }

        // Post: City
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "CityName")] ForecastIndexViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Citys = _service.GetCity(model.CityName);
                    if (model.Citys.Count() == 0)
                    {
                        TempData["noCities"] = "Inga städer hittades med namnet " + model.CityName + "!";
                    }
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
            }

            return View(model);
        }

        // Get: Weather
        public ActionResult Weather(int id, ForecastIndexViewModel model)
        {
            try
            {
                model.City = _service.FindCity(id);

                if (model.City == null)
                {
                    return View("Error");
                }

                model.Forecasts = _service.GetForecast(model.City);
            }
            catch (Exception)
            {
                return View("Error");
            }

            return View(model); 
        }
	}
}