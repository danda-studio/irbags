
using Irbags.Application.Product.Models.Request;
using Irbags.Application.Product.Models.Response;

namespace Irbags.Application.Product
{
    public interface IProductService
    {
        public Task<GetTagResponse> GetTag(Guid tagId);
        Task<IReadOnlyCollection<GetTagResponse>> GetTags();
        public Task<CreateTagResponse> CreateTag(CreateTagRequest request);
        public Task<UpdateTagResponse> UpdateTag(UpdateTagRequest request);
        public Task<bool> DeleteTag(Guid tagId);
        
    }
}
