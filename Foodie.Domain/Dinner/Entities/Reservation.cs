using Foodie.Domain.Bill.ValueObjects;
using Foodie.Domain.Common.Models;
using Foodie.Domain.Dinner.Enums;
using Foodie.Domain.Dinner.ValueObjects;
using Foodie.Domain.Guest.ValueObjects;

namespace Foodie.Domain.Dinner.Entities;
public sealed class Reservation : Entity<ReservationId>
{
    #region Properties

    public int GuestCount { get; }
    public ReservationStatus ReservationStatus { get; }
    public GuestId GuestId { get; }
    public BillId BillId { get; }
    public DateTime? ArrivalDateTime { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    #endregion

    #region Constructor

    private Reservation(
        ReservationId reservationId,
        ReservationStatus reservationStatus,
        GuestId guestId,
        BillId billId,
        DateTime? arrivalDateTime,
        DateTime createdDateTime,
        DateTime updatedDateTime)
        : base(reservationId)
    {
        ReservationStatus = reservationStatus;
        GuestId = guestId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
    }

    #endregion

    #region Factory Static  Method

    public static Reservation Create(ReservationStatus reservationStatus,
        GuestId guestId,
        BillId billId,
        DateTime? arrivalDateTime,
        DateTime createdDateTime,
        DateTime updatedDateTime)
    {
        return new(
            ReservationId.CreateUnique(),
            reservationStatus,
            guestId,
            billId,
            arrivalDateTime,
            createdDateTime,
            updatedDateTime);
    } 
    #endregion
}
