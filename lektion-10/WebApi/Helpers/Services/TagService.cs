using WebApi.Helpers.Repositories;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;
using WebApi.Models.Schemas;

namespace WebApi.Helpers.Services
{
    public class TagService
    {
        private readonly TagRepo _tagRepo;

        public TagService(TagRepo tagRepo)
        {
            _tagRepo = tagRepo;
        }


        public async Task<Tag> CreateTagAsync(string tagName)
        {
            var entity = new TagEntity { TagName = tagName };
            var result = await _tagRepo.AddAsync(entity);
            return result;
        }

        public async Task<Tag> CreateTagAsync(TagSchema tagSchema)
        {
            var result = await _tagRepo.AddAsync(tagSchema);
            return result;
        }

        public async Task<Tag> GetTagAsync(string tagName)
        {
            var result = await _tagRepo.GetAsync(x => x.TagName == tagName);
            return result;
        }

        public async Task<Tag> GetTagAsync(TagSchema tagSchema)
        {
            var result = await _tagRepo.GetAsync(x => x.TagName == tagSchema.TagName);
            return result;
        }

        public async Task<IEnumerable<Tag>> GetTagsAsync()
        {
            var result = await _tagRepo.GetAllAsync();
            var list = new List<Tag>();
            foreach (var tag in result)
                list.Add(tag);

            return list;
        }

        public async Task<Tag> UpdateTagAsync(Tag tag)
        {
            var entity = await _tagRepo.GetAsync(x => x.Id == tag.Id);
            if (entity != null)
            {
                entity.TagName = tag.TagName;
                var result = await _tagRepo.UpdateAsync(entity);
                return result;
            }

            return null!;
        }

        public async Task<bool> DeleteTagAsync(int id)
        {
            var entity = await _tagRepo.GetAsync(x => x.Id == id);
            return await _tagRepo.DeleteAsync(entity);        
        }

        public async Task<bool> DeleteTagAsync(string tagName)
        {
            var entity = await _tagRepo.GetAsync(x => x.TagName == tagName);
            return await _tagRepo.DeleteAsync(entity);
        }

        public async Task<bool> DeleteTagAsync(Tag tag)
        {
            var entity = await _tagRepo.GetAsync(x => x.Id == tag.Id);
            return await _tagRepo.DeleteAsync(entity);
        }
    }
}
