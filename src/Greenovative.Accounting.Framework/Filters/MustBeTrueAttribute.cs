using System.ComponentModel.DataAnnotations;

namespace Greenovative.Accounting.Framework.Filters;

public sealed class MustBeTrueAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        return Equals(value, true);
    }
}
