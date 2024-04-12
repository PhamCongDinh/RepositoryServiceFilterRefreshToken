using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models;
using RepositoryPattern.Repository;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiPhimsController : ControllerBase
    {
        IGenericRepository<Loaiphim> lpRepo = null;
        WebphimonlineContext db = new WebphimonlineContext();  
        public LoaiPhimsController(IGenericRepository<Loaiphim> lp) {
            lpRepo= lp;
        }
        [HttpGet("getlp")]
        public IActionResult Get()
        {
            var lst = lpRepo.Getdatas();
            return new JsonResult(new {messages ="success",data=lst,status=200});
        }

        [HttpPost("addlp")]
        public IActionResult addlp(Loaiphim req)
        {
            lpRepo.Add(req);
            return new JsonResult(new {messages ="success",data=req,status=200});

        }
        [HttpPut("updatelp")]
        public IActionResult updatelp(Loaiphim req)
        {
            lpRepo.Update(req);
            return new JsonResult(new { messages ="success",data=req, status=200});
        }
    }
}
