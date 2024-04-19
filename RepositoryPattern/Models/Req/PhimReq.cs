using System.ComponentModel.DataAnnotations;

namespace RepositoryPattern.Models.Req
{
    public class PhimReq
    {
        public int Id { get; set; }
        public string TenPhim { get; set; }
        [FileExtensions(Extensions = "jpg,jpeg")]
        public IFormFile AnhPhim { get; set; }
        public DateTime NgayPhatHanh { get; set; }
        public string? ThoiLuongPhim { get; set; }
        public string? MoTa { get; set; }
        public int IdLP { get; set; }
        public int IdHP { get; set; }
        public int TongSoTap { get; set; }
    }
}
