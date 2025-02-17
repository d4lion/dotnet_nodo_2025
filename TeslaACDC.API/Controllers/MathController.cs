namespace TeslaACDC.API.Controllers;

using System.Net;
using Microsoft.AspNetCore.Mvc;
using TeslaACDC.Business.Interfaces;
using TeslaACDC.Data.DTO;

[Route("api/[controller]")]
[ApiController]
public class MathController(IMatematikaService matematikaService) : ControllerBase
{
    private readonly IMatematikaService _matematikaService = matematikaService;

    [HttpPost("sum")]
    public async Task<IActionResult> SumNumbers([FromBody] TwiceNumbers twiceNumbers)
    {
        var result = await _matematikaService.SumNumbers(twiceNumbers);
        return result.StatusCode == HttpStatusCode.OK ? Ok(result) : StatusCode((int)result.StatusCode, result);
    }

    [HttpPost("multiply")]
    public async Task<IActionResult> MultiplyNumbers([FromBody] TwiceNumbers twiceNumbers)
    {
        var result = await _matematikaService.MultiplyNumbers(twiceNumbers);
        return result.StatusCode == HttpStatusCode.OK ? Ok(result) : StatusCode((int)result.StatusCode, result);
    }

    [HttpPost("divide")]
    public async Task<IActionResult> DivideNumbers([FromBody] TwiceNumbers twiceNumbers)
    {
        var result = await _matematikaService.DivideNumbers(twiceNumbers);
        return result.StatusCode == HttpStatusCode.OK ? Ok(result) : StatusCode((int)result.StatusCode, result);
    }
}

