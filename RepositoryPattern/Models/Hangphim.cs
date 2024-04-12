using System;
using System.Collections.Generic;

namespace RepositoryPattern.Models;

public partial class Hangphim
{
    public int Id { get; set; }

    public string? TenHangPhim { get; set; }

    public virtual ICollection<Phim> Phims { get; set; } = new List<Phim>();
}
