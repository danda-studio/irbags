
namespace Irabags.Core.Product
{
    public class ProductColor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        // Ñâÿçü ñ ProductColorSize
        public List<ProductColorSize> ProductColorSizes { get; set; }
    }
}