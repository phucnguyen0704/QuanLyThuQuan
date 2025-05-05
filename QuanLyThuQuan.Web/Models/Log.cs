using System;
using System.Collections.Generic;

namespace QuanLyThuQuan.Web.Models;

public partial class Log
{
    public uint LogId { get; set; }

    public string? MemberId { get; set; }

    public DateTime? CheckinTime { get; set; }

    public sbyte? Status { get; set; }

    public DateTime? CreatedAt { get; set; }
}
