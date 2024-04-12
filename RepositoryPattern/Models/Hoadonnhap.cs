using System;
using System.Collections.Generic;

namespace RepositoryPattern.Models;

public partial class Hoadonnhap
{
    public int Id { get; set; }

    public DateTime NgayNhap { get; set; }

    public virtual ICollection<Chitiethdn> Chitiethdns { get; set; } = new List<Chitiethdn>();
}
