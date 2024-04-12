using System;
using System.Collections.Generic;

namespace RepositoryPattern.Models;

public partial class Phim
{
    public int Id { get; set; }

    public string? TenPhim { get; set; }

    public string? AnhPhim { get; set; }

    public DateTime NgayPhatHanh { get; set; }

    public string? ThoiLuongPhim { get; set; }

    public string? MoTa { get; set; }

    public double? DanhGia { get; set; }

    public int? IdHangPhim { get; set; }

    public int? IdLp { get; set; }

    public int TongSoTap { get; set; }

    public virtual Hangphim? IdHangPhimNavigation { get; set; }

    public virtual Loaiphim? IdLpNavigation { get; set; }

    public virtual ICollection<Tapphim> Tapphims { get; set; } = new List<Tapphim>();
}
