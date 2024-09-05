namespace Greenovative.Accounting.Framework.Exceptions;

public class DuplicateNameException : BusinessRuleException
{
    public DuplicateNameException(string message) : base(message)
    {

    }
    public override string Message => base.Message;
}
