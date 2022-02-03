using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VendingMachine.Model.Models;
using VendingMachine.Services.Classes;
using VendingMachine.Services.DTO;
using VendingMachine.Services.Interfaces.Services;

namespace VendingMachine.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }
        public async Task<Product> AddProductAsync(CreateProductDto createProductDto)
        {
            //Check If product exist
            if (await _unitOfWork.Products.GetProductByCodeAsync(createProductDto.ProductCode) != null)
                return null;

            Product _newProduct = new Product()
            {
                Name = createProductDto.ProductName,
                ProductCode = createProductDto.ProductCode,
                Price = createProductDto.Price,
                QtyStock = 10,
                CategoryTypeId = createProductDto.CategoryTypeId,
                IsDeleted = false
            };
            //Add new record
            if (!await _unitOfWork.Products.CreateAsync(_newProduct))
            {
                return _newProduct;
            }

            return _newProduct;
        }

        public async Task<Product> GetByProductCodeAsync(string ProductCode)
        {
            return await _unitOfWork.Products.GetProductByCodeAsync(ProductCode);
        }

        public async Task<Product> GetByIdAsync(int Id)
        {
            return await _unitOfWork.Products.GetByIdAsync(Id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _unitOfWork.Products.GetAllAsync();
        }

        public async Task<string> DeleteProductAsync(string ProductCode)
        {

            //check if record exist
            if (await _unitOfWork.Products.ProductExistAsync(ProductCode))
            {
                bool isSuccesful = await _unitOfWork.Products.DisableProductAsync(ProductCode);
            }

            return ProductCode;
        }

        public async Task<Product> UpdateProductQuantity(int id,bool restock)
        {
            

            //check if record exist
            var _existingProduct = await _unitOfWork.Products.GetByIdAsync(id);

            //Update
            if (_existingProduct.QtyStock > 0 && !restock)
                _existingProduct.QtyStock--;
            else if (restock)
                _existingProduct.QtyStock = 10;
            else
                return null;

            if (!await _unitOfWork.Products.UpdateProductAsync(_existingProduct))
            {
            }
            return _existingProduct;
        }

        public Task<Product> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            throw new System.NotImplementedException();
        }

    }
}
