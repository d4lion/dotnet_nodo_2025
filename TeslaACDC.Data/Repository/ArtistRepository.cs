using Microsoft.EntityFrameworkCore;
using TeslaACDC.Data.Interfaces;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Data.Repository;

public class ArtistRepository<TId, TEntity> : IArtistRepository<TId, TEntity>
where TId : struct
where TEntity : BaseEntity<TId>
{

    private readonly DatabaseContext _context;
    internal DbSet<TEntity> dbSet;

    public ArtistRepository(DatabaseContext context)
    {
        _context = context;
        dbSet = _context.Set<TEntity>();
    }

    public async Task AddAsync(TEntity artist)
    {
        await dbSet.AddAsync(artist);
        await _context.SaveChangesAsync();
    }

    public async Task<TEntity> FindByIdAsync(TId id)
    {
        var result = await dbSet.FindAsync(id);
        return result!;
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public async Task<TEntity> UpdateAsync(TEntity artist)
    {
        try
        {
            _context.Update(artist);
            await _context.SaveChangesAsync();
            return artist;
        }
        catch
        {
            return null!;
        }
    }

}
