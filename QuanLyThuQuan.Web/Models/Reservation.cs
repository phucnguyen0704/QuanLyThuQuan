using System;
using System.Collections.Generic;

namespace QuanLyThuQuan.Web.Models;

public partial class Reservation
{
    public uint ReservationId { get; set; }

    public uint? MemberId { get; set; }

    public uint? SeatId { get; set; }

    public sbyte? ReservationType { get; set; }

    public DateTime? ReservationTime { get; set; }

    public DateTime? DueTime { get; set; }

    public DateTime? ReturnTime { get; set; }

    public sbyte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Member? Member { get; set; }

    public virtual ICollection<ReservationDetail> ReservationDetails { get; set; } = new List<ReservationDetail>();

    public virtual Seat? Seat { get; set; }

    public virtual ICollection<Violation> Violations { get; set; } = new List<Violation>();
}
