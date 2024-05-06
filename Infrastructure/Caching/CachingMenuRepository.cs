using Domain.Menus;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Caching;

public class CachingMenuRepository : IMenuRepository
{
    private readonly IMenuRepository _repository;
    private readonly IMemoryCache _cache;

    public CachingMenuRepository(
        IMenuRepository repository,
        IMemoryCache cache)
    {
        this._repository = repository;
        this._cache = cache;
    }
    public async Task<IEnumerable<MenuItem>> GetAllByIdAsync(Guid id)
    {
        string key = $"menu-{id}";
        if (!_cache.TryGetValue(key, out IEnumerable<MenuItem>? cacheValue))
        {
            cacheValue = await _repository.GetAllByIdAsync(id);

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

            _cache.Set(key, cacheValue, cacheEntryOptions);
        }

        return cacheValue;
    }

    public async Task<IEnumerable<MenuItem>> GetByCategoryIdAsync(Guid id)
    {
        string key = $"categoryid-{id}";
        if (!_cache.TryGetValue(key, out IEnumerable<MenuItem>? cacheValue))
        {
            cacheValue = await _repository.GetByCategoryIdAsync(id);

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(10));

            _cache.Set(key, cacheValue, cacheEntryOptions);
        }

        return cacheValue;
    }
}
