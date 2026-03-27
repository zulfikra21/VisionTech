using VisionTech.Api.Application.Interfaces;
using VisionTech.Api.Domain.Entities;
using VisionTech.Api.DTOs;

namespace VisionTech.Api.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;

        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ResponseDto<IEnumerable<Product>>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return new ResponseDto<IEnumerable<Product>> { Data = products };
        }

        public async Task<ResponseDto<Product>> GetProductByIdAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return new ResponseDto<Product> { Success = false, Message = "Product not found" };
            
            return new ResponseDto<Product> { Data = product };
        }

        public async Task<ResponseDto<Product>> CreateProductAsync(Product product)
        {
            await _productRepository.AddAsync(product);
            return new ResponseDto<Product> { Data = product, Message = "Product created successfully" };
        }

        public async Task<ResponseDto<bool>> UpdateProductAsync(Product product)
        {
            var existing = await _productRepository.GetByIdAsync(product.Id);
            if (existing == null)
                return new ResponseDto<bool> { Success = false, Message = "Product not found", Data = false };

            await _productRepository.UpdateAsync(product);
            return new ResponseDto<bool> { Data = true, Message = "Product updated successfully" };
        }

        public async Task<ResponseDto<bool>> DeleteProductAsync(Guid id)
        {
            var existing = await _productRepository.GetByIdAsync(id);
            if (existing == null)
                return new ResponseDto<bool> { Success = false, Message = "Product not found", Data = false };

            await _productRepository.DeleteAsync(id);
            return new ResponseDto<bool> { Data = true, Message = "Product deleted successfully" };
        }
    }
}
