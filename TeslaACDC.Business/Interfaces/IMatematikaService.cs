using TeslaACDC.Data.DTO;
using TeslaACDC.Data.Models;

namespace TeslaACDC.Business.Interfaces;

public interface IMatematikaService
{
    Task<BaseMessage<string>> SumNumbers(TwiceNumbers data);

    Task<BaseMessage<string>> MultiplyNumbers(TwiceNumbers data);

    Task<BaseMessage<string>> DivideNumbers(TwiceNumbers data);

    Task<BaseMessage<string>> SquareArea(Square square);

}
