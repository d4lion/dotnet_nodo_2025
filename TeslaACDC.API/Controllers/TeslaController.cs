namespace TeslaACDC.API.Controllers;

using System.Net;
using Microsoft.AspNetCore.Mvc;
using TeslaACDC.Business.Interfaces;
using TeslaACDC.Data.DTO;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

[ApiController, Route("api/[controller]")]
public class TeslaController(IAlbumService albumService) : ControllerBase
{
    private readonly IAlbumService _albumService = albumService;



    [HttpGet("almbums")]
    public async Task<IActionResult> GetAlbum()
    {
        var resultData = await _albumService.GetList();
        return resultData.StatusCode == HttpStatusCode.OK ? Ok(resultData) : StatusCode((int)resultData.StatusCode, resultData); ;
    }

    

}