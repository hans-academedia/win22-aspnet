namespace WebApi.Models.Interfaces
{
    public interface IProduct
    {
        public string ArticleNumber { get; set; }
        public string ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductCategoryId { get; set; }
    }
}
