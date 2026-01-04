using Irbags.Application.Product.Models.Request;
using Irbags.Application.Product.Models.Response;
using Irbags.Application.Store;

namespace Irbags.Application.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IReadOnlyCollection<GetProductsResponse>> GetProducts()
        {
            var products = await _productRepository.GetProducts();

            return products;
        }

        public async Task<GetProductResponse> GetProduct(Guid Id)
        {
            var product = await _productRepository.GetProduct(Id);

            return product ?? throw new KeyNotFoundException($"Product with id '{Id}' not found");
        }

        public async Task<CreateProductResponse> CreateProduct(CreateProductRequest request)
        {
            var product = await _productRepository.CreateProduct(request);

            return product;
        }

        public async Task<UpdateProductResponse> UpdateProduct(UpdateProductRequest request)
        {
            var product = await _productRepository.UpdateProduct(request);

            return product ?? throw new KeyNotFoundException($"Product not found");
        }

        public async Task<bool> DeleteProduct(Guid Id)
        {
            var product = await _productRepository.DeleteProduct(Id);

            return product;
        }
    }
}
