namespace WebApi.Models.Dtos
{
    public class Product
    {
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; } = null!;
        public IEnumerable<Tag> Tags { get; set; } = new List<Tag>();
    }
}
