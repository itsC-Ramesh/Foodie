using Foodie.Domain.Common.Enums;
using Foodie.Domain.Common.Models;

namespace Foodie.Domain.Dinner.ValueObjects;

public sealed class Price : ValueObject
{
    #region Properties

    public double Amount { get; }
    public Currency Currency { get; }

    #endregion

    #region Constructor

    //Temporarily made ctor public
    public Price(double amount, Currency currency)
    {
        Amount = amount;
        Currency = currency;
    }
    #endregion

    #region Methods
    // 
    #endregion

    #region GetEqualityComponents

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Currency;
    }
    #endregion
}
