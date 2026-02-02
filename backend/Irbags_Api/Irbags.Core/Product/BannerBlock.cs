
namespace Irbags.Core.Product
{
    public class BannerBlock
    {
        public Guid Id { get; set; }
        public Guid ImageId { get; set; }
        public string Key { get; set; }
        public ProductImage Image { get; set; }
    }
}
