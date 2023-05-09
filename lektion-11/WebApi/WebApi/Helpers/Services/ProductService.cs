using WebApi.Helpers.Repositories;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Models.Schemas;

namespace WebApi.Helpers.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepo;
        private readonly TagService _tagService;
        private readonly ProductTagRepository _productTagRepository;


        public ProductService(ProductRepository productRepo, TagService tagService, ProductTagRepository productTagRepository)
        {
            _productRepo = productRepo;
            _tagService = tagService;
            _productTagRepository = productTagRepository;
        }

        public async Task<Product> CreateAsync(ProductSchema schema)
        {
            ProductEntity entity = schema;
            entity = await _productRepo.AddAsync(entity);
            if (entity != null) 
            { 
                foreach(var tagName in schema.Tags)
                {
                    var tag = await _tagService.GetOrCreateAsync(new TagEntity { TagName = tagName });
                    await _productTagRepository.AddAsync(new ProductTagEntity
                    {
                        ArticleNumber = entity.ArticleNumber,
                        TagId = tag.Id,
                    });
                }
            
                return await GetAsync(entity.ArticleNumber);
            }
            
            return null!;
        }

        public async Task<Product> GetAsync(string articleNumber)
        {
            var entity = await _productRepo.GetAsync(x => x.ArticleNumber == articleNumber);
            if (entity != null)
            {
                Product product = entity;

                if (entity.ProductTags.Count > 0)
                {
                    var tagList = new List<Tag>();

                    foreach (var productTag in entity.ProductTags)
                        tagList.Add(new Tag { Id = productTag.Tag.Id, TagName = productTag.Tag.TagName });

                    product.Tags = tagList;
                }

                return product;
            }

            return null!;
        }

        public async Task<Product> GetAllAsync()
        {
            var result = await _productRepo.GetAllAsync();
            var list = new List<Product>();
            foreach (var entity in result)
            {
                Product product = entity;

                if (entity.ProductTags.Count > 0)
                {
                    var tagList = new List<Tag>();

                    foreach (var productTag in entity.ProductTags)
                        tagList.Add(new Tag { Id = productTag.Tag.Id, TagName = productTag.Tag.TagName });

                    product.Tags = tagList;
                }

                list.Add(product);
            }

            return null!;
        }
    }
}
