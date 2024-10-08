﻿namespace Greenovative.Accounting.Framework.Exceptions;

public class DomainValidationException : Exception
{
    public IEnumerable<string> Errors { get; private set; }

    public DomainValidationException(IEnumerable<string> errors, Exception innerException)
        : base("Domain Validation Exception", innerException)
    {
        Errors = new List<string>(errors);
    }
}
