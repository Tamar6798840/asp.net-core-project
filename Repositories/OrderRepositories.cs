using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepositories : IOrderRepositories
    {
        StshopContext _StshopContext;


        public OrderRepositories(StshopContext stshopContext)
        {
            _StshopContext = stshopContext;
        }
        public async Task<Order> AddOrderAsync(Order order)
        {
           
           
            await _StshopContext.Orders.AddAsync(order);
            await _StshopContext.SaveChangesAsync();
            return order;
           


        }
    }
}
