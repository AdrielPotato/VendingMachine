using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using VendingMachine.Model.Models;
using VendingMachine.Model.Repositories;
using VendingMachine.Services.Interfaces.Contracts;

namespace VendingMachine.Services.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private VendingMachineDBContext DBContext { get { return Context as VendingMachineDBContext; } }
        public OrderRepository(VendingMachineDBContext context) : base(context)
        { }

        public async Task<Product> GetProductByOrderIdAsync(int productId)
        {
            return await DBContext.Orders?.Where(m => m.Product.Id == productId)?.Select(m => m.Product)?.FirstOrDefaultAsync();
        }

    }
}
