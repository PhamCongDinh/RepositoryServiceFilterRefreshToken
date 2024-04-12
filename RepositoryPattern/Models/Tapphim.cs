using System;
using System.Collections.Generic;

namespace RepositoryPattern.Models;

public partial class Tapphim
{
    public int Id { get; set; }

    public DateTime ThoiHan { get; set; }

    public int TapSo { get; set; }

    public DateTime ThoiGianChieu { get; set; }

    public string? ThoiLuong { get; set; }

    public string? UrlPhim { get; set; }

    public string? UrlTrailer { get; set; }

    public int? IdPhim { get; set; }

    public virtual ICollection<Binhluan> Binhluans { get; set; } = new List<Binhluan>();

    public virtual ICollection<Chitiethdn> Chitiethdns { get; set; } = new List<Chitiethdn>();

    public virtual ICollection<Danhgia> Danhgia { get; set; } = new List<Danhgia>();

    public virtual Phim? IdPhimNavigation { get; set; }

    public virtual ICollection<Lichsuphim> Lichsuphims { get; set; } = new List<Lichsuphim>();
}
