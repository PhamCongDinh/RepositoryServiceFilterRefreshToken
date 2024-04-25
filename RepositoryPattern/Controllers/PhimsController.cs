using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models;
using RepositoryPattern.Models.Req;
using RepositoryPattern.Repository;
using RepositoryPattern.Services;
using System.Net.Http.Headers;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PhimsController : ControllerBase
    {
        

        IPhimRepository phimRepos = null;

        PhimService pser;
        public PhimsController(IPhimRepository phimRepo)
        {
            phimRepos = phimRepo;
        }
        [HttpGet("getallphim")]
        public ActionResult getallphim()
        {          
                var lst = phimRepos.GetPhims();
                return Ok(new { message = "success", data = lst });         
        }




       
        
        [HttpPost("newphim")]
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

            pser.Create(phim);

            return Ok(new { message = "success", data = phim, status = 200 });
        }




        [HttpPut("updatephim")]
        public IActionResult updateFilm(Phim phim)
        {
            phimRepos.Update(phim);
            return Ok(new {message = "success", data = phim});
        }

        [HttpDelete("deletephim")]
        public IActionResult deleteFilm(Phim phim)
        {
            phimRepos.Delete(phim);
            return Ok(new {message="success", data = phim});
        }
    }
}
