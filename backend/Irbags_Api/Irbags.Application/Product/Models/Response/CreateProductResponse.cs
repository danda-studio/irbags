

namespace Irbags.Application.Product.Models.Response
{
    public class CreateProductResponse
    {
        public Guid Id { get; set; }
        public Guid TagId { get; set; }
        public List<ColorItem> Colors { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public double Discount { get; set; } = 0;
        public List<ImageItem> Images { get; set; }
    }
}
