using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using WebApp.Models.Dtos;

namespace WebApp.Models.ViewModels
{
    public class ProductRegistrationViewModel
    {
        [Display(Name = "Article Number")]
        public string ArticleNumber { get; set; } = null!;

        [Display(Name = "Product Name")]
        public string ProductName { get; set; } = null!;

        [Display(Name = "Product Description")]
        public string? ProductDescription { get; set; }

        [Display(Name = "Product Price (SEK)")]
        public decimal ProductPrice { get; set; }

        public int ProductCategoryId { get; set; }
        public List<SelectListItem> ProductCategoryOptions { get; set; } = new List<SelectListItem>();





        [Display(Name = "Tags (seperate by ; to add more then one tag)")]
        public string? TagList { get; set; }
        public List<string> Tags { get; set; } = new List<string>();


        [Display(Name = "Product Image")]
        [DataType(DataType.Upload)]
        public IFormFile? ProductImageUpload { get; set; }
    }
}
