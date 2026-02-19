
using Irbags.Application.Product.Models.Request;
using Irbags.Application.Product.Models.Response;
using Irbags.Application.Store;
using Irbags.Core.Product;
using Microsoft.EntityFrameworkCore;

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
            var products = await _dbContext.Products
                .AsNoTracking()
                .Select(p => new GetProductsResponse
                {
                    Id = p.Id,
                    TagId = p.TagId,
                    Name = p.Name,
                    Price = p.BasePrice,
                    Description = p.Description,
                    ShortDescription = p.ShortDescription,
                    Discount = p.Discount,
                    Size = p.Size,
                    Tag = new TagItem
                    {
                        Id = p.Tag.Id,
                        Name = p.Tag.Name,
                    },
                    Colors = p.Colors.Select(c => new ColorItem
                    {
                        Id = c.Id,
                        Name = c.Name,
                    }).ToList(),
                    Images = p.Images.Select(i => new ImageItem
                    {
                        Id = i.Id,
                        ImageUrl = $"/images/{i.Name}{i.Extension}"
                    }).ToList()
                })
                .ToListAsync();

            return products.AsReadOnly();
        }

        public async Task<GetProductResponse> GetProduct(Guid id)
        {
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                throw new KeyNotFoundException($"Product with id {id} not found");

            return new GetProductResponse
            {
                Product = new ProductItem
                {
                    Id = product.Id,
                    TagId = product.TagId,
                    Name = product.Name,
                    Price = product.BasePrice,
                    Description = product.Description,
                    ShortDescription = product.ShortDescription,
                    Discount = product.Discount,
                    Size = product.Size,
                    Tag = new TagItem
                    {
                        Id = product.Tag.Id,
                        Name = product.Tag.Name,
                    },
                    Colors = product.Colors.Select(c => new ColorItem
                    {
                        Id = c.Id,
                        Name = c.Name,
                    }).ToList(),
                    Images = product.Images.Select(i => new ImageItem
                    {
                        Id = i.Id,
                        ImageUrl = $"/images/{i.Name}{i.Extension}"
                    }).ToList()
                }
            };
        }

        public async Task<CreateProductResponse> CreateProduct(CreateProductRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ArgumentException("Product name is required");

            if (request.Price <= 0)
                throw new ArgumentException("Product price must be greater than 0");

            if (request.TagId == Guid.Empty)
                throw new ArgumentException("TagId is required");

            var colors = await _dbContext.Colors
                .Where(c => request.ColorIds.Contains(c.Id))
                .ToListAsync();

            if (!colors.Any())
                throw new ArgumentException("At least one color is required");

            var images = request.Images?
                .Select(i => new ProductImage
                {
                    Id = Guid.NewGuid(),
                    Name = i.Key,
                    Extension = i.Image.Extension
                })
                .ToList() ?? new List<ProductImage>();

            var product = new Product
            {
                Id = request.Id,
                Name = request.Name,
                BasePrice = request.Price,
                Discount = request.Discount >= 0 ? request.Discount : 0,
                Description = request.Description,
                ShortDescription = request.ShortDescription,
                Size = request.Size,
                TagId = request.TagId,
                Colors = colors,
                Images = images,
            };

            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            return new CreateProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.BasePrice,
                Discount = product.Discount,
                Description = product.Description,
                ShortDescription = product.ShortDescription,
                Size = product.Size,
                TagId = product.TagId,
                Colors = colors.Select(c => new ColorItem
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToList()
            };
        }

        public async Task<UpdateProductResponse> UpdateProduct(UpdateProductRequest request)
        {
            var product = await _dbContext.Products
                .Include(p => p.Colors)
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == request.Id);

            if (product == null)
                throw new Exception("Product not found");

            if (!string.IsNullOrWhiteSpace(request.Name))
                product.Name = request.Name;

            if (!string.IsNullOrWhiteSpace(request.Description))
                product.Description = request.Description;

            if (!string.IsNullOrWhiteSpace(request.ShortDescription))
                product.ShortDescription = request.ShortDescription;

            if (!string.IsNullOrWhiteSpace(request.Size))
                product.Size = request.Size;

            if (request.Price > 0)
                product.BasePrice = request.Price;

            if (request.Discount > 0 && request.Discount <= 100)
                product.Discount = request.Discount;

            if (request.TagId != Guid.Empty)
                product.TagId = request.TagId;

            if (request.ColorIds != null && request.ColorIds.Count > 0)
            {
                var colors = await _dbContext.Colors
                    .Where(c => request.ColorIds.Contains(c.Id))
                    .ToListAsync();

                product.Colors = colors;
            }

            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();

            return new UpdateProductResponse
            {
                Id = product.Id,
                Name = product.Name,
            };
        }

        public async Task<bool> DeleteProduct(Guid Id)
        {
            var product = await _dbContext.Products
                .FirstOrDefaultAsync(p => p.Id == Id);

            if (product == null)
                return false;

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
