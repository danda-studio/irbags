
namespace Irbags.Core.Product
{
    public class ProductBlock
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public Guid ProductId { get; set; }

        public Product Product { get; set; }
    }
}
