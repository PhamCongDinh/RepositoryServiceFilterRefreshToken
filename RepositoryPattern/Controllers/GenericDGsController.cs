using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models;
using RepositoryPattern.Services;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericDGsController : ControllerBase
    {
        GenericService<Danhgia> _dg;
        public GenericDGsController(GenericService<Danhgia> dg)
        {
            _dg = dg;
        }
        [HttpPost("addDG")]
        public IActionResult addDG(Danhgia dg)
        {
            dg.ThoiGian = DateTime.Now;
            _dg.add(dg);
            return Ok(new {message = "Success", data=dg});
        }
        [HttpDelete("deletedg")]
        public IActionResult deletedg(Danhgia dg)
        {
            _dg.delete(dg);
            return Ok(new {message ="success"});
        }
        [HttpPut("editdg")]
        public IActionResult edit(Danhgia dg)
        {
            return Ok(new { message = "success", data = _dg.update(dg) });

        }
        [HttpGet("getdgbyid")]
        public IActionResult GetAction(int Id)
        {
            return Ok(new { message = "success", data = _dg.getbyid(Id) });

        }
    }
}
