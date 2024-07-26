using ING_Recruitment_Task.Utilities.Exceptions;
using Newtonsoft.Json;
using Serilog;

namespace ING_Recruitment_Task.MiddleWare
{
    public class ExceptionhandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionhandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (NbpServiceException ex)
            {
                await HandleExceptionAsync(httpContext, ex.Message, (int)ex.Code);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message, ex);
                await HandleExceptionAsync(httpContext, "Something went wrong", StatusCodes.Status500InternalServerError);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, string message, int statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            var result = JsonConvert.SerializeObject(new { error = message });
            Log.Error(result);
            return context.Response.WriteAsync(result);
        }
    }
}
