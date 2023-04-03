using Foodie.Domain.Bill.ValueObjects;
using Foodie.Domain.Common.Models;
using Foodie.Domain.Dinner.ValueObjects;
using Foodie.Domain.Guest.ValueObjects;
using Foodie.Domain.Host.ValueObjects;

namespace Foodie.Domain.Bill;

public sealed class Bill : Entity<BillId>
{
    #region Properties
    public DinnerId DinnerId { get; }
    public GuestId GuestId { get; }
    public HostId HostId { get; }
    public Price Price { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }
    #endregion

    #region Constructor
    private Bill(BillId billId, DinnerId dinnerId, GuestId guestId, HostId hostId, Price price, DateTime createdDateTime, DateTime updatedDateTme) : base(billId)
    {
        DinnerId = dinnerId;
        GuestId = guestId;
        HostId = hostId;
        Price = price;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTme;
    }
    #endregion

    #region Static Factory Method
    public static Bill Create(GuestId guestId, DinnerId dinnerId, HostId hostId, Price price, DateTime createdDateTime, DateTime updatedDateTme)
    {
        return new(BillId.CreateUnique(), dinnerId, guestId, hostId, price, createdDateTime, updatedDateTme);
    }
    #endregion
}
