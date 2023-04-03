using Foodie.Domain.Common.Models;
using Foodie.Domain.Common.ValueObjects;
using Foodie.Domain.Dinner.ValueObjects;
using Foodie.Domain.Guest.ValueObjects;
using Foodie.Domain.Host.ValueObjects;
using Foodie.Domain.Menu.ValueObjects;
using Foodie.Domain.MenuReview.ValueObjects;

namespace Foodie.Domain.MenuReview;

public sealed class MenuReview : Entity<MenuReviewId>
{
    #region Properties
    public int Rating { get; }
    public string Comment { get; }
    public HostId HostId { get; }
    public MenuId MenuId { get; }
    public GuestId GuestId { get; }
    public DinnerId DinnerId { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; } 
    #endregion

    #region Constructor
    private MenuReview(
        MenuReviewId menuReviewId,
        int rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(menuReviewId)
    {
        Rating = rating;
        Comment = comment;
        HostId = hostId;
        MenuId = menuId;
        GuestId = guestId;
        DinnerId = dinnerId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    } 
    #endregion

    #region Static Factory Methood
    public static MenuReview Create(
        int rating,
        string comment,
        HostId hostId,
        MenuId menuId,
        GuestId guestId,
        DinnerId dinnerId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new(
            MenuReviewId.CreateUnique(),
            rating,
            comment,
            hostId,
            menuId,
            guestId,
            dinnerId,
            createdDateTime,
            updatedDateTime
            );
    } 
    #endregion
}
