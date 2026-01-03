using Irbags.Application.Product.Models.Request;
using Irbags.Application.Product.Models.Response;
using Irbags.Application.Store;

namespace Irbags.Application.Product
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IReadOnlyCollection<GetTagResponse>> GetTags()
        {
            var tags = await _productRepository.GetTags();

            return tags;
        }

        public async Task<GetTagResponse> GetTag(Guid Id)
        {
            var tag = await _productRepository.GetTag(Id);
            
            return tag ?? throw new KeyNotFoundException($"Tag with id '{Id}' not found");
        }

        public async Task<CreateTagResponse> CreateTag(CreateTagRequest request)
        {
            var tag = await _productRepository.CreateTag(request);

            return tag;
        }

        public async Task<UpdateTagResponse> UpdateTag(UpdateTagRequest request)
        {
            var tag = await _productRepository.UpdateTag(request);
            
            return tag ?? throw new KeyNotFoundException($"Tag not found");
        }

        public async Task<bool> DeleteTag(Guid Id)
        {
            var tag = await _productRepository.DeleteTag(Id);

            return tag;
        }

    }
}
