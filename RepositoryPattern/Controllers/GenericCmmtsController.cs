using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models;
using RepositoryPattern.Services;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericCmmtsController : ControllerBase
    {
        GenericService<Binhluan> _cmmt;
        public GenericCmmtsController(GenericService<Binhluan> cmmt)
        {
            _cmmt = cmmt;
        }
        [HttpPost("addcmmt")]
        public IActionResult addcmmt(Binhluan cmmt)
        {
            cmmt.ThoiGian = DateTime.Now;
            _cmmt.add(cmmt);
            return Ok(new { message = "success", data = cmmt });
        }

        [HttpDelete("deletecmmt")]
        public IActionResult deletecmmt(Binhluan cmmt) 
        {
            _cmmt.delete(cmmt);
            return Ok(new { message = "success",status_code=200 });
        }
        [HttpGet("getcmmtbyid")]
        public IActionResult GetAction(int Id)
        {
            return Ok(new { message = "success", data = _cmmt.getbyid(Id), status_code = 200 });

        }
        [HttpPut("editcmmt")]
        public IActionResult edit(Binhluan cmmt)
        {
            return Ok(new { message = "success", data = _cmmt.update(cmmt) , status_code = 200 });

        }
    }
}
