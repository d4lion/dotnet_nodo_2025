using System.Net;
using TeslaACDC.Business.Interfaces;
using TeslaACDC.Data;
using TeslaACDC.Data.Interfaces;
using TeslaACDC.Data.Models;
using TeslaACDC.Data.Repository;

namespace TeslaACDC.Business.Services;

public class ArtistService(IArtistRepository<int, Artist> artistRepository) : IArtistService
{
    private readonly IArtistRepository<int, Artist> _artistRepository = artistRepository;


    public async Task<BaseMessage<Artist>> Add(Artist artist)
    {
        await _artistRepository.AddAsync(artist);
        return new BaseMessage<Artist>()
        {
            Result = artist,
            StatusCode = HttpStatusCode.Created
        };
    }

    public async Task<BaseMessage<Artist>> FindById(int id)
    {
        var foundArtist = await _artistRepository.FindByIdAsync(id);

        if (foundArtist == null)
        {
            return new BaseMessage<Artist>()
            {
                Message = "Artist not found",
                Result = null!,
                StatusCode = HttpStatusCode.NotFound
            };
        }

        return new BaseMessage<Artist>()
        {
            Result = foundArtist,
        };
    }

    public async Task<BaseMessage<List<Artist>>> GetAll()
    {
        var artists = await _artistRepository.GetAllAsync();
        return new BaseMessage<List<Artist>>()
        {
            Result = artists,
        };
    }

    public async Task<BaseMessage<Artist>> Update(Artist artist)
    {
        var result = await _artistRepository.UpdateAsync(artist);

        if (result != null)
        {
            return new BaseMessage<Artist>()
            {
                Result = artist
            };
        }

        return new BaseMessage<Artist>()
        {
            Message = "Artist not found",
            Result = null!,
            StatusCode = HttpStatusCode.NotFound
        };
    }
}
