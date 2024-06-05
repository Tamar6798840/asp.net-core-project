using Entities;

namespace Services
{
    public interface IOrderServices
    {
        Task<Order> AddOrdersAsync(Order order);
    }
}