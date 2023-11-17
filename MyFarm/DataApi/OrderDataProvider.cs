using System.Net.Http.Json;
using MyFarm.Models;

namespace MyFarm.DataApi
{
    public class OrderDataProvider
    {
        private readonly HttpClient _httpClient;

        public OrderDataProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("/api/orders");
                if (response.IsSuccessStatusCode)
                {
                    var orders = await response.Content.ReadFromJsonAsync<List<Order>>();
                    return orders ?? new();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Błąd - GetAllOrdersAsync : " + ex.Message);
            }
            return new List<Order>();
        }
    }
}
