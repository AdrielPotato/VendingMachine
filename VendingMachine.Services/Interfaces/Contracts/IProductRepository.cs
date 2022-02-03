using System.Collections.Generic;
using System.Threading.Tasks;
using VendingMachine.Model.Models;

namespace VendingMachine.Services.Interfaces.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<ICollection<Product>> GetDeletedProductsAsync();
        Task<Product> GetProductByCodeAsync(string ProductCode);
        Task<bool> ProductExistAsync(string poductCode);
        Task<bool> ProductExistAsync(int Id);
        Task<bool> DisableProductAsync(string productCode);
        Task<bool> UpdateProductAsync(Product product);
    }

}
