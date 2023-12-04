using DVP.Project.Domain.Exception;

namespace DVP.Project.Api.Infrastructure.Exceptions;

public class InvalidRequestException : System.Exception
{
    /// <summary>
    ///     Exception for request not valid
    /// </summary>
    /// <param name="message"> Message to show in response</param>
    /// <param name="details"> Message to show in response</param>
    /// <param name="translationCode"> Message to show in response </param>
    public InvalidRequestException(string message) : base(message)
    {
    }

    /// <summary>
    ///     Exception for request not valid
    /// </summary>
    /// <param name="message"> Message to show in response</param>
    /// <param name="details"> Message to show in response</param>
    /// <param name="translationCode"></param>
    public InvalidRequestException(string message, List<ErrorDetail> details) : base(message)
    {
        Details = details;
    }

    public List<ErrorDetail> Details { get; }
}