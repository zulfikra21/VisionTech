using VisionTech.Api.Domain.Entities;
using VisionTech.Api.DTOs;

namespace VisionTech.Api.Application.Interfaces
{
    public interface IProductService
    {
        Task<ResponseDto<IEnumerable<Product>>> GetAllProductsAsync();
        Task<ResponseDto<Product>> GetProductByIdAsync(Guid id);
        Task<ResponseDto<Product>> CreateProductAsync(Product product);
        Task<ResponseDto<bool>> UpdateProductAsync(Product product);
        Task<ResponseDto<bool>> DeleteProductAsync(Guid id);
    }
}
