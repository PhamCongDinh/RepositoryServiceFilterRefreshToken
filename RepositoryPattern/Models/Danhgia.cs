using System;
using System.Collections.Generic;

namespace RepositoryPattern.Models;

public partial class Danhgia
{
    public int Id { get; set; }

    public double? SoDiem { get; set; }

    public DateTime? ThoiGian { get; set; }

    public int IdTapPhim { get; set; }

    public int IdTk { get; set; }

    public virtual Tapphim? IdTapPhimNavigation { get; set; }

    public virtual Taikhoan? IdTkNavigation { get; set; }
}
