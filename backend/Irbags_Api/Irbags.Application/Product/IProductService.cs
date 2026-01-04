using Irbags.Application.Product.Models.Request;
using Irbags.Application.Product.Models.Response;

namespace Irbags.Application.Product
{
    public interface IProductService
    {
        public Task<GetProductResponse> GetProduct(Guid Id);
        public Task<IReadOnlyCollection<GetProductsResponse>> GetProducts();
        public Task<CreateProductResponse> CreateProduct(CreateProductRequest request);
        public Task<UpdateProductResponse> UpdateProduct(UpdateProductRequest request);
        public Task<bool> DeleteProduct(Guid Id);
    }
}
