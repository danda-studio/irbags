
namespace Irbags.Core.Product
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public double Discount { get; set; }
        public string Size { get; set; }
        public Guid TagId { get; set; }
        public ProductTag Tag { get; set; }
        public List<ProductColor> Colors { get; set; }
        public List<ProductImage> Images { get; set; } 
    }
}
