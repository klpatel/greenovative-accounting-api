namespace Greenovative.Accounting.Framework.Exceptions;

public class BusinessRuleException : Exception
{
    public BusinessRuleException(string message) : base(message)
    {

    }
}

public class NotificationException : Exception
{
    public NotificationException(string message) : base(message)
    {

    }
}

public class ApplicationSecurityException : Exception
{
    public ApplicationSecurityException(string message) : base(message)
    {

    }
}

public class LotoMateValidationException : Exception
{
    public LotoMateValidationException(string message) : base(message)
    {

    }
}

public class DatabaseValidationException : Exception
{
    public DatabaseValidationException(string message) : base(message)
    {

    }
}
