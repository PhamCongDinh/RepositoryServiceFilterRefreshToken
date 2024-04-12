using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore.Metadata;
using RepositoryPattern.Controllers;
using RepositoryPattern.Models;

namespace RepositoryPattern.Filters
{
    public class AuthenFilter : IActionFilter
    {
        private readonly ILogger<AuthenFilter> _logger;

        public AuthenFilter(ILogger<AuthenFilter> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("logger");
            _logger.LogInformation(context.ActionDescriptor.Parameters.ToString());
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation(context.ActionDescriptor.DisplayName);
            
        }
    }
}
