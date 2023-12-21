using Microsoft.AspNetCore.Mvc;
using TNetTask.Exceptions;

namespace TNetTask.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next,
    ILogger<ExceptionHandlingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            logger.LogError(
                exception, "Exception occurred: {Message}", exception.Message);

            var problemDetails = new ProblemDetails();

            if (exception is DomainException e)
            {
                problemDetails.Status = 422;
                problemDetails.Title = e.Message;
                
                context.Response.StatusCode =
                    StatusCodes.Status422UnprocessableEntity;
                
                await context.Response.WriteAsJsonAsync(problemDetails);
            }
            else
            {

                problemDetails.Status = 500;
                problemDetails.Title = "Server error";
                
                context.Response.StatusCode =
                    StatusCodes.Status500InternalServerError;

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }
    }
}