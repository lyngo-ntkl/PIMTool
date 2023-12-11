using PIMTool.Core.Exceptions;

namespace PIMTool.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected exception");
                int statusCode = GetStatusCode(ex);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;

                await context.Response.WriteAsync(new
                {
                    Code = statusCode,
                    Message = ex.Message
                }.ToString() ?? string.Empty);
            }
        }

        private int GetStatusCode(Exception exception)
        {
            if(typeof(Exception) == typeof(NotFoundException))
            {
                return 404;
            }
            else
            {
                return 500;
            }
        }
    }
}