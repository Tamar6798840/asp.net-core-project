using Entities;

namespace Repositories
{
    public interface IOrderRepositories
    {
        Task<Order> AddOrderAsync(Order order);
    }
}