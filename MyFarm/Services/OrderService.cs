using MyFarm.DataApi;
using MyFarm.Models;

namespace MyFarm.Services
{
    public class OrderService 
    {
        private readonly OrderDataProvider _orderDataProvider;

        public OrderService(OrderDataProvider orderDataProvider)
        {
            _orderDataProvider = orderDataProvider;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _orderDataProvider.GetAllOrdersAsync();
        }

    }
}
