using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingMachine.Model.Models;
using VendingMachine.Services.DTO;

namespace VendingMachine.Services.Interfaces.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetByIdAsync(int Id);
        Task<Product> GetProductByOrderIdAsync(int Id);
        Task<Order> AddOrderAsync(CreateOrderDto createProductDto);
        Task<bool> DeleteOrderAsync(int Id);
    }
}
