using Foodie.Domain.Common.Models;

namespace Foodie.Domain.Common.ValueObjects;

public sealed class Rating : ValueObject
{
    public double Value { get; private set; }

    public Rating(double value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
