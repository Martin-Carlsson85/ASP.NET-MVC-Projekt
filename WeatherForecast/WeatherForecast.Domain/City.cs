using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Domain
{
    public partial class City
    {
        public City() //Defaultkonstruktor som användas när informationen läses ut från databasen
        {
        }
        public City(JToken cityToken) //Konstruktor som skickar in en parameter och instansierar namn, region och land-objekt
        {
            Name = cityToken.Value<string>("name");
            Region = cityToken.Value<string>("adminName1");
            Country = cityToken.Value<string>("countryName");
        }
    }
}
