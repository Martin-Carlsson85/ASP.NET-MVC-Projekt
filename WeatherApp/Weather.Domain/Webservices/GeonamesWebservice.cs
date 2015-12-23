using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Weather.Domain.Webservices
{
    public class GeonamesWebservice : IGeonamesWebservice
    {
        public IEnumerable<City> GetCity(string cityName)
        {
            string rawJson;

            var requestUrlString = String.Format("http://api.geonames.org/searchJSON?name=" + cityName + "&maxRows=50&username=mc22dg");
            var request = (HttpWebRequest)WebRequest.Create(requestUrlString);

            using (var response = request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawJson = reader.ReadToEnd();
            }

            var lengthToStart = rawJson.IndexOf("[");
            var lengthRawJson = rawJson.Length;
            var contentRawJson = rawJson.Substring(lengthToStart, lengthRawJson - lengthToStart - 1);

            return JArray.Parse(contentRawJson).Select(city => new City(city)).ToList();
        }
    }
}
