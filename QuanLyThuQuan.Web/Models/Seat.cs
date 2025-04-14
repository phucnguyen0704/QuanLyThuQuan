using System;
using System.Collections.Generic;

namespace QuanLyThuQuan.Web.Models;

public partial class Seat
{
    public uint SeatId { get; set; }

    public string? Name { get; set; }

    public sbyte? Status { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
