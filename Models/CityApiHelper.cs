using RestSharp;
using System;
using System.Threading.Tasks;

namespace LocalLookupMVC.Models
{
    class CityApiHelper
    {
        public static async Task<string> GetAll()
        {
            RestClient client = new RestClient("http://localhost:5004/api");
            RestRequest request = new RestRequest($"cities", Method.GET);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task<string> Get(int id)
        {
            RestClient client = new RestClient("http://localhost:5004/api");
            RestRequest request = new RestRequest($"cities/{id}", Method.GET);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task Post(string newCity)
        {
            RestClient client = new RestClient("http://localhost:5004/api");
            RestRequest request = new RestRequest($"cities", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(newCity);
            var response = await client.ExecuteTaskAsync(request);
        }

        public static async Task Put(int id, string newCity)
        {
            RestClient client = new RestClient("http://localhost:5004/api");
            RestRequest request = new RestRequest($"cities/{id}", Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(newCity);
            var response = await client.ExecuteTaskAsync(request);
        }

        public static async Task Delete(int id)
        {
            RestClient client = new RestClient("http://localhost:5004/api");
            RestRequest request = new RestRequest($"cities/{id}", Method.DELETE);
            request.AddHeader("content-Type", "application/json");
            var response = await client.ExecuteTaskAsync(request);
        }

    }
}