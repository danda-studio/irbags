using Irbags.Application.Auth.Models.Request;
using Irbags_Api.AuthController.Models.Request;

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
            => new() { ProductId =  request.ProductId, Key = request.Key, Image = request.Image};

        public static Irbags.Application.Photo.Models.Request.UpdateImageRequest ToApplicationUpdateImageRequest(this ImageController.Models.Request.UpdateImageRequest request, string key)
            => new() { Image = request.Image, Key = key };

    }
}