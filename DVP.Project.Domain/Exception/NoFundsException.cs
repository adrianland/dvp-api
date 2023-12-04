namespace DVP.Project.Domain.Exception;

public class NoFundsException : DVPException
{
    // 1 - 10 Excepciones de Cuentas
    public const int NO_FUNDS = 1;
    public const int INVALID_ACCOUNT = 2;

    public NoFundsException(int code, string message) : base(code, message) { }
}