using Irbags.Application.Product.Models.Request;
using Irbags.Application.Product.Models.Response;

namespace Irbags.Application.Store
{
    public interface IProductRepository
    {
        Task<IReadOnlyCollection<GetProductsResponse>> GetProducts();
        //Task<GetProductResponse> GetProduct(Guid Id);
        Task<CreateProductResponse> CreateProduct(CreateProductRequest request);
        Task<UpdateProductResponse> UpdateProduct(UpdateProductRequest request);
        Task<bool> DeleteProduct(Guid Id);
    }
}