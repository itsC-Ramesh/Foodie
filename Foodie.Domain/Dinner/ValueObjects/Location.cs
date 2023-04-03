using Foodie.Domain.Common.Models;

namespace Foodie.Domain.Dinner.ValueObjects;

public sealed class Location : ValueObject
{
    public string Name { get; }
    public string Address { get; }
    public string Lattitude { get; }
    public string Longitude { get; }

    private Location(string name, string address, string lattitude, string longitude)
    {
        Name = name;
        Address = address;
        Lattitude = lattitude;
        Longitude = longitude;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Name;
        yield return Address;
        yield return Lattitude;
        yield return Longitude;

    }
}
