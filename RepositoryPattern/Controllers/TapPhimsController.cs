using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models;
using RepositoryPattern.Models.Req;
using RepositoryPattern.Repository;
using RepositoryPattern.Services;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TapPhimsController : ControllerBase
    {
        WebphimonlineContext db = new WebphimonlineContext();


        TapPhimService chk;
        IGenericRepository<Tapphim> tpRepos = null;
        public TapPhimsController(IGenericRepository<Tapphim> tpRepo)
        {
            tpRepos = tpRepo;
        }

        [HttpGet("tapphimbyId")]
        public IActionResult get(int id)
        {
            var lst = tpRepos.GetById(id);
            return new JsonResult(lst);
        }


        
        [HttpPost("newtapphim")]
        public async Task<IActionResult> newtapphim([FromBody] TapPhimReq req)
        {
            var hd = new Hoadonnhap
            {
                NgayNhap = DateTime.Now,
            };
            db.Hoadonnhaps.Add(hd);
            db.SaveChanges();
            var idHD = hd.Id;

            foreach (var phimdata in req.tapphimDatas)
            {
                var idPhim = phimdata.IdPhim;
                var tapso = phimdata.TapSo;
                var thoigianchieu = phimdata.ThoiGianChieu;
                var thoihan = phimdata.ThoiHan;
                var thoiluong = phimdata.ThoiLuong;
                var url_trailer = phimdata.Url_trailer;
                var url_tapphim = phimdata.Url_tapphim;
                var giaphim = phimdata.Gia;
                //var check = db.Tapphims.FirstOrDefault(x => x.IdPhim == idPhim && x.TapSo == tapso);
                var check = chk.DoubleCheck(idPhim, tapso);
                if (check != null) { return BadRequest(new { message = "Phim này đã có tập này rồi", data = check }); }
                var tapphim = new Tapphim
                {
                    TapSo = tapso,
                    ThoiGianChieu = thoigianchieu,
                    ThoiHan = thoihan,
                    ThoiLuong = thoiluong,
                    UrlPhim = url_tapphim,
                    UrlTrailer = url_trailer,
                    IdPhim = idPhim,
                };
                tpRepos.Add(tapphim);       
                
                var chitiethd = new Chitiethdn
                {
                    GiaPhim = giaphim,
                    IdPnk = idHD,
                    IdTapPhim = tapphim.Id
                };
                db.Chitiethdns.Add(chitiethd);
                db.SaveChanges();
            }
            return Ok(new { success = true, req });
        }

    }
}
