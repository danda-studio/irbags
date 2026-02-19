using Irbags.Application.Product.Models.Request;
using Irbags.Application.Product.Models.Response;
using Irbags.Application.Store;
using Irbags.Core.Product;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Irbags.Infrastructure
{
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TagRepository(ApplicationDbContext dbContext) 
        { 
            _dbContext = dbContext; 
        }

        public async Task<IReadOnlyCollection<GetTagResponse>> GetTags()
        {
            var tags = await _dbContext.Tags
                .AsNoTracking()
                .Select(t => new GetTagResponse
                {
                    Id = t.Id,
                    Name = t.Name,
                }).ToListAsync();
            
            return new ReadOnlyCollection<GetTagResponse>(tags);
        }

        public async Task<GetTagResponse?> GetTag(Guid Id)
        {
            var tag = await _dbContext.Tags
                .Where(t => t.Id == Id)
                .Select(t => new GetTagResponse
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .FirstOrDefaultAsync();

            return tag;
        }

        public async Task<CreateTagResponse> CreateTag(CreateTagRequest request)
        {
            var tag = new ProductTag
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            _dbContext.Tags.Add(tag);
            await _dbContext.SaveChangesAsync();

            return new CreateTagResponse
            {
                Id = tag.Id,
                Name = tag.Name
            };
        }

        public async Task<UpdateTagResponse?> UpdateTag(UpdateTagRequest request)
        {
            var tag = await _dbContext.Tags
                .FirstOrDefaultAsync(t => t.Id == request.Id);

            if (tag == null)
                return null;

            tag.Name = request.Name;
            await _dbContext.SaveChangesAsync();

            return new UpdateTagResponse
            {
                Id = tag.Id,
                Name = tag.Name
            };
        }

        public async Task<bool> DeleteTag(Guid Id)
        {
            var tag = _dbContext.Tags
                .FirstOrDefault(t => t.Id == Id);

            if (tag == null) 
              return false;

            _dbContext.Tags.Remove(tag);
            await _dbContext.SaveChangesAsync(); 
            
            return true;
        }
    }
}
