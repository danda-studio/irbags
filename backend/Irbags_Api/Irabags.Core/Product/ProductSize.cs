
namespace Irabags.Core.Product
{
    public class ProductSize
    {
        public Guid Id { get; set; }
        public string Size { get; set; }

        // Ñâÿçü ñ ProductColorSize
        public List<ProductColorSize> ProductColorSizes { get; set; }
    }
}