namespace Greenovative.Accounting.Framework.Exceptions;

public class RecordNotFoundException : DatabaseValidationException
{
    public RecordNotFoundException(string message) : base(message)
    {

    }
    public override string Message => base.Message;
}
