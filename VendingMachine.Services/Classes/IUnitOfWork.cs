using System;
using VendingMachine.Services.Interfaces.Contracts;

namespace VendingMachine.Services.Classes
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IOrderRepository Orders { get; }
    }
}
