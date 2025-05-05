using System;
using System.Collections.Generic;

namespace QuanLyThuQuan.Web.Models;

public partial class Member
{
    public uint MemberId { get; set; }

    public string? FullName { get; set; }

    public DateOnly? Birthday { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? Department { get; set; }

    public string? Major { get; set; }

    public string? Class { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }

    public sbyte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

    public virtual ICollection<Violation> Violations { get; set; } = new List<Violation>();
}
