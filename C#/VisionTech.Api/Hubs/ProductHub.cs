using Microsoft.AspNetCore.SignalR;
using VisionTech.Api.Application.Interfaces;
using VisionTech.Api.Domain.Entities;
using VisionTech.Api.DTOs;

namespace VisionTech.Api.Hubs
{
    public class ProductHub : Hub
    {
        private readonly IProductService _productService;

        public ProductHub(IProductService productService)
        {
            _productService = productService;
        }

        public async Task GetProducts()
        {
            var result = await _productService.GetAllProductsAsync();
            await Clients.Caller.SendAsync("ReceiveAllProducts", result.Data);
        }

        public async Task CreateProduct(Product product)
        {
            var result = await _productService.CreateProductAsync(product);
            if (result.Success)
            {
                // Broadcast the new product to everyone
                await Clients.All.SendAsync("ProductCreated", result.Data);
            }
            else
            {
                // Send error back to caller
                await Clients.Caller.SendAsync("Error", result.Message);
            }
        }
    }
}
