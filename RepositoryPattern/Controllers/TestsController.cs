using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models.Req;
using RepositoryPattern.Models;
using RepositoryPattern.Services;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        PhimService _pser;
        public TestsController(PhimService pser)
        {
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

    }
}
