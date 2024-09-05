namespace Greenovative.Accounting.Framework.Exceptions;

public class DuplicateUserNameException : BusinessRuleException
{
    public DuplicateUserNameException(string message = null) : base(message)
    {

    }

    public override string Message => base.Message;
}
