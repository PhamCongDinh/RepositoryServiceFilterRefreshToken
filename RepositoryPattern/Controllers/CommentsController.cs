using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Filters;
using RepositoryPattern.Models;
using RepositoryPattern.Services;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        CommentService _cmmtSe;
        public CommentsController(CommentService cmmtSe)
        {
            this._cmmtSe = cmmtSe; 
        }

        [ServiceFilter(typeof(CommentFilter))]
        [HttpPost("newCmmt")]
        public IActionResult newcmmt(Binhluan req)
        {
            var iduser = User.Claims.FirstOrDefault(x => x.Type == "userId");

            req.IdTk = Convert.ToInt32(iduser.Value);
            
            _cmmtSe.newcmmt(req);
           // return new JsonResult(new {data=req });
           return Ok(new { message = "success", data = req });

        }
    }
}
