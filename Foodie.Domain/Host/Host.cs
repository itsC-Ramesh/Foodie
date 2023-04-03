using Foodie.Domain.Bill.ValueObjects;
using Foodie.Domain.Common.Models;
using Foodie.Domain.Common.ValueObjects;
using Foodie.Domain.Dinner.ValueObjects;
using Foodie.Domain.Host.ValueObjects;
using Foodie.Domain.Menu.ValueObjects;
using Foodie.Domain.MenuReview.ValueObjects;
using Foodie.Domain.User.ValueObjects;

namespace Foodie.Domain.Host;

public sealed class Host : Entity<HostId>
{
    #region Private Members
    private readonly List<MenuId> _menuIds = new();
    private readonly List<DinnerId> _dinnerIds = new();
    #endregion

    #region Properties

    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public AverageRating AverageRating { get; }
    public UserId UserId { get; }
    public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
    public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    #endregion

    #region Constructor
    private Host(
        HostId hostId,
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(hostId)
    {
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    #endregion

    #region Methods
    public static Host Create(
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new(
            HostId.CreateUnique(),
            firstName,
            lastName,
            profileImage,
            averageRating,
            userId,
            createdDateTime,
            updatedDateTime);
    }
    #endregion
}
