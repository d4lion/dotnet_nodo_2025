using TeslaACDC.Data.Models;

namespace TeslaACDC.Data.Interfaces;

public interface IAlbumRepository<TId, TEntity>
where TId : struct
where TEntity : BaseEntity<TId>
{
    Task AddAsync(TEntity album);
    Task<Album> FindByIdAsync(TId id);
    Task<List<Album>> GetAllAsync();
    Task<List<Album>> FindByArtistAsync(string Artist);
    Task<List<Album>> FindByGenreAsync(string Genre);
    Task<List<Album>> FindByNameAsync(string Name);
    Task<List<Album>> FindByRangeOfYearAsync(int StartYear, int EndYear);

}
