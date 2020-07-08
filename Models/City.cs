using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Linq;

namespace LocalLookupMVC.Solution.Models
{
    public class City
    {

        public int CityId{get;set;}
        public string Address{get;set;}
        public string PhoneNumber{get;set;}
        public string Blurb { get; set; }

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
            var result = apiCallTask.Result;

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            City city = JsonConvert.DeserializeObject<City>(jsonResponse.ToString());
            return city;
        }

        public static void Post(City city)
        {
            string jsonCity = JsonConvert.SerializeObject(city);
            var apiCallTask = CityApiHelper.Post(jsonCity);
        }

        public static void Put(City city)
        {
            string jsonCity = JsonConvert.SerializeObject(city);
            var apiCallTask = CityApiHelper.Put(city.CityId, jsonCity);
        }

        public static void Delete(int id)
        {
            var apiCallTask = CityApiHelper.Delete(id);
        }


    }
}