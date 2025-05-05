using System;
using System.Collections.Generic;

namespace QuanLyThuQuan.Web.Models;

public partial class Regulation
{
    public uint RegulationId { get; set; }

    public string? Name { get; set; }

    public string? Type { get; set; }

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Violation> Violations { get; set; } = new List<Violation>();
}
