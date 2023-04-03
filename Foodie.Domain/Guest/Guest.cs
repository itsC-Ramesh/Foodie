using Foodie.Domain.Bill.ValueObjects;
using Foodie.Domain.Common.Models;
using Foodie.Domain.Common.ValueObjects;
using Foodie.Domain.Guest.Entities;
using Foodie.Domain.Guest.ValueObjects;
using Foodie.Domain.MenuReview.ValueObjects;
using Foodie.Domain.User.ValueObjects;

namespace Foodie.Domain.Guest;

public sealed class Guest : Entity<GuestId>
{
    #region Private Members

    //Private Members - Lists
    private readonly List<BillId> _billIds = new();
    private readonly List<MenuReviewId> _menuReviewId = new();
    private readonly List<GuestRating> _guestRatings = new();

    #endregion

    #region Properties
    public string FirstName { get; }
    public string LastName { get; }
    public string ProfileImage { get; }
    public AverageRating AverageRating { get; }
    public UserId UserId { get; }

    //ToDO : 
    //upcomingDinnerIds
    //pastDinnerIds
    //pendingDinnerIds

    public IReadOnlyList<BillId> BillIds => _billIds.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewId.AsReadOnly();
    public IReadOnlyList<GuestRating> Ratings => _guestRatings.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    #endregion

    #region Constructor

    private Guest(
        GuestId guestId,
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(guestId)
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

    public static Guest Create(
        string firstName,
        string lastName,
        string profileImage,
        AverageRating averageRating,
        UserId userId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new(
            GuestId.CreateUnique(),
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
