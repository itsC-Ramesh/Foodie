using Foodie.Domain.Common.Models;
using Foodie.Domain.User.ValueObjects;

namespace Foodie.Domain.User;

public sealed class User : Entity<UserId>
{
    #region Properties
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string Password { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    #endregion

    #region Constructor
    private User(
    UserId userId,
    string firstName,
    string lastName,
    string email,
    string password,
    DateTime createdDateTime,
    DateTime updatedDateTime)
    : base(userId)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    #endregion

    #region Static Factory Method
    public static User Create(
        string firstName,
        string lastName,
        string email,
        string password,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new(UserId.CreateUnique(),
            firstName,
            lastName,
            email,
            password,
            createdDateTime,
            updatedDateTime);
    }
    #endregion

}
