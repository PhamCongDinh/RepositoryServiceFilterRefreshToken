using System;
using System.Collections.Generic;

namespace RepositoryPattern.Models;

public partial class Hoadon
{
    public int Id { get; set; }

    public DateTime NgayTao { get; set; }

    public virtual ICollection<Chitiethd> Chitiethds { get; set; } = new List<Chitiethd>();
}
