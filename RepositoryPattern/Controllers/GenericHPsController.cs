using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Models;
using RepositoryPattern.Models.Req;
using RepositoryPattern.Services;
using System.Runtime.CompilerServices;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericHPsController : ControllerBase
    {
        WebphimonlineContext db = new WebphimonlineContext();
        GenericService<Hangphim> _hp;
        public GenericHPsController(GenericService<Hangphim> hp) { _hp = hp; }

        [HttpPost("addHP")]
        public IActionResult add(Hangphim hp)
        {
            _hp.add(hp);
            return Ok(hp);
        }

        [HttpPut("update")]
        public IActionResult update(Hangphim hp)
        {
            _hp.update(hp);
            return Ok(hp);
        }
        [HttpGet("getbyid")]
        public IActionResult getbyid(int Id)
        {
            return Ok(new { message = "success", data = _hp.getbyid(Id) });

        }

        [HttpGet("proc")]
        public IActionResult procdure(int ngay)
        {
            var lst = db.products.FromSqlRaw("exec GetPhimTongSoTapByNgayTrongTuan {0}", ngay);

            return Ok(new { message = "success", data=lst,status_code =200});
        }
        [HttpGet("view")]
        public IActionResult view() {
            var lst = db.danhsach.ToList();
            return Ok(lst);
        }
        [HttpGet("func")]
        public IActionResult list(int id)
        {
            var lst = db.Set<FunctionSQL>().FromSqlRaw("SELECT * FROM ListPhim({0})", id);
            return Ok(lst);
        }
    }
}
