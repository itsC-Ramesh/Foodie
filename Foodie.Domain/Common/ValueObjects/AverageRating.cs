﻿using Foodie.Domain.Common.Models;

namespace Foodie.Domain.Common.ValueObjects;

public sealed class AverageRating : ValueObject
{
    public double Value { get; private set; }
    public int NumRatings { get; private set; }
    private AverageRating(double value, int numRatings)
    {
        Value = value;
        NumRatings = numRatings;
    }
    public static AverageRating Create(double value, int numRatings)
    {
        return new(value, numRatings);
    }

    public void AddRating(Rating rating)
    {
        Value = ((Value * NumRatings) + rating.Value) / ++NumRatings;
    }

    internal void RemoveRating(Rating rating)
    {
        Value = ((Value * NumRatings) - rating.Value) / --NumRatings;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
