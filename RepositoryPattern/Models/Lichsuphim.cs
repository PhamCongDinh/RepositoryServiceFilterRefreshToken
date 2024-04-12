using System;
using System.Collections.Generic;

namespace RepositoryPattern.Models;

public partial class Lichsuphim
{
    public int Id { get; set; }

    public int? IdTapphim { get; set; }

    public int? IdTk { get; set; }

    public DateTime? CreateAt { get; set; }

    public virtual Tapphim? IdTapphimNavigation { get; set; }

    public virtual Taikhoan? IdTkNavigation { get; set; }
}
