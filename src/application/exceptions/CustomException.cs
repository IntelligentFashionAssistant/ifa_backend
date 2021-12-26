namespace application.exceptions;

public class CustomException : Exception
{
    public List<string> ErrorMessages { get;}
    public CustomException(string message, List<string> errorMessages) :base(message) => ErrorMessages = errorMessages;
}