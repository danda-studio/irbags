
namespace Irabags.Core.Product
{
    public class Product
    {
        public Guid Id { get; set; }
        public decimal BasePrice { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public double Discount { get; set; }
        public Guid TagId { get; set; }
        public ProductTag Tag { get; set; }
        public List<ProductColorSize> ProductColorSizes { get; set; }
    }
}
