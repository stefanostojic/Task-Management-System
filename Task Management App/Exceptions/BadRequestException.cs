using Task_Management_System.Exceptions;

public class BadRequestException : CustomException
{
    /// <summary>
    /// Status code: 400 
    /// Error message: "Bad request"
    /// </summary>
    public BadRequestException()
        : base()
    {
        StatusCode = 400;
        ErrorMessage = "Bad request.";
    }

    public BadRequestException(string message)
        : this()
    {
        ErrorMessage = message;
    }
}