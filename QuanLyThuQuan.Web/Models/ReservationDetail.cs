using System;
using System.Collections.Generic;

namespace QuanLyThuQuan.Web.Models;

public partial class ReservationDetail
{
    public uint ReservationDetailId { get; set; }

    public uint? ReservationId { get; set; }

    public uint? DeviceId { get; set; }

    public sbyte? Status { get; set; }

    public virtual Device? Device { get; set; }

    public virtual Reservation? Reservation { get; set; }
}
