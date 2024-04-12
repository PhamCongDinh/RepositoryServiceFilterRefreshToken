using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RepositoryPattern.Models;
using System.Text;

namespace RepositoryPattern.Filters
{
    public class testFilter : IActionFilter
    {
        private readonly ILogger<testFilter> _logger;

        public testFilter(ILogger<testFilter> logger)
        {
            _logger = logger;
        }
        public async void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.TryGetValue("req", out var value) && value is Taikhoan req)
            {
                _logger.LogInformation($"client login(email: {req.Email} | password: {req.MatKhau})");
            }
        }

        public async void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null)
            {
                var actionResult = context.Result as ObjectResult;
                if (actionResult != null)
                {
                    //chuyển đổi ra json
                    string jsonResponse = JsonConvert.SerializeObject(actionResult.Value);

                    if (actionResult.StatusCode == StatusCodes.Status200OK)
                    {

                        _logger.LogInformation($"Đăng nhập thành công. Response: {jsonResponse}");
                    }
                    else
                    {
                        _logger.LogInformation($"Đăng nhập thất bại. {jsonResponse}");
                    }
                }
                
            }
            else
            {
                _logger.LogError(context.Exception, "Lỗi xảy ra trong quá trình đăng nhập.");
            }
        }



    }
}
