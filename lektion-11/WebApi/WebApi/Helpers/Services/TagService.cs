using System.Linq.Expressions;
using WebApi.Helpers.Repositories;
using WebApi.Models.Dtos;
using WebApi.Models.Entities;

namespace WebApi.Helpers.Services
{
    public class TagService
    {
        private readonly TagRepository _tagRepo;

        public TagService(TagRepository tagRepo)
        {
            _tagRepo = tagRepo;
        }

        public async Task<Tag> GetOrCreateAsync(TagEntity entity)
        {
            var _entity = await GetAsync(x => x.TagName == entity.TagName);
            _entity ??= await CreateAsync(entity);

            return _entity;
        }


        public async Task<Tag> GetAsync(Expression<Func<TagEntity, bool>> expression)
        {
            var _entity = await _tagRepo.GetAsync(expression);
            return _entity!;
        }

        public async Task<Tag> CreateAsync(TagEntity entity)
        {
            var _entity = await _tagRepo.AddAsync(entity);
            return _entity!;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            var entities = await _tagRepo.GetAllAsync();
            var _entities = new List<Tag>();
            foreach (var entity in entities)
                _entities.Add(entity);

            return _entities;
        }
    }
}
