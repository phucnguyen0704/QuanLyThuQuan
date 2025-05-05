using System;
using System.Collections.Generic;

namespace QuanLyThuQuan.Web.Models;

public partial class Device
{
    public uint DeviceId { get; set; }

    public string? Name { get; set; }

    public string? Image { get; set; }

    public sbyte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<ReservationDetail> ReservationDetails { get; set; } = new List<ReservationDetail>();
}
