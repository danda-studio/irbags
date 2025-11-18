
namespace Irabags.Core.Product
{
    public class ProductSize
    {
        public Guid Id { get; set; }
        public string Size { get; set; }
        public List<ProductColorSize> ProductColorSizes { get; set; }
    }
}