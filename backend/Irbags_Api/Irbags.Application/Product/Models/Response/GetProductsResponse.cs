namespace Irbags.Application.Product.Models.Response
{
    public class GetProductsResponse
    {
        public Guid Id { get; set; }
        public Guid TagId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public double Discount { get; set; }
        public string Size { get; set; }
        public TagItem Tag { get; set; }
        public List<ColorItem> Colors { get; set; }
        public List<ImageItem> Images { get; set; }
    }
}