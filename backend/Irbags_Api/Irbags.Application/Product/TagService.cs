using Irbags.Application.Product.Models.Request;
using Irbags.Application.Product.Models.Response;
using Irbags.Application.Store;

namespace Irbags.Application.Product
{
    public class TagService : ITagService
    {
        private ITagRepository _tagRepository;
        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<IReadOnlyCollection<GetTagResponse>> GetTags()
        {
            var tags = await _tagRepository.GetTags();

            return tags;
        }

        public async Task<GetTagResponse> GetTag(Guid Id)
        {
            var tag = await _tagRepository.GetTag(Id);
            
            return tag ?? throw new KeyNotFoundException($"Tag with id '{Id}' not found");
        }

        public async Task<CreateTagResponse> CreateTag(CreateTagRequest request)
        {
            var tag = await _tagRepository.CreateTag(request);

            return tag;
        }

        public async Task<UpdateTagResponse> UpdateTag(UpdateTagRequest request)
        {
            var tag = await _tagRepository.UpdateTag(request);
            
            return tag ?? throw new KeyNotFoundException($"Tag not found");
        }

        public async Task<bool> DeleteTag(Guid Id)
        {
            var tag = await _tagRepository.DeleteTag(Id);

            return tag;
        }

    }
}
