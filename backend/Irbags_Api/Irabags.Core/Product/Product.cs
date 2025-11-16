
namespace Irabags.Core.Product
{
    public class Product
    {
        public Guid Id { get; set; }
        public decimal BasePrice { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public double Discount { get; set; }

        // Связь с Tag (один продукт - один тег)
        public Guid TagId { get; set; }
        public ProductTag Tag { get; set; }

        // Связь с ProductColorSize (один продукт - много ProductColorSize)
        public List<ProductColorSize> ProductColorSizes { get; set; }
    }
}
