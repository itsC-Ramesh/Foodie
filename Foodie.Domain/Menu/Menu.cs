using Foodie.Domain.Common.Models;
using Foodie.Domain.Common.ValueObjects;
using Foodie.Domain.Dinner.ValueObjects;
using Foodie.Domain.Host.ValueObjects;
using Foodie.Domain.Menu.Entities;
using Foodie.Domain.Menu.ValueObjects;
using Foodie.Domain.MenuReview.ValueObjects;

namespace Foodie.Domain.Menu;

public sealed class Menu : AggregateRoot<MenuId>
{
    #region private Members 
    private readonly List<MenuSection> _sections = new();
    private readonly List<DinnerId> _dinners = new();
    private readonly List<MenuReviewId> _menuReviews = new();
    #endregion

    #region Properties
    public string Name { get; }
    public string Description { get; }
    public AverageRating AverageRating { get; }
    public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
    public HostId HostId { get; }
    public IReadOnlyList<DinnerId> DinnerIds => _dinners.AsReadOnly();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviews.AsReadOnly();
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    #endregion

    #region Constructor
    private Menu(
        MenuId menuId,
        string name,
        string description,
        AverageRating avgRating,
        HostId hostId,
        DateTime createdDateTime,
        DateTime updatedDateTime
        ) : base(menuId)
    {
        Name = name;
        Description = description;
        AverageRating = avgRating;
        HostId = hostId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }
    #endregion

    #region Static Factory Method
    public static Menu Create(
        string name,
        string description,
        AverageRating avgRating,
        HostId hostId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new(
            MenuId.CreateUnique(),
            name,
            description,
            avgRating,
            hostId,
            createdDateTime,
            updatedDateTime);
    }
    #endregion
}