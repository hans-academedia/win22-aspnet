namespace WebApp.Models.Dtos
{
    public class Product
    {
        public string? ArticleNumber { get; set; }
        public string? BarCode { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public string? ImageName { get; set; }
    
    
        public static implicit operator CollectionItem(Product item)
        {
            return new CollectionItem
            {
                ItemId = item.ArticleNumber,
                Title = item.Name,
                Price = item.Price.ToString(),
                ImageUrl = item.ImageName
            };
        }
    }
}
