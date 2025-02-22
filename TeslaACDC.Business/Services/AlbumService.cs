using System.Net;
using TeslaACDC.Business.Interfaces;
using TeslaACDC.Data.Interfaces;
using TeslaACDC.Data.Models;


namespace TeslaACDC.Business.Services;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

public class AlbumService(IAlbumRepository<int, Album> albumRepository) : IAlbumService
{
    private readonly IAlbumRepository<int, Album> _albumRepository = albumRepository;

    public async Task<BaseMessage<Album>> AddAlbum(Album album)
    {
        await _albumRepository.AddAsync(album);
        return new BaseMessage<Album>()
        {
            Result = album,
            StatusCode = HttpStatusCode.Created
        };
    }

    public async Task<BaseMessage<List<Album>>> FindByArtist(string Artist)
    {
        var result = await _albumRepository.FindByArtistAsync(Artist);

        if (result.Count > 0)
        {
            return BuilderResponse(result);
        }

        return BuilderResponse(result!, statusCode: HttpStatusCode.NotFound, message: $"Not albums founded with artist: {Artist}");
    }

    public async Task<BaseMessage<List<Album>>> FindByGenre(string Genre)
    {
        var result = await _albumRepository.FindByGenreAsync(Genre);

        if (result.Count > 0)
        {
            return BuilderResponse(result);
        }


        return BuilderResponse(result!, statusCode: HttpStatusCode.NotFound, message: $"Not albums founded with genre: {Genre}");
    }

    public async Task<BaseMessage<Album>> FindById(int Id)
    {
        var result = await _albumRepository.FindByIdAsync(Id);

        if (result != null)
        {
            return new BaseMessage<Album>()
            {
                Result = result
            };
        }

        return new BaseMessage<Album>()
        {
            StatusCode = HttpStatusCode.NotFound,
            Message = $"Not album founded with id: {Id}",
            Result = null!
        };
    }

    public async Task<BaseMessage<List<Album>>> FindByName(string Name)
    {
        var result = await _albumRepository.FindByNameAsync(Name);

        if (result.Count > 0)
        {
            return BuilderResponse(result);
        }

        return BuilderResponse(result!, statusCode: HttpStatusCode.NotFound, message: $"Not albums founded with name: {Name}");
    }

    public async Task<BaseMessage<List<Album>>> FindByRangeOfYear(int StartYear, int EndYear)
    {
        var result = await _albumRepository.FindByRangeOfYearAsync(StartYear, EndYear);

        if (result.Count > 0)
        {
            return BuilderResponse(result);
        }
       
       return BuilderResponse(result!, statusCode: HttpStatusCode.NotFound, message: $"Not albums founded with range of year: {StartYear} - {EndYear}");
    }

    public async Task<BaseMessage<List<Album>>> FindByYear(int Year)
    {
        var result = await _albumRepository.FindByRangeOfYearAsync(Year, Year);

        if (result.Count > 0)
        {
            return BuilderResponse(result);
        }

        return BuilderResponse(result!, statusCode: HttpStatusCode.NotFound, message: $"Not albums founded with year: {Year}");

    }

    public async Task<BaseMessage<List<Album>>> GetList()
    {
        var result = await _albumRepository.GetAllAsync();

        if (result.Count > 0)
        {        
            return BuilderResponse(result);
        }

        return BuilderResponse(result!, statusCode: HttpStatusCode.NotFound, message: "Not albums founded");
    }

    private BaseMessage<List<Album>> BuilderResponse(List<Album> data, HttpStatusCode statusCode = HttpStatusCode.OK, string message = "Success")
    {
        return new BaseMessage<List<Album>>
        {
            Result = data,
            StatusCode = statusCode,
            Message = message
        };
    }
}
