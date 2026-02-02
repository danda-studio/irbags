
namespace Irbags.Core.Product
{
    public class ProductColor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}