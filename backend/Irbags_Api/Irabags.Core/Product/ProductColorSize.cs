
namespace Irabags.Core.Product
{
    public class ProductColorSize
    {
        public Guid Id { get; set; }

        // Внешние ключи
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid ColorId { get; set; }
        public ProductColor Color { get; set; }

        public Guid SizeId { get; set; }
        public ProductSize Size { get; set; }
    }
}