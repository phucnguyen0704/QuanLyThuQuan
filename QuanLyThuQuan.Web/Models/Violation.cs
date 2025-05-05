using System;
using System.Collections.Generic;

namespace QuanLyThuQuan.Web.Models;

public partial class Violation
{
    public uint ViolationId { get; set; }

    public uint? MemberId { get; set; }

    public uint? RegulationId { get; set; }

    public uint? ReservationId { get; set; }

    public string? Penalty { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? DueTime { get; set; }

    public sbyte? Status { get; set; }

    public virtual Member? Member { get; set; }

    public virtual Regulation? Regulation { get; set; }

    public virtual Reservation? Reservation { get; set; }
}
