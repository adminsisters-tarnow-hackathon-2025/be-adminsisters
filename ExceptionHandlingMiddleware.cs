using Microsoft.AspNetCore.Mvc;

namespace be_adminsisters;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            
            } catch (Exception exception)
            {
                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Type = "ServerError",
                    Title = "Błąd serwera!",
                    Detail = "Wystąpił nieoczekiwany błąd."
                };

                problemDetails.Extensions["exception"] = exception.Message;
                logger.LogError(exception, "Wystąpił nieoczekiwany błąd serwera: {Message}", exception.Message);
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }
    }
