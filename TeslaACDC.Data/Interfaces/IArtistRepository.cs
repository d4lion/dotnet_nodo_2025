using TeslaACDC.Data.Models;

namespace TeslaACDC.Data.Interfaces;

public interface IArtistRepository<TId, TEntity>
where TId : struct
where TEntity : BaseEntity<TId>
{
    Task AddAsync(TEntity artist);
    Task<TEntity> UpdateAsync(TEntity artist);
    Task<TEntity> FindByIdAsync(TId id);
    Task<List<TEntity>> GetAllAsync();

}
