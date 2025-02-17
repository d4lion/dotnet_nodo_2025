using System.Net;
using Microsoft.AspNetCore.Mvc;
using TeslaACDC.Business.Interfaces;

namespace TeslaACDC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController(IAlbumService albumService) : ControllerBase
    {

        private readonly IAlbumService _albumService = albumService;

        [HttpGet("albums")]
        public async Task<IActionResult> GetAlbum()
        {
            var resultData = await _albumService.GetList();
            return resultData.StatusCode == HttpStatusCode.OK ? Ok(resultData) : StatusCode((int)resultData.StatusCode, resultData); ;
        }

        [HttpGet("findById")]
        public async Task<IActionResult> FindById(int Id)
        {
            var resultData = await _albumService.FindById(Id);
            Console.WriteLine(Id);
            return resultData.StatusCode == HttpStatusCode.OK ? Ok(resultData) : StatusCode((int)resultData.StatusCode, resultData);
        }

        [HttpGet("findByName")]
        public async Task<IActionResult> FindByName(string Name)
        {
            var result = await _albumService.FindByName(Name);
            return result.StatusCode == HttpStatusCode.OK ? Ok(result) : StatusCode((int)result.StatusCode, result);
        }



        [HttpGet("findByArtist")]
        public async Task<IActionResult> FindByArtist(string Artist)
        {
            var result = await _albumService.FindByArtist(Artist);
            return result.StatusCode == HttpStatusCode.OK ? Ok(result) : StatusCode((int)result.StatusCode, result);
        }

        [HttpGet("findByGenre")]
        public async Task<IActionResult> FindByGenre(string Genre)
        {
            var result = await _albumService.FindByGenre(Genre);
            return result.StatusCode == HttpStatusCode.OK ? Ok(result) : StatusCode((int)result.StatusCode, result);
        }

        [HttpGet("findByRangeOfYear")]
        public async Task<IActionResult> FindByRangeOfYear(int StartYear, int EndYear)
        {
            var result = await _albumService.FindByRangeOfYear(StartYear, EndYear);
            return result.StatusCode == HttpStatusCode.OK ? Ok(result) : StatusCode((int)result.StatusCode, result);
        }

        [HttpGet("findByYear")]
        public async Task<IActionResult> FindByYear(int Year)
        {
            var result = await _albumService.FindByYear(Year);
            return result.StatusCode == HttpStatusCode.OK ? Ok(result) : StatusCode((int)result.StatusCode, result);
        }

    }
}
