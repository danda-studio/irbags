using Irbags.Application.Photo.Models.Request;

namespace Irbags.Application.Product.Models.Request
{
    public class CreateProductRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public double Discount { get; set; } = 0;
        public ProductTagItem Tag { get; set; }
        public List<ProductColorItem> Colors { get; set; }
        public List<FileUploadImageItem> Images { get; set; }
    }
}
