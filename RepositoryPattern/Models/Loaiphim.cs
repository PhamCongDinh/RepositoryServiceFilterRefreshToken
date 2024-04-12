using System;
using System.Collections.Generic;

namespace RepositoryPattern.Models;

public partial class Loaiphim
{
    public int Id { get; set; }

    public string? TenLp { get; set; }

    public virtual ICollection<Phim> Phims { get; set; } = new List<Phim>();
}
