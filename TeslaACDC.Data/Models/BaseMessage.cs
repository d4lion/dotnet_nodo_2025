using System.Net;

namespace TeslaACDC.Data.Models;

public class BaseMessage<T>
where T : class
{
    public string Message { get; set; } = "Success";
    public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    public required T Result { get; set; }
}
