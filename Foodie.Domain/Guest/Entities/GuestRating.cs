using Foodie.Domain.Common.Models;
using Foodie.Domain.Dinner.ValueObjects;
using Foodie.Domain.Guest.ValueObjects;
using Foodie.Domain.Host.ValueObjects;

namespace Foodie.Domain.Guest.Entities;

public sealed class GuestRating : Entity<GuestRatingId>
{
    #region Properties
    public HostId HostId { get; }
    public DinnerId DinnerId { get; }
    public int Rating { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    #endregion

    #region Constructor

    private GuestRating(
        GuestRatingId guestRatingId,
        HostId hostId,
        DinnerId dinnerId,
        int rating,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(guestRatingId)
    {
        HostId = hostId;
        DinnerId = dinnerId;
        Rating = rating;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    #endregion

    #region Methods

    public static GuestRating Create(
        HostId hostId,
        DinnerId dinnerId,
        int rating,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new(
            GuestRatingId.CreateUnique(),
            hostId,
            dinnerId,
            rating,
            createdDateTime,
            updatedDateTime);
    }

    #endregion
}
