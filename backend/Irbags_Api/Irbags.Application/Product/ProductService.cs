using Irbags.Application.Photo;
using Irbags.Application.Photo.Models.Request;
using Irbags.Application.Photo.Models.Response;
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

        public async Task<GetProductResponse> GetProduct(Guid id)
        {
            var product = await _productRepository.GetProduct(id);

            if (product == null)
                throw new KeyNotFoundException($"Product with id '{id}' not found");

            // Загружаем изображения для этого продукта
            var images = await _photoService.GetImagesByProductId(id);

            // Обогащаем ответ данными изображений из базы
            product.Product.Images = images.Select(i => new Models.Response.ImageItem
            {
                Id = i.Id,
                ImageUrl = i.RelativeUrl
            }).ToList();

            return product;
        }

        public async Task<CreateProductResponse> CreateProduct(CreateProductRequest request)
        {
            // Валидация входных данных
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrWhiteSpace(request.Name))
                throw new ArgumentException("Product name is required");

            if (request.Price <= 0)
                throw new ArgumentException("Product price must be greater than 0");

            // Создаём продукт в репозитории
            var product = await _productRepository.CreateProduct(request);

            // Добавляем изображения, если они есть
            AddImagesResponse? imagesResponse = null;
            if (request.Images != null && request.Images.Count > 0)
            {
                imagesResponse = await _photoService.AddImages(new AddImagesRequest
                {
                    ProductId = product.Id,
                    ImageItems = request.Images
                });
            }

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
                Images = imagesResponse?.Images.Select(i => new Models.Response.ImageItem
                {
                    Id = i.Id,
                    ImageUrl = i.RelativeUrl
                }).ToList() ?? new List<Models.Response.ImageItem>()
            };
        }

        public async Task<UpdateProductResponse> UpdateProduct(UpdateProductRequest request)
        {
            // Валидация входных данных
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (request.Id == Guid.Empty)
                throw new ArgumentException("Product Id is required");

            // Обновляем продукт в репозитории
            var product = await _productRepository.UpdateProduct(request);

            if (product == null)
                throw new KeyNotFoundException($"Product with id '{request.Id}' not found");

            // Если передали новые изображения, добавляем их
            if (request.Images != null && request.Images.Count > 0)
            {
                await _photoService.AddImages(new AddImagesRequest
                {
                    ProductId = request.Id,
                    ImageItems = request.Images
                });
            }

            return new UpdateProductResponse
            {
                Id = product.Id,
                Name = product.Name,
            };
        }

        public async Task<bool> DeleteProduct(Guid Id)
        {
            var product = await _productRepository.DeleteProduct(Id);

            return product;
        }
    }
}
