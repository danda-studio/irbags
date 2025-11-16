
namespace Irabags.Core.Product
{
    public class ProductTag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        // Обратная связь: один тег - много продуктов
        public List<Product> Products { get; set; }
    }
}