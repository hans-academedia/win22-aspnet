namespace WebApi.Models.Dtos
{
    public class Product
    {
        public string ArticleNumber { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string? ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }

        public ProductCategory ProductCategory { get; set; } = null!;
        public IEnumerable<Tag> Tags { get; set; } = new List<Tag>();
    }
}
