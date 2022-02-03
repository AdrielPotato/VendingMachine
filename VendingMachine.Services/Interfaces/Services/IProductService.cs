using System.Collections.Generic;
using System.Threading.Tasks;
using VendingMachine.Model.Models;
using VendingMachine.Services.DTO;

namespace VendingMachine.Services.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetByIdAsync(int Id);
        Task<Product> GetByProductCodeAsync(string productCode);
        Task<Product> AddProductAsync(CreateProductDto createProductDto);
        Task<Product> UpdateProductAsync(UpdateProductDto updateProductDto);
        Task<string> DeleteProductAsync(string productCode);
        Task<Product> UpdateProductQuantity(int Id, bool restock);


    }
}
