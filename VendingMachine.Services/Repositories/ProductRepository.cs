using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingMachine.Model.Models;
using VendingMachine.Model.Repositories;
using VendingMachine.Services.Interfaces.Contracts;

namespace VendingMachine.Services.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private VendingMachineDBContext DBContext { get { return Context as VendingMachineDBContext; } }
        public ProductRepository(VendingMachineDBContext context) : base(context)
        { }
        public async Task<bool> ProductExistAsync(string ProductName)
        {
            return await DBContext.Products.AnyAsync(m => m.Name.Contains(ProductName));
        }

        public async Task<bool> ProductExistAsync(int Id)
        {
            return await DBContext.Products.AnyAsync(m => m.Id == Id);
        }

        public async Task<Product> GetProductByCodeAsync(string ProductCode)
        {
            return await DBContext.Products.FirstOrDefaultAsync(m => m.ProductCode == ProductCode);
        }

        public async Task<ICollection<Product>> GetDeletedProductsAsync()
        {
            return await DBContext.Products.Where(m => m.IsDeleted == true).ToListAsync();
        }

        public async Task<bool> DisableProductAsync(string productCode)
        {
            var _exisitngProduct = await GetProductByCodeAsync(productCode);

            if (_exisitngProduct != null)
            {
                _exisitngProduct.IsDeleted = true;
                return await Save();
            }
            return false;
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            DBContext.Products.Update(product);
            return await Save();
        }

        private async Task<bool> Save()
        {
            return await DBContext.SaveChangesAsync() >= 0 ? true : false;
        }
    }
}
