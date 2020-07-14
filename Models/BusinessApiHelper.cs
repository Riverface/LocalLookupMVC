using RestSharp;
using System.Threading.Tasks;
using System.Collections.Generic;
    
namespace LocalLookupMVC.Models
{
    class BusinessApiHelper
    {
        public static async Task<string> GetAll()
        {
            RestClient client = new RestClient("http://localhost:5004/api");
            RestRequest request = new RestRequest($"businesses", Method.GET);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task<string> Get(int id)
        {
            RestClient client = new RestClient("http://localhost:5004/api");
            RestRequest request = new RestRequest($"businesses/{id}", Method.GET);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task Post(string newBusiness)
        {
            RestClient client = new RestClient("http://localhost:5004/api");
            RestRequest request = new RestRequest($"businesses", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(newBusiness);
            var response = await client.ExecuteTaskAsync(request);
        }

        public static async Task Put(int id, string newBusiness)
        {
            RestClient client = new RestClient("http://localhost:5004/api");
            RestRequest request = new RestRequest($"businesses/{id}", Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(newBusiness);
            var response = await client.ExecuteTaskAsync(request);
        }

        public static async Task Delete(int id)
        {
            RestClient client = new RestClient("http://localhost:5004/api");
            RestRequest request = new RestRequest($"businesses/{id}", Method.DELETE);
            request.AddHeader("Content-Type", "application/json");
            var response = await client.ExecuteTaskAsync(request);
        }

    }
}