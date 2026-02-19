
namespace Irbags.Core.Product
{
    public class ProductImage
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public DateTime CreatedAt { get; set; }
        public Product Product { get; set; }
        public BannerBlock BannerBlock { get; set; }

    }
}
