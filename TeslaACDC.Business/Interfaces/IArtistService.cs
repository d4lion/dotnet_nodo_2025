using System.ComponentModel.DataAnnotations;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Business.Interfaces;

public interface IArtistService
{
    public Task<BaseMessage<Artist>> FindById(int id);
    public Task<BaseMessage<Artist>> Add(Artist artist);
    public Task<BaseMessage<List<Artist>>> GetAll();
    public Task<BaseMessage<Artist>> Update(Artist artist);

}
