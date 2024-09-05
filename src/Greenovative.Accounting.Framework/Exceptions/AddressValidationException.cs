namespace Greenovative.Accounting.Framework.Exceptions;

public class AddressValidationException : LotoMateValidationException
{
    public AddressValidationException(string message) : base(message)
    {

    }
    public override string Message => base.Message;
}
