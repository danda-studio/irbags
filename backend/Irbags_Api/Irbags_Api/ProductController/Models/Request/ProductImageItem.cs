namespace Irbags_Api.ProductController.Models.Request
{
    public class ProductImageItem
    {
        public string Key { get; set; }
        public IFormFile Image { get; set; }
    }
}
