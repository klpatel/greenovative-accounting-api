namespace Greenovative.Accounting.Framework.Exceptions;

public class RecordFoundException : DatabaseValidationException
{
    public RecordFoundException(string message) : base(message)
    {

    }
    public override string Message => base.Message;
}
