namespace RepositoryPattern.Models.Req
{
    public class DanhSach
    {
        public int Id { get; set; }
        public DateTime ThoiHan {  get; set; }  
        public int TapSo {  get; set; }
        public DateTime ThoiGianChieu { get; set; }
        public string ThoiLuong { get; set; }
        public string URL_trailer { get; set; }
        public string URL_Phim {  get; set; }
        public int Id_phim {  get; set; }
    }
}
