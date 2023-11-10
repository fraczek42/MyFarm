using MyFarm.Models;

namespace MyFarm.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrdersAsync();

    }
}
