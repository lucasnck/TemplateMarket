using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

public class ResultResponseFilter : IAsyncResultFilter
{
    public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (context.Result is ObjectResult objectResult &&
            objectResult.Value is not Result<object> &&
            objectResult.StatusCode >= 200 && objectResult.StatusCode < 300)
        {
            var wrapped = new Result<object>
            {
                Success = true,
                Data = objectResult.Value
            };

            context.Result = new ObjectResult(wrapped)
            {
                StatusCode = objectResult.StatusCode
            };
        }

        await next();
    }
}
