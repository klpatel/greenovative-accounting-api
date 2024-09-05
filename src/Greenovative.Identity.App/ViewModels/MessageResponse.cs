namespace Greenovative.Identity.App.ViewModels;

public class MessageResponse
{
    public int Status;
    public Errors errors { get; set; }
    public MessageResponse(int statusCode, string responseMessage)
    {
        Status = statusCode;
        errors = new Errors() { Messages = new List<string>() { responseMessage } };
    }
    public MessageResponse(int statusCode, Errors errors)
    {
        Status = statusCode;
        this.errors = errors;
    }
}
public class Errors
{
    public List<string> Messages { get; set; }
}
