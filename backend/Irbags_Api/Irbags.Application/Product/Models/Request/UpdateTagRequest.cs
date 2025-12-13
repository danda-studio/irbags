
namespace Irbags.Application.Product.Models.Request
{
    public class UpdateTagRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
