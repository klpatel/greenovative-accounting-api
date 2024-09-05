namespace Greenovative.Accounting.Framework.Exceptions;

public class DuplicateAddressException : BusinessRuleException
{
    public DuplicateAddressException(string message) : base(message)
    {

    }
    public override string Message => base.Message;
}
