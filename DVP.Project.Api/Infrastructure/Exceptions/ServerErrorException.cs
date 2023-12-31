namespace DVP.Project.Api.Infrastructure.Exceptions;

public class ServerErrorException : System.Exception
{
    /// <summary>
    ///     Exception for 5XX Errors
    /// </summary>
    /// <param name="statusCode"></param>
    /// <param name="code"></param>
    /// <param name="message"></param>
    /// <param name="details"></param>
    public ServerErrorException(string code, string message, string details = null) : base(message)
    {
        StatusCode = StatusCodes.Status500InternalServerError;
        Code = code;
        //Source = source;
        Details = details;
    }

    public int StatusCode { get; }
    public string Code { get; }
    public string Details { get; }
}