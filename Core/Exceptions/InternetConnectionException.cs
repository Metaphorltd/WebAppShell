namespace WebAppShell.Core.Exceptions;

public class InternetConnectionException : Exception
{
    public InternetConnectionException()
    {
    }

    public InternetConnectionException(string message) : base(message)
    {
    }

    public InternetConnectionException(string message, Exception inner) : base(message, inner)
    {
    }
}