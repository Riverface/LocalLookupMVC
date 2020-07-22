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
            string result = apiCallTask.Result;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
            List<City> cityList = JsonConvert.DeserializeObject<List<City>>(jsonResponse.ToString());

            return cityList;
        }

        public static async Task<City> GetDetails(int id)
        {
            string apiCallTask = await CityApiHelper.Get(id);

            if (apiCallTask == "")
            {
                return new City { Name = "Fart city", CityId = 0 };
            }
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(apiCallTask);
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