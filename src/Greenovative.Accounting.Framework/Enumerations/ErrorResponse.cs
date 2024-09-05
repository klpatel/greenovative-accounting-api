namespace Greenovative.Accounting.Framework.Enumerations;

public class ErrorResponse
{
    public int Status;
    public Errors errors { get; set; }
    public ErrorResponse(int statusCode, string responseMessage)
    {
        Status = statusCode;
        errors = new Errors() { Messages = new List<string>() { responseMessage } };
    }
    public ErrorResponse(int statusCode, Errors errors)
    {
        Status = statusCode;
        this.errors = errors;
    }
}
public class Errors
{
    public List<string> Messages { get; set; }
}
