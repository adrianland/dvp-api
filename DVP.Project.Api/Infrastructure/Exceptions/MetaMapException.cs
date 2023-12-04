using DVP.Project.Domain.Exception;

namespace DVP.Project.Api.Infrastructure.Exceptions;

public class MetaMapException : DVPException
{
    public MetaMapException(string message) : base(message) { }
}
