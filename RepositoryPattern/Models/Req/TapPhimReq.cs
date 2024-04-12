namespace RepositoryPattern.Models.Req
{
    public class TapPhimReq
    {
        public List<TapphimData> tapphimDatas {  get; set; }    
    }

    public class TapphimData
    {
        public int IdPhim { get; set; }
        public int TapSo { get; set; }
        public DateTime ThoiGianChieu { get; set; }
        public DateTime ThoiHan { get; set; }
        public string ThoiLuong { get; set; }
        public string Url_trailer { get; set; }
        public string Url_tapphim { get; set; }
        public int Gia { get; set; }
    }
}
