using RestSharp;
using System.Threading.Tasks;

namespace LocalLookupMVC.Models
{
    class CityApiHelper
    {
        public static async Task<string> GetAll()
        {
            RestClient client = new RestClient("http://localhost:5001/api");
            RestRequest request = new RestRequest($"Cities", Method.GET);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task<string> Get(int id)
        {
            RestClient client = new RestClient("http://localhost:5001/api");
            RestRequest request = new RestRequest($"Cities/{id}", Method.GET);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task Post(string newCity)
        {
            RestClient client = new RestClient("http://localhost:5001/api");
            RestRequest request = new RestRequest($"Cities", Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(newCity);
            var response = await client.ExecuteTaskAsync(request);
        }

        public static async Task Put(int id, string newCity)
        {
            RestClient client = new RestClient("http://localhost:5001/api");
            RestRequest request = new RestRequest($"Cities/{id}", Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(newCity);
            var response = await client.ExecuteTaskAsync(request);
        }

        public static async Task Delete(int id)
        {
            RestClient client = new RestClient("http://localhost:5001/api");
            RestRequest request = new RestRequest($"Cities/{id}", Method.DELETE);
            request.AddHeader("Content-Type", "application/json");
            var response = await client.ExecuteTaskAsync(request);
        }

    }
}