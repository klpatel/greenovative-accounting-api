﻿namespace Greenovative.Accounting.Framework.Exceptions;

public class DuplicatePhoneException : LotoMateValidationException
{
    public DuplicatePhoneException(string message) : base(message)
    {

    }
    public override string Message => base.Message;
}
