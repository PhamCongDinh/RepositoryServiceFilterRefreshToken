using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using RepositoryPattern.Models;

namespace RepositoryPattern.Filters
{
    public class CommentFilter : IActionFilter
    {
        private readonly ILogger<CommentFilter> _logger;

        public CommentFilter(ILogger<CommentFilter> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null)
            {
                var actionResult = context.Result as ObjectResult;
                if (actionResult != null && actionResult.Value != null)
                {
                    string jsonResponse = JsonConvert.SerializeObject(actionResult.Value);
                    _logger.LogInformation($"Bình luận thành công. Phản hồi: {jsonResponse}");
                }
                else
                {
                    _logger.LogInformation("Không có dữ liệu phản hồi.");
                }
            }
            else
            {
                _logger.LogError(context.Exception, "Lỗi xảy ra trong quá trình thêm bình luận.");
            }
        }

        public  void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.ActionArguments.TryGetValue("req", out var comment) && comment is Binhluan req) {
                _logger.LogInformation($"client having comment {req.IdTapPhim} context {req.NoiDung}" );
            }
        }


    }
}
