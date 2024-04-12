using System;
using System.Collections.Generic;

namespace RepositoryPattern.Models;

public partial class Chitiethd
{
    public int Id { get; set; }

    public DateTime NgayNhan { get; set; }

    public int? SoTien { get; set; }

    public int? IdTk { get; set; }

    public int? IdHd { get; set; }

    public virtual Hoadon? IdHdNavigation { get; set; }

    public virtual Taikhoan? IdTkNavigation { get; set; }
}
