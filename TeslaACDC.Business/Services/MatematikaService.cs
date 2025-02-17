using System.Net;
using TeslaACDC.Business.Interfaces;
using TeslaACDC.Data.DTO;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Business.Services;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously

public class MatematikaService : IMatematikaService
{
    public async Task<BaseMessage<string>> DivideNumbers(TwiceNumbers data)
    {
        if (data.Num2 == 0) {
            return new BaseMessage<string>()
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Result = "",
                Message = "No se puede divir entre cero"
            };
        }

        return new BaseMessage<string>()
        {
            Result = Math.Round(data.Num1 / data.Num2, 2).ToString()
        };
    }

    public async Task<BaseMessage<string>> MultiplyNumbers(TwiceNumbers data)
    {
        return new BaseMessage<string>
        {
            Result = (data.Num1 * data.Num2).ToString()
        };
    }

    public async Task<BaseMessage<string>> SquareArea(Square square)
    {
        return new BaseMessage<string>()
        { 
            Result = (square.Side * square.Side).ToString()
        };
    }

    public async Task<BaseMessage<string>> SumNumbers(TwiceNumbers data)
    {
        return new BaseMessage<string>()
        {
            Result = (data.Num1 + data.Num2).ToString()
        };
    }
}
