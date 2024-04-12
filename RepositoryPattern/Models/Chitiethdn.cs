using System;
using System.Collections.Generic;

namespace RepositoryPattern.Models;

public partial class Chitiethdn
{
    public int Id { get; set; }

    public int? GiaPhim { get; set; }

    public int? IdPnk { get; set; }

    public int? IdTapPhim { get; set; }

    public virtual Hoadonnhap? IdPnkNavigation { get; set; }

    public virtual Tapphim? IdTapPhimNavigation { get; set; }
}
