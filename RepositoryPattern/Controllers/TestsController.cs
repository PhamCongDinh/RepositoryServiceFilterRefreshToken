using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models.Req;
using RepositoryPattern.Models;
using RepositoryPattern.Services;
using RepositoryPattern.Repository;
namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        PhimService _pser;
        IPhimRepository _pserRepository;
        WebphimonlineContext db = new WebphimonlineContext(); 
        public TestsController(PhimService pser, IPhimRepository repository)
        {
            _pserRepository = repository;
            _pser = pser;
        }
        [HttpPost("add")]
        public async Task<IActionResult> newphim([FromForm] PhimReq req)
        {
            var phim = new Phim
            {
                TenPhim = req.TenPhim,
                IdHangPhim = req.IdHP,
                IdLp = req.IdLP,
                MoTa = req.MoTa,
                TongSoTap = req.TongSoTap,
                NgayPhatHanh = req.NgayPhatHanh,

            };
            if (req.AnhPhim != null)
            {
                var imageName = req.AnhPhim.FileName;
                var imagePath = Path.Combine("C:\\fpt\\QLwebphim\\Primeng\\src\\assets\\images", imageName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await req.AnhPhim.CopyToAsync(stream);
                }
                phim.AnhPhim = imageName;
            }
            var result = _pser.Create(phim);

            if (result == PhimService.status.created)
            {
                return Ok(new { message = "Phim created successfully", data = phim });
            }
            else
            {
                return Conflict(new { message = "Phim already exists" });
            }

        }

        
        [HttpPut("update")]
        public async Task<IActionResult> update([FromForm] PhimReq req)
        {
            var phim = new Phim
            {
                Id = req.Id,
                TenPhim = req.TenPhim,
                IdHangPhim = req.IdHP,
                IdLp = req.IdLP,
                MoTa = req.MoTa,
                TongSoTap = req.TongSoTap,
                NgayPhatHanh = req.NgayPhatHanh,
            };

            var check = db.Phims.FirstOrDefault(x => x.Id == req.Id);
            if (req.AnhPhim != null && (check == null || check.AnhPhim != req.AnhPhim.FileName))
            {
                // Xóa ảnh cũ nếu có
                if (check != null && !string.IsNullOrEmpty(check.AnhPhim))
                {
                    var oldImagePath = Path.Combine("C:\\fpt\\QLwebphim\\Primeng\\src\\assets\\images", check.AnhPhim);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                // Thêm ảnh mới
                var imageName = req.AnhPhim.FileName;
                var imagePath = Path.Combine("C:\\fpt\\QLwebphim\\Primeng\\src\\assets\\images", imageName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await req.AnhPhim.CopyToAsync(stream);
                }
                phim.AnhPhim = imageName;
            }
            else if (check != null)
            {
                // Nếu ảnh không thay đổi, giữ nguyên ảnh cũ
                phim.AnhPhim = check.AnhPhim;
            }

            _pserRepository.Update(phim);
            return Ok(phim);
        }
    }
}
