using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LocalLookupMVC.Models
{
    public class City
    {

        public int CityId { get; set; }
        public int ZipCode { get; set; }
        public string Name { get; set; }
        public HashSet<Business> Businesses;

        public static List<City> GetCities()
        {
            var apiCallTask = CityApiHelper.GetAll();
            var result = apiCallTask.Result;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
            List<City> cityList = JsonConvert.DeserializeObject<List<City>>(jsonResponse.ToString());

            return cityList;
        }

        public static City GetDetails(int id)
        {
            var apiCallTask = CityApiHelper.Get(id);
            if (apiCallTask.Status.Equals(204))
            {
                return new City { Name = "I AM ERROR", CityId = 0 };
            }
            var result = apiCallTask.Result;
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);

            City city = JsonConvert.DeserializeObject<City>(jsonResponse.ToString());
            return city;
        }

        public static async Task Post(City city)
        {
            string jsonCity = JsonConvert.SerializeObject(city);
            await CityApiHelper.Post(jsonCity);
        }

        public static async Task Put(City city)
        {
            string jsonCity = JsonConvert.SerializeObject(city);
            await CityApiHelper.Put(city.CityId, jsonCity);
        }

        public static async Task Delete(int id)
        {
            await CityApiHelper.Delete(id);
        }
    }
}