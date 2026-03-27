using Microsoft.AspNetCore.Mvc;
using VisionTech.Api.Application.Interfaces;
using VisionTech.Api.Domain.Entities;
using VisionTech.Api.DTOs;

namespace VisionTech.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<IEnumerable<Product>>>> GetAll()
        {
            var result = await _productService.GetAllProductsAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<Product>>> GetById(Guid id)
        {
            var result = await _productService.GetProductByIdAsync(id);
            if (!result.Success)
                return NotFound(result);
            
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<Product>>> Create(Product product)
        {
            var result = await _productService.CreateProductAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<bool>>> Update(Guid id, Product product)
        {
            if (id != product.Id)
                return BadRequest(new ResponseDto<bool> { Success = false, Message = "Id mismatch" });

            var result = await _productService.UpdateProductAsync(product);
            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<bool>>> Delete(Guid id)
        {
            var result = await _productService.DeleteProductAsync(id);
            if (!result.Success)
                return NotFound(result);

            return Ok(result);
        }
    }
}
