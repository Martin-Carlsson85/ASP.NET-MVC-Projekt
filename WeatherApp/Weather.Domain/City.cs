using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Domain
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
