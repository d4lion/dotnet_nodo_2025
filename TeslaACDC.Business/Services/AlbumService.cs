using System.Net;
using System.Text;
using TeslaACDC.Business.Interfaces;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Business.Services;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

public class AlbumService : IAlbumService
{
    readonly List<Album> albums = [
            new Album{
                Name = "Back in black",
                Year = "1995",
                Id = 1,
                Genre = Genre.Rock,
                // Artist = new Artist{
                //     Name = "ACDC",
                //     IsOnTour = true,
                //     Label = "Sony",
                //     Id = 1001,
                // }
            },
            new Album{
                Name = "Secod Song Name",
                Year = "1990",
                Id = 2,
                Genre = Genre.Metal,
                // Artist = new Artist{
                //     Name = "Metallica",
                //     IsOnTour = false,
                //     Label = "Universal",
                //     Id = 1002,
                // }
            },
            new Album{
                Name = "Third Song Name",
                Year = "2005",
                Id = 3,
                Genre = Genre.Metal,
                // Artist = new Artist{
                //     Name = "Iron Maiden",
                //     IsOnTour = true,
                //     Label = "EMI",
                //     Id = 1003,
                // }
            },
            new Album{
                Name = "Fourth song name",
                Year = "2010",
                Id = 4,
                Genre = Genre.Metal,
                // Artist = new Artist{
                //     Name = "Megadeth",
                //     IsOnTour = false,
                //     Label = "Warner",
                //     Id = 1004,
                // }
            },
        ];
    public async Task<List<Album>> AddAlbum()
    {
        throw new NotImplementedException();
    }

    public async Task<BaseMessage<List<Album>>> FindByArtist(string Artist)
    {
        // var result = albums.FindAll(x => x.Artist.Name.Contains(Artist, StringComparison.CurrentCultureIgnoreCase)).ToList();

        // if (result.Count == 0)
        // {
        //     return BuilderResponse(result, statusCode: HttpStatusCode.NotFound, message: $"Not albums founded with artist: {Artist}");
        // }
        // return BuilderResponse(result);

        return BuilderResponse(new List<Album>(), statusCode: HttpStatusCode.NotImplemented, message: $"Service disabled temporarily");
    }

    public async Task<BaseMessage<List<Album>>> FindByGenre(string Genre)
    {
        var result = albums.FindAll(x => x.Genre.ToString().Contains(Genre, StringComparison.CurrentCultureIgnoreCase)).ToList();

        if (result.Count == 0)
        {
            return BuilderResponse(result, statusCode: HttpStatusCode.NotFound, message: $"Not albums founded with genre: {Genre}");
        }

        return BuilderResponse(result);

    }

    public async Task<BaseMessage<List<Album>>> FindById(int Id)
    {
        var result = albums.Where(x => x.Id == Id).ToList();

        if (result.Count == 0) {
            return BuilderResponse(result, statusCode: HttpStatusCode.NotFound, message: $"Not album found with Id: {Id}");
        }


        return BuilderResponse(result);
    }

    public async Task<BaseMessage<List<Album>>> FindByName(string Name)
    {
        var result = albums.FindAll(x => x.Name.ToLower().Contains(Name.ToLower())).ToList();

        if (result.Count == 0)
        {
            return BuilderResponse(result, statusCode: HttpStatusCode.NotFound, message: $"Not albums founded with name: {Name}");
        }

        return BuilderResponse(result);

    }

    public async Task<BaseMessage<List<Album>>> FindByRangeOfYear(int StartYear, int EndYear)
    {
        var result = albums.FindAll(x => int.TryParse(x.Year, out int year) && year >= StartYear && year <= EndYear).ToList();

        if (result.Count == 0)
        {
            return BuilderResponse(result, statusCode: HttpStatusCode.NotFound, message: $"Not albums founded between {StartYear} and {EndYear}");
        }

        return BuilderResponse(result);


    }

    public async Task<BaseMessage<List<Album>>> FindByYear(int Year)
    {
        var result = albums.FindAll(x => x.Year == Year.ToString()).ToList();

        if (result.Count == 0)
        {
            return BuilderResponse(result, statusCode: HttpStatusCode.NotFound, message: $"Not albums founded with year: {Year}");
        }
    
        return BuilderResponse(result);

    }

    public async Task<BaseMessage<List<Album>>> GetList()
    {
        return BuilderResponse(albums);
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
