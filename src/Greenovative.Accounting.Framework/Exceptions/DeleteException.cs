namespace Greenovative.Accounting.Framework.Exceptions;

public class DeleteException : Exception
{
    public DeleteException(string message) : base(message)
    {

    }
    public override string Message => base.Message;
}
