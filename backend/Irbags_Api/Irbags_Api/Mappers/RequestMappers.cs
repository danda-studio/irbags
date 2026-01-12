
using Irbags.Application.Photo.Models.Request;

namespace Irbags_Api.Mappers
{
    public static class RequestMappers
    {
        public static Irbags.Application.Auth.Models.Request.LoginRequest ToApplicationLoginRequest(this AuthController.Models.Request.LoginRequest request)
            => new() { Login = request.Login, Password = request.Password };

        public static Irbags.Application.Product.Models.Request.CreateTagRequest ToApplicationCreateTagRequest(this ProductController.Models.Request.CreateTagRequest request)
            => new() { Name = request.Name};

        public static Irbags.Application.Product.Models.Request.UpdateTagRequest ToApplicationUpdateTagRequest(this ProductController.Models.Request.UpdateTagRequest request, Guid Id)
            => new() { Id = Id, Name = request.Name };

        public static Irbags.Application.Photo.Models.Request.AddImageRequest ToApplicationAddImageRequest(this ImageController.Models.Request.AddImageRequest request)
            => new() { 
                ProductId =  request.ProductId, 
                Key = request.Key, 
                Image = new FileUploadImageItem
                {
                    Content = request.Image.OpenReadStream(),
                    FileName = request.Image.FileName,
                    ContentType = request.Image.ContentType,
                    Extension = Path.GetExtension(request.Image.FileName).ToLowerInvariant()
                }
            };

        public static Irbags.Application.Photo.Models.Request.UpdateImageRequest ToApplicationUpdateImageRequest(this ImageController.Models.Request.UpdateImageRequest request, string key)
            => new() { 
                Image = new FileUploadImageItem
                {
                    Content = request.Image.OpenReadStream(),
                    FileName = request.Image.FileName,
                    ContentType = request.Image.ContentType,
                    Extension = Path.GetExtension(request.Image.FileName).ToLowerInvariant()
                }, 
                Key = key };

        public static Irbags.Application.Product.Models.Request.CreateProductRequest ToApplicationCreateProductRequest(this ProductController.Models.Request.CreateProductRequest request)
            => new() { 
                Id = request.Id,
                Name = request.Name,
                Description =  request.Description,
                ShortDescription = request.ShortDescription,
                Size = request.Size,
                Price = request.Price,
                Discount = request.Discount,
                Tag = request.Tag.ToApplicationProductTagItem(),
                Colors = request.Colors.Select(c => c.ToApplicationProductColorItem()).ToList(),
                Images = request.Images.Select(i => i.ToApplicationFileUploadImageItem()).ToList(),
            };
        public static Irbags.Application.Product.Models.Request.UpdateProductRequest ToApplicationUpdateProductRequest(this ProductController.Models.Request.UpdateProductRequest request)
            => new() { };

        public static Irbags.Application.Product.Models.Request.ProductTagItem ToApplicationProductTagItem(this ProductController.Models.Request.ProductTagItem request)
            => new() { Id = request.Id, Name = request.Name};

        public static Irbags.Application.Product.Models.Request.ProductColorItem ToApplicationProductColorItem(this ProductController.Models.Request.ProductColorItem request)
            => new() { Id = request.Id, Name = request.Name};
        public static FileUploadImageItem ToApplicationFileUploadImageItem(this IFormFile file)
        {
            if (file == null) return new FileUploadImageItem();

            return new FileUploadImageItem
            {
                Content = file.OpenReadStream(),
                FileName = file.FileName,
                ContentType = file.ContentType,
                Extension = Path.GetExtension(file.FileName).ToLowerInvariant()
            };
        }

    }
}