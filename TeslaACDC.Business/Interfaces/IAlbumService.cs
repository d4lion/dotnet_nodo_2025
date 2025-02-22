using TeslaACDC.Data.Models;

namespace TeslaACDC.Business.Interfaces;

public interface IAlbumService
{
    Task<BaseMessage<List<Album>>> GetList();
    Task<BaseMessage<Album>> AddAlbum(Album album);
    Task<BaseMessage<Album>> FindById(int Id);
    Task<BaseMessage<List<Album>>> FindByName(string Name);
    Task<BaseMessage<List<Album>>> FindByYear(int Year);
    Task<BaseMessage<List<Album>>> FindByRangeOfYear(int StartYear, int EndYear);
    Task<BaseMessage<List<Album>>> FindByArtist(string Artist);
    Task<BaseMessage<List<Album>>> FindByGenre(string Genre);
}
