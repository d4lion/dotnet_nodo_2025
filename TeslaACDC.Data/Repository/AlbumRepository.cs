using System;
using Microsoft.EntityFrameworkCore;
using TeslaACDC.Data.Interfaces;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Data.Repository;

public class AlbumRepository<TId, TEntity> : IAlbumRepository<TId, TEntity>
where TId : struct
where TEntity : BaseEntity<TId>
{

    private readonly DatabaseContext _context;
    internal DbSet<TEntity> dbSet;

    public AlbumRepository(DatabaseContext context)
    {
        _context = context;
        dbSet = _context.Set<TEntity>();
    }

    public async Task AddAsync(TEntity album)
    {
        await dbSet.AddAsync(album);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Album>> FindByArtistAsync(string Artist)
    {
        return await _context.Albums.Include(x => x.Artist).Where(x => x.Artist!.Name.Equals(Artist)).ToListAsync();
    }

    public async Task<List<Album>> FindByGenreAsync(string Genre)
    {
        
        return await _context.Albums.Include(x => x.Artist).Where(x => x.Genre.ToString().Contains(Genre)).ToListAsync();
    }

    public async Task<Album> FindByIdAsync(TId id)
    {

        #pragma warning disable CS8603 // Possible null reference return.

        return await _context.Albums.Include(x => x.Artist).FirstOrDefaultAsync(x => x.Id.Equals(id) && x.Artist != null);

    }

    public async Task<List<Album>> FindByNameAsync(string Name)
    {
        return await _context.Albums.Include(x => x.Artist).Where(x => x.Name.ToLower().Contains(Name.ToLower())).ToListAsync();
    }

    public async Task<List<Album>> FindByRangeOfYearAsync(int StartYear, int EndYear)
    {
        return await _context.Albums.Include(x => x.Artist).Where(x => x.Year >= StartYear && x.Year <= EndYear).ToListAsync();
    }

    public async Task<List<Album>> GetAllAsync()
    {
        return await _context.Albums.Include(x => x.Artist).ToListAsync();
    }
}
