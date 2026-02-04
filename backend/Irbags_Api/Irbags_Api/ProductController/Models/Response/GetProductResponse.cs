using Irbags.Application.Product.Models.Response;

namespace Irbags_Api.ProductController.Models.Response
{
    public class GetProductResponse
    {
        public List<ProductItem> Products { get; set; }
    }
}
