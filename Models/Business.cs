using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace LocalLookupMVC.Models
{
    public class Business
    {
        public int BusinessId { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Blurb { get; set; }

        public Business()
        {

        }

        public static List<Business> GetBusinesses()
        {
            var apiCallTask = BusinessApiHelper.GetAll();
            var result = apiCallTask.Result;
            
            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
            List<Business> BusinessList = JsonConvert.DeserializeObject<List<Business>>(jsonResponse.ToString());

            return BusinessList;
        }

        public static Business GetDetails(int id)
        {
            var apiCallTask = BusinessApiHelper.Get(id);
            var result = apiCallTask.Result;

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            Business business = JsonConvert.DeserializeObject<Business>(jsonResponse.ToString());
            return business;
        }

        public static void Post(Business business)
        {
            string jsonBusiness = JsonConvert.SerializeObject(business);
            var apiCallTask = BusinessApiHelper.Post(jsonBusiness);
        }

        public static void Put(Business business)
        {
            string jsonBusiness = JsonConvert.SerializeObject(business);
            var apiCallTask = BusinessApiHelper.Put(business.BusinessId, jsonBusiness);
        }

        public static void Delete(int id)
        {
            var apiCallTask = BusinessApiHelper.Delete(id);
        }

    }
}