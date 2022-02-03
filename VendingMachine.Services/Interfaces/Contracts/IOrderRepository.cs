using System.Threading.Tasks;
using VendingMachine.Model.Models;

namespace VendingMachine.Services.Interfaces.Contracts
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        Task<Product> GetProductByOrderIdAsync(int orderId);
    }

}
