using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Foodie.Api.Filters;

public class ExceptionHandlingFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var ex = context.Exception;
        var errorResult = new { error = ex.Message };
        context.Result = new ObjectResult(errorResult)
        {
            StatusCode = 500,
        };
        context.ExceptionHandled = true;
    }
}
