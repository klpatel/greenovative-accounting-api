namespace Greenovative.Accounting.Framework.Exceptions;

public class InvalidParameterException : BusinessRuleException
{
    public InvalidParameterException(string message) : base(message)
    {

    }
    public override string Message => base.Message;
}
