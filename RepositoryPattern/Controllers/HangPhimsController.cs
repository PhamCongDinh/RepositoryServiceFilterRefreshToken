using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models;
using RepositoryPattern.Repository;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangPhimsController : ControllerBase
    {
        WebphimonlineContext db = new WebphimonlineContext();
        IGenericRepository<Hangphim> hpRepos = null;
        public HangPhimsController(IGenericRepository<Hangphim> hpRepo) {
           hpRepos = hpRepo;
        }
        [HttpGet("getHP")]
        public ActionResult gethp()
        {
            var lst = hpRepos.Getdatas();
            return new JsonResult(new { message = "success", data = lst,status=200 });
        }

        

        [HttpGet("GethpbyId")]
        public IActionResult getbyid(int id)
        {
            var lst = hpRepos.GetById(id);
            return new JsonResult(new {message = "success", data = lst, status=200 });
        }

        [HttpPost("addHP")]
        public IActionResult addhp(Hangphim req)
        {
            if (req == null) {
                return new JsonResult(new { message = "error", status = 415 });
            }
            else
            {
                hpRepos.Add(req);
                return new JsonResult(new {messags="success",data=req, status=200});
            }
        }
       

        [HttpPut("updateHP")]
        public IActionResult updatehp(Hangphim req)
        {
            if (req == null) { return BadRequest(); }
            else { hpRepos.Update(req); return new JsonResult(new {message="success", data=req, status=200});}
        }
        [HttpDelete("deleteHP")]
        public IActionResult deletehp(Hangphim req)
        {
            hpRepos.Delete(req);
            return new JsonResult(new { message = "success" });
        }
    }
}
