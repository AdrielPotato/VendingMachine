using VendingMachine.Model.Models;
using VendingMachine.Services.Interfaces.Contracts;
using VendingMachine.Services.Repositories;

namespace VendingMachine.Services.Classes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VendingMachineDBContext _context;
        private ProductRepository _productRepo;
        private OrderRepository _orderRepo;
        public UnitOfWork(VendingMachineDBContext context)
        {
            this._context = context;
        }

        public IProductRepository Products => _productRepo ??= new ProductRepository(_context);
        public IOrderRepository Orders => _orderRepo ??= new OrderRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
