namespace RepositoryPattern.Models.Req
{
    public class product
    {
        public int Id { get; set; }
        public string? Ten_Phim { get; set; }
        public string? Anh_Phim { get; set; }
        public DateTime NgayPhatHanh { get; set; }
        public string? ThoiLuongPhim { get; set; }
        public string? MoTa { get; set; }
        public double? DanhGia { get; set; }
        public int? ID_HangPhim { get; set; }
        public int? ID_Lp { get; set; }
        public int TongSoTap { get; set; }
        // Thêm trường solg từ stored procedure
        public int Solg { get; set; }
    }


}
