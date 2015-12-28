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
        public City()
        {
        }
        public City(JToken cityToken)
        {
            Name = cityToken.Value<string>("name");
            Region = cityToken.Value<string>("adminName1");
            Country = cityToken.Value<string>("countryName");
        }
    }
}
