namespace TeslaACDC.API.Controllers;

using System.Net;
using Microsoft.AspNetCore.Mvc;
using TeslaACDC.Business.Interfaces;
using TeslaACDC.Data.Models;

[Route("api/[controller]")]
[ApiController]
public class ArtistController(IArtistService artistService) : ControllerBase
{
    private readonly IArtistService _artistService = artistService;

    [HttpGet("getArtist/{id}")]
    public async Task<IActionResult> GetArtist(int id)
    {
        var artist = await _artistService.FindById(id);
        return StatusCode((int)artist.StatusCode, artist);
    }

    [HttpGet("getAllArtists")]
    public async Task<IActionResult> GetAllArtists()
    {
        var artists = await _artistService.GetAll();
        return StatusCode((int)artists.StatusCode, artists);
    }

    [HttpPost("updateArtist")]
    public async Task<IActionResult> UpdateArtist(Artist artist)
    {
        var updatedArtistStatus = await _artistService.Update(artist);
        return StatusCode((int)updatedArtistStatus.StatusCode, updatedArtistStatus);
    }

    [HttpPost("addArtist")]
    public async Task<IActionResult> AddArtist(Artist artist)
    {
        var addedArtist = await _artistService.Add(artist);
        return StatusCode((int)addedArtist.StatusCode, addedArtist);
    }

}

