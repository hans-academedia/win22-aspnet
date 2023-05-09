using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Models.Dtos;
using WebApi.Models.Interfaces;

namespace WebApi.Models.Entities;

public class ProductEntity : IProduct
{
    [Key]
    public string ArticleNumber { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public string? ProductDescription { get; set; }

    [Column(TypeName = "money")]
    public decimal ProductPrice { get; set; }
    public int ProductCategoryId { get; set; }
    public string? ProductImage { get; set; }
    



    public ProductCategoryEntity ProductCategory { get; set; } = null!;
    public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();

    public static implicit operator Product(ProductEntity entity)
    {
        if (entity != null)
        {
            return new Product
            {
                ArticleNumber = entity.ArticleNumber,
                ProductName = entity.ProductName,
                ProductDescription = entity.ProductDescription,
                ProductPrice = entity.ProductPrice,
                ProductCategory = entity.ProductCategory
            };
        }

        return null!;
    }
}
