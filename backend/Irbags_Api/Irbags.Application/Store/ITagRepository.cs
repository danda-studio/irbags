using Irbags.Application.Product.Models.Request;
using Irbags.Application.Product.Models.Response;

namespace Irbags.Application.Store
{
    public interface ITagRepository
    {
        Task<IReadOnlyCollection<GetTagResponse>> GetTags();
        Task<GetTagResponse?> GetTag(Guid Id);
        Task<CreateTagResponse> CreateTag(CreateTagRequest request);
        Task<UpdateTagResponse?> UpdateTag(UpdateTagRequest request);
        Task<bool> DeleteTag(Guid Id);
    }
}
