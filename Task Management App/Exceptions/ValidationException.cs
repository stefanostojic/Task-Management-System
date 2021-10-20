using Task_Management_System.Exceptions;

public class ValidationException : BadRequestException
{
    public ValidationException(string modelName) 
        : base()
    {
        StatusCode = 400;
        ErrorMessage = $"Validation error for {modelName}";
    }

    public ValidationException(string modelName, string errors)
        : this(modelName)
    {
        ErrorMessage = $"Validation error for {modelName}. \n{errors}";
    }
}