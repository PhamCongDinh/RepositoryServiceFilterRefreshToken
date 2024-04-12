using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models;
using RepositoryPattern.Services;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        ReviewService _review;
        public ReviewsController(ReviewService review)
        {
            this._review = review;
        }
        [HttpPost("newreview")]
        public IActionResult newreview(Danhgia req)
        {
            var iduser = User.Claims.FirstOrDefault(x => x.Type == "userId");

            req.IdTk = Convert.ToInt32(iduser.Value);
            _review.newreview(req);
            return new JsonResult(new { data = req });
        }
    }
}
