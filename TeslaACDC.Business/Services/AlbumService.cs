using TeslaACDC.Business.Interfaces;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Business.Services;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

public class AlbumService : IAlbumService
{
    public async Task<List<Album>> AddAlbum()
    {
        throw new NotImplementedException();
    }


    public async Task<BaseMessage<List<Album>>> GetList()
    {
        List<Album> albums = [
            new Album{
                Name = "Back in black",
                Year = "1995",
                Id = 1,
                Genre = Genre.Rock,
                Artist = new Artist{
                    Name = "ACDC",
                    IsOnTour = true,
                    Label = "Sony",
                    Id = 1001,
                }
            },
            new Album{
                Name = "Secod Song Name",
                Year = "1990",
                Id = 2,
                Genre = Genre.Metal,
                Artist = new Artist{
                    Name = "Metallica",
                    IsOnTour = false,
                    Label = "Universal",
                    Id = 1002,
                }
            },
            new Album{
                Name = "Third Song Name",
                Year = "2005",
                Id = 3,
                Genre = Genre.Metal,
                Artist = new Artist{
                    Name = "Iron Maiden",
                    IsOnTour = true,
                    Label = "EMI",
                    Id = 1003,
                }
            },
            new Album{
                Name = "Fourth song name",
                Year = "2010",
                Id = 4,
                Genre = Genre.Metal,
                Artist = new Artist{
                    Name = "Megadeth",
                    IsOnTour = false,
                    Label = "Warner",
                    Id = 1004,
                }
            },
        ];

        return new BaseMessage<List<Album>>()
        {
            Result = albums
        };
    }
}
