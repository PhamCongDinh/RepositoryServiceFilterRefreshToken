using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern.Models;

public partial class Taikhoan
{
    public int Id { get; set; }

    public string? TenTk { get; set; }

    public string? MatKhau { get; set; }
    //[EmailAddress]
    public string? Email { get; set; }
    [RegularExpression("^[0-9]*$", ErrorMessage = "Chi duoc nhap số")]
    public int LoaiTk { get; set; }
    public string? RefreshToken {  get; set; }
    public virtual ICollection<Binhluan> Binhluans { get; set; } = new List<Binhluan>();

    public virtual ICollection<Chitiethd> Chitiethds { get; set; } = new List<Chitiethd>();

    public virtual ICollection<Danhgia> Danhgia { get; set; } = new List<Danhgia>();

    public virtual ICollection<Lichsuphim> Lichsuphims { get; set; } = new List<Lichsuphim>();
}
