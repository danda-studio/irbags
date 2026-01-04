using Irbags.Application.Product.Models.Request;
using Irbags.Application.Product.Models.Response;
using Irbags.Application.Store;
using Irbags.Core.Product;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Irbags.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyCollection<GetProductsResponse>> GetProducts()
        {

            return new List<GetProductsResponse>();
        }

        public async Task<GetProductResponse?> GetProduct(Guid Id)
        {

            return new GetProductResponse();
        }

        public async Task<CreateProductResponse> CreateProduct(CreateProductRequest request)
        {
            return new CreateProductResponse();
        }

        public async Task<UpdateProductResponse> UpdateProduct(UpdateProductRequest request)
        {
            return new UpdateProductResponse();
        }

        public async Task<bool> DeleteProduct(Guid Id)
        {

            return true;
        }
    }
}
