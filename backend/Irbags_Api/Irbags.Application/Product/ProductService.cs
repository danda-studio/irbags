using Irbags.Application.Photo;
using Irbags.Application.Photo.Models.Request;
using Irbags.Application.Product.Models.Request;
using Irbags.Application.Product.Models.Response;
using Irbags.Application.Store;


namespace Irbags.Application.Product
{
    public class ProductService : IProductService
    {
        private readonly IPhotoService _photoService;
        private readonly IProductRepository _productRepository;
       
        public ProductService(IPhotoService photoService, IProductRepository productRepository)
        {
            _photoService = photoService;
            _productRepository = productRepository;
        }

        public async Task<IReadOnlyCollection<GetProductsResponse>> GetProducts()
        {
            var products = await _productRepository.GetProducts();

            return products;
        }

        //public async Task<GetProductResponse> GetProduct(Guid Id)
        //{
        //    var product = await _productRepository.GetProduct(Id);

        //    var images = await _photoService.GetImages();

        //    return product ?? throw new KeyNotFoundException($"Product with id '{Id}' not found");
        //}

        public async Task<CreateProductResponse> CreateProduct(CreateProductRequest request)
        {

            var product = await _productRepository.CreateProduct(request);

            var image = await _photoService.AddImages(new AddImagesRequest
            {
                ProductId = product.Id,
                ImageItems = request.Images
            });

            return new CreateProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Discount = product.Discount,
                Description = product.Description,
                ShortDescription = product.ShortDescription,
                Size = product.Size,
                TagId = product.TagId,
                Colors = product.Colors.Select(c => new ColorItem
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToList(),
                Images = image.Images.Select(i => new Models.Response.ImageItem
                {
                    Id = i.Id,
                    ImageUrl = i.RelativeUrl
                }).ToList()
            };

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
