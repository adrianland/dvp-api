namespace DVP.Project.Domain.Exception;

[Serializable]
public sealed class BadRequestException : ClientErrorException
{
    public BadRequestException() : base() { }
    public BadRequestException(string message) : base(message) { }
}